using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KLib.Net;

namespace VVA_Controller
{
    public partial class MainForm : Form
    {
        private bool _haveVR;
        private IPEndPoint _ipEndPoint;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _haveVR = ConnectToVR();
        }

        private bool ConnectToVR()
        {
            var ping = PingVR();

            if (ping)
            {
                connectionStatusLabel.Image = imageList.Images[1];
                connectionStatusLabel.Text = $"Connected to VR at {_ipEndPoint.ToString()}";
            }
            else
            {
                connectionStatusLabel.Image = imageList.Images[0];
                connectionStatusLabel.Text = "No VR connection (double-click to retry)";
            }

            return false;
        }

        private bool PingVR()
        {
            bool success = false;

            connectionStatusLabel.Image = imageList.Images[0];
            connectionStatusLabel.Text = "Connecting to VR...";
            Refresh();

            _ipEndPoint = Discovery.Discover("VVA VR");
            if (_ipEndPoint != null)
            {
                var result = KTcpClient.SendCommand(_ipEndPoint, "Ping");
                success = result > 0;
            }

            return success;
        }

        private void connectionStatusLabel_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("wtf");
            _haveVR = ConnectToVR();
        }
    }
}
