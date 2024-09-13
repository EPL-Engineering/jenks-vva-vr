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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
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

            _haveVR = ConnectToVR();
        }

        private bool ConnectToVR()
        {
            var ping = PingVR();

            if (ping)
            {
                connectionStatusLabel.Image = imageList.Images[1];
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
            _haveVR = ConnectToVR();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Information("Exit");
            Log.CloseAndFlush();
        }
    }
}
