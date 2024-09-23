using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib;
using KLib.Net;

using Jenks.VVA;

namespace VVA_Controller
{
    public partial class MoogDialog : Form
    {
        private IPEndPoint _ipEndPoint;
        private TestSpecification _test;

        private CancellationTokenSource _cts;
        private SynchronizationContext _synchronizationContext;

        public MoogDialog(IPEndPoint ipEndPoint, TestSpecification test)
        {
            _ipEndPoint = ipEndPoint;
            _test = test;

            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void simulateButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = true;
            closeButton.Enabled = false;
            simulateButton.Visible = false;

            _cts = new CancellationTokenSource();
            await SimulateMoog(_cts.Token);

            simulateButton.Visible = true;
            closeButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
                stopButton.Enabled = false;
            }
        }

        private async Task SimulateMoog(CancellationToken ct)
        {
            try
            {
                await DoSimulation(ct);
            }
            catch (OperationCanceledException ex)
            {
                KTcpClient.SendMessage(_ipEndPoint, "Abort");
            }
        }

        private async Task DoSimulation(CancellationToken ct)
        {
            var udpClient = new UdpClient();

            _test.motionSource = MotionSource.UDP;
            var response = KTcpClient.SendMessage(_ipEndPoint, "Run", KFile.ToProtoBuf(_test));

            float t = 0;
            float x = 0;
            float rollTilt = 0;
            float deltaTime = 0.016f;

            float[] data = new float[2];
            byte[] byteArray = new byte[2 * sizeof(float)];

            var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 61557);

            while (true && t < _test.duration_s)
            {
                ct.ThrowIfCancellationRequested();

                rollTilt = _test.amplitude_degrees * (float) Math.Sin(2 * Math.PI * _test.frequency_Hz * t);
                t += deltaTime;

                data[0] = rollTilt;
                data[1] = x;

                Buffer.BlockCopy(data, 0, byteArray, 0, byteArray.Length);
                udpClient.Send(byteArray, byteArray.Length, endpoint);

                await Task.Delay(16);
            }

            KTcpClient.SendMessage(_ipEndPoint, "Abort");
        }
    }
}
