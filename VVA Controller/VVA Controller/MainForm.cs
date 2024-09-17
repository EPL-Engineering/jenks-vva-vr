using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Serilog;

using KLib;
using KLib.Net;

using Jenks.VVA;

namespace VVA_Controller
{
    public partial class MainForm : Form
    {
        private bool _haveVR;
        private IPEndPoint _ipEndPoint;

        private Serilog.Core.LoggingLevelSwitch _logLevel = new Serilog.Core.LoggingLevelSwitch();

        private DateTime _runStartTime;
        private double _runDuration;

        private Settings _testSettings;
        private AppSettings _appSettings;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _appSettings = AppSettings.Restore();

            if (_appSettings.controllerLocation.X > 0)
            {
                StartPosition = FormStartPosition.Manual;
                Location = _appSettings.controllerLocation;
            }

            Log.Information($"VVA Controller v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            connectionStatusLabel.Text = "Starting logger...";
            Refresh();

            await StartLogging();

            _testSettings = Settings.Restore();
            TryVRConnection();
        }

        private async Task StartLogging()
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
        }

        private void connectionStatusLabel_DoubleClick(object sender, EventArgs e)
        {
            TryVRConnection();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appSettings.controllerLocation = Location;

            var vrLocation = GetVRLocation();
            if (vrLocation.X > 0)
            {
                _appSettings.vrLocation = vrLocation;
            }
            _appSettings.Save();

            CloseVRApp();

            Log.Information("Exit");
            Log.CloseAndFlush();
        }

        private void TryVRConnection()
        {
            _haveVR = ConnectToVR();
            startButton.Enabled = _haveVR;
        }

        private bool ConnectToVR(bool autoStart = true)
        {
            bool success = false;

            if (autoStart)
            {
                connectionStatusLabel.Image = imageList.Images[1];
                connectionStatusLabel.Text = "Connecting to VR...";
                Refresh();
            }

            var ping = PingVR();

            if (ping)
            {
                success = true;
                connectionStatusLabel.Image = imageList.Images[2];
                connectionStatusLabel.Text = $"Connected to VR at {_ipEndPoint.ToString()}";
                Log.Information($"Connected to VR at {_ipEndPoint.ToString()}");
            }
            else if (autoStart)
            {
                connectionStatusLabel.Text = "Launching VR...";
                Log.Information("Launching VR");
                Refresh();

                var launch = LaunchVR();

                if (launch)
                {
                    ping = PingVR();
                    if (ping)
                    {
                        success = true;
                        connectionStatusLabel.Image = imageList.Images[2];
                        connectionStatusLabel.Text = $"Connected to VR at {_ipEndPoint.ToString()}";
                        Log.Information($"Connected to VR at {_ipEndPoint.ToString()}");
                    }
                    else
                    {
                        connectionStatusLabel.Image = imageList.Images[0];
                        connectionStatusLabel.Text = "No VR connection (double-click to retry)";
                        Log.Information("No VR connection after launch");
                    }
                }
                else
                {
                    connectionStatusLabel.Image = imageList.Images[0];
                    connectionStatusLabel.Text = "Failed to launch VR (double-click to retry)";
                    Log.Information("Failed to launch VR");
                }
            }
            else
            {
                connectionStatusLabel.Image = imageList.Images[0];
                connectionStatusLabel.Text = "No VR connection (double-click to retry)";
                Log.Information("No VR connection");
            }

            return success;
        }

        private string VRAppLocation
        {
            get
            {
#if DEBUG
                var folder = @"D:\Development\Jenks\jenks-vva-vr\VVA VR\Build";
#else
                DirectoryInfo di = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
                var folder = Path.Combine(Directory.GetParent(di.FullName).FullName, "VR");
#endif
                return Path.Combine(folder, "VVA VR.exe");
            }
        }

        private bool LaunchVR()
        {
            bool success = true;
            try
            {
                Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(VRAppLocation));
                if (processes.Length == 0)
                {
                    Log.Information($"Starting new VR process '{VRAppLocation}'");
                    var proc = Process.Start(VRAppLocation);

                    // wait for VR app's discovery server to start
                    int ntries = 0;
                    IPEndPoint ep = null;
                    while (ntries < 10)
                    {
                        Thread.Sleep(1000);
                        ep = Discovery.Discover("VVA VR");
                        if (ep != null) break;
                        ++ntries;
                    }
                    if (ep == null)
                    {
                        success = false;
                        Log.Information("Timed out waiting for VR to respond");
                    }
                    else if (_appSettings.vrLocation.X > 0)
                    {
                        Windows.MoveWindow(proc.MainWindowHandle, _appSettings.vrLocation.X, _appSettings.vrLocation.Y);
                    }
                }
                else
                {
                    Log.Information("VR process already exists");
                    IntPtr hWnd = Windows.FindWindow(null, "VR Hardware");
                    Windows.ShowWindowAsync(hWnd, Windows.ShowWindowFlags.Show);
                    Windows.ShowWindowAsync(hWnd, Windows.ShowWindowFlags.Restore);
                    Windows.SetForegroundWindow(hWnd);
                }
            }
            catch (Exception ex)
            {
                success = false;
                Log.Information("VR launch failed with exception: " + ex.Message);
            }

            return success;
        }

        private Point GetVRLocation()
        {
            Point location = new Point(-1, -1);
            Windows.Rect rect = new Windows.Rect();
            Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(VRAppLocation));
            if (processes.Length > 0)
            {
                Windows.GetWindowRect(processes[0].MainWindowHandle, ref rect);
                location.X = rect.Left;
                location.Y = rect.Top;
            }

            return location;
        }

        public void CloseVRApp()
        {
            Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(VRAppLocation));
            foreach (Process p in processes)
            {
                p.CloseMainWindow();
                p.Close();
            }
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

            if (!success)
            {
                Log.Information($"Ping failed (ipEndPoint =  {_ipEndPoint})");
            }

            return success;
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
