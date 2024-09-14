using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;

using KLib.Net;

namespace VVA_Controller
{
    public partial class MainForm : Form
    {
        private bool _haveVR;
        private IPEndPoint _ipEndPoint;

        private Serilog.Core.LoggingLevelSwitch _logLevel = new Serilog.Core.LoggingLevelSwitch();

        private DateTime _runStartTime;
        private double _runDuration;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _logLevel.MinimumLevel = Serilog.Events.LogEventLevel.Verbose;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(_logLevel)
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Jenks", "Logs", "VVA-Controller-.txt"),
                    rollingInterval: RollingInterval.Day,
                    buffered: true)
                .CreateLogger();

            Log.Information($"VVA Controller v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _haveVR = ConnectToVR();
        }

        private bool ConnectToVR(bool autoStart = true)
        {
            if (autoStart)
            {
                connectionStatusLabel.Image = imageList.Images[1];
                connectionStatusLabel.Text = "Connecting to VR...";
                Refresh();
            }

            var ping = PingVR();

            if (ping)
            {
                connectionStatusLabel.Image = imageList.Images[2];
                connectionStatusLabel.Text = $"Connected to VR at {_ipEndPoint.ToString()}";
                Log.Information($"Connected to VR at {_ipEndPoint.ToString()}");
            }
            else
            {
                connectionStatusLabel.Image = imageList.Images[0];
                connectionStatusLabel.Text = "No VR connection (double-click to retry)";
                Log.Information("No VR connection");
            }

            return false;
        }

        private bool PingVR()
        {
            bool success = false;

            Log.Information("Pinging VR");

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
            _haveVR = ConnectToVR();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Information("Exit");
            Log.CloseAndFlush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KTcpClient.SendCommand(_ipEndPoint, "Exit");
            ConnectToVR(autoStart: false);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _runDuration = 15;
            _runStartTime = DateTime.Now;

            Log.Information("Starting run");
            KTcpClient.SendCommand(_ipEndPoint, "Test");
            startButton.Visible = false;

            progressBar.Maximum = (int)(_runDuration / (0.001 * runTimer.Interval));
            progressBar.Value = 0;
            runTimer.Enabled = true;
        }

        private void EndRun()
        {
            Log.Information("Aborting run");
            KTcpClient.SendCommand(_ipEndPoint, "Abort");
            startButton.Visible = true;
            progressBar.Value = 0;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            runTimer.Enabled = false;
            EndRun();
        }

        private void runTimer_Tick(object sender, EventArgs e)
        {
            var elapsedTime = (DateTime.Now - _runStartTime);
            progressBar.Value = Math.Min(progressBar.Value + 1, progressBar.Maximum);
            elapsedTimeLabel.Text = elapsedTime.ToString(@"mm\:ss");


            if (elapsedTime.TotalSeconds > _runDuration)
            {
                runTimer.Enabled = false;
                EndRun();
            }
        }
    }
}
