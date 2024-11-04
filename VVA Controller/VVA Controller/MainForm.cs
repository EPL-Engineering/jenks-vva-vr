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
        private double _phaseDuration;
        private DateTime _lastStatusCheck;
        private bool _haveFileName;

        private AppSettings _appSettings;
        private ControllerSettings _controllerSettings;

        private enum RunPhase { Baseline, Motion}
        private RunPhase _runPhase;
        private bool _userAbort;

        public MainForm()
        {
            InitializeComponent();

            progressLabel.Text = "";
            startButton.Enabled = false;
            testTable.ClearTable();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _appSettings = AppSettings.Restore();

            if (_appSettings.controllerLocation.X > 0)
            {
                StartPosition = FormStartPosition.Manual;
                Location = _appSettings.controllerLocation;
            }

            KLib.Controls.Utilities.SetEnumItems(baselineSceneListBox, typeof(Scene));
            KLib.Controls.Utilities.SetEnumItems(motionSourceListBox, typeof(MotionSource));
            KLib.Controls.Utilities.SetEnumItems(motionDirectionListBox, typeof(MotionDirection));

            Log.Information($"VVA Controller v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} started");
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            connectionStatusLabel.Text = "Starting logger...";
            Refresh();

            await StartLogging();

            connectionStatusLabel.Text = "Restoring tests...";
            Refresh();

            await RestoreSettings();

            if (_appSettings.protocolState != null && !_appSettings.protocolState.IsFinished)
            {
                ShowProtocol();
            }

            TryVRConnection();
        }

        private void mmFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void mmFileRestore_Click(object sender, EventArgs e)
        {
            await RestoreSettings();
        }

        private void mmFileSave_Click(object sender, EventArgs e)
        {
            ReadSettings();
            _controllerSettings.Save();
            MessageBox.Show("Saved defaults.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mmToolsScene_Click(object sender, EventArgs e)
        {
            var dlg = new ScenePropertiesDialog(_controllerSettings);
            dlg.ShowDialog();
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
                    retainedFileCountLimit: 30,
                    buffered: true)
                .CreateLogger();
        }

        private async Task RestoreSettings()
        {
            _controllerSettings = ControllerSettings.Restore();

            KLib.Controls.Utilities.SetCheckedEnumItems(baselineSceneListBox, _controllerSettings.baselineScenes);
            KLib.Controls.Utilities.SetCheckedEnumItems(motionSourceListBox, _controllerSettings.motionSources);
            KLib.Controls.Utilities.SetCheckedEnumItems(motionDirectionListBox, _controllerSettings.motionDirections);

            linkedParamsTable.Value = _controllerSettings.linkedParams;
        }

        private void ReadSettings()
        {
            _controllerSettings.baselineScenes = KLib.Controls.Utilities.GetCheckedEnumItems<Scene>(baselineSceneListBox);
            _controllerSettings.motionSources = KLib.Controls.Utilities.GetCheckedEnumItems<MotionSource>(motionSourceListBox);
            _controllerSettings.motionDirections = KLib.Controls.Utilities.GetCheckedEnumItems<MotionDirection>(motionDirectionListBox);
        }

        private void connectionStatusLabel_DoubleClick(object sender, EventArgs e)
        {
            TryVRConnection();
        }

        private void headsetLabel_DoubleClick(object sender, EventArgs e)
        {
            headsetLabel.Text = GetHeadset();
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
            headsetLabel.Text = GetHeadset();

            startButton.Enabled = _haveVR && _appSettings.protocolState != null && !_appSettings.protocolState.IsFinished;
            mmToolsHeadset.Enabled = _haveVR;
        }

        private string GetHeadset()
        {
            string result = "---";
            bool eyeTrackingReady = false;
            if (_haveVR)
            {
                result = KTcpClient.SendMessageReceiveString(_ipEndPoint, "GetHeadset");
                if (!string.IsNullOrEmpty(result) && result.Equals("None"))
                {
                    result = "No HMD";
                }
                else
                {
                    eyeTrackingReady = KTcpClient.SendMessage(_ipEndPoint, "GetEyeTrackingReady") > 0;
                }
            }

            headsetLabel.BackColor = eyeTrackingReady ? Color.LightGreen : connectionStatusLabel.BackColor;

            return result;
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
                        ep = Discovery.Discover("VVA VR", "localhost");
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

            _ipEndPoint = Discovery.Discover("VVA VR", "localhost");
            if (_ipEndPoint != null)
            {
                var result = KTcpClient.SendMessage(_ipEndPoint, "Ping");
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
            startButton.Enabled = false;
            try
            {
                var test = _appSettings.protocolState.CurrentTest;

                if (test.baselineScene == Scene.Dots)
                {
                    Log.Information("Sending dot properties: " + _controllerSettings.dotProperties);
                    KTcpClient.SendMessage(_ipEndPoint, "DotProperties", KFile.ToProtoBuf(_controllerSettings.dotProperties));
                }
                else if (test.baselineScene == Scene.Bars)
                {
                    Log.Information("Sending grating properties: " + _controllerSettings.wallProperties);
                    KTcpClient.SendMessage(_ipEndPoint, "GratingProperties", KFile.ToProtoBuf(_controllerSettings.wallProperties));
                }

                _userAbort = false;
                _runPhase = RunPhase.Baseline;
                _phaseDuration = test.baselineDuration_s;

                var runMessage = new RunMessage()
                {
                    scene = test.baselineScene,
                    motionSource = test.motionSource,
                    motionDirection = test.motionDirection,
                    amplitude_degrees = 0,
                    duration_s = test.baselineDuration_s
                };

                progressLabel.Text = $"Test {_appSettings.protocolState.nextTest + 1}: baseline";
                Log.Information($"Starting test {_appSettings.protocolState.nextTest + 1}/{_appSettings.protocolState.protocol.Count}: {test.ToLogString()}");
                Log.Information("Baseline phase: " + runMessage.ToLogString());

                KTcpClient.SendMessage(_ipEndPoint, $"StartTest:{test.ToLogString()}");
                var response = KTcpClient.SendMessage(_ipEndPoint, "Run", KFile.ToProtoBuf(runMessage));
                startButton.Visible = false;

                progressBar.Maximum = (int)(_phaseDuration / (0.001 * runTimer.Interval));
                progressBar.Value = 0;

                _runStartTime = DateTime.Now;
                _lastStatusCheck = DateTime.Now;
                _haveFileName = false;
                runTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                runTimer.Enabled = false;
                startButton.Visible = true;
                startButton.Enabled = true;

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EndBaseline()
        {
            try
            {
                var test = _appSettings.protocolState.CurrentTest;

                _runPhase = RunPhase.Motion;
                _phaseDuration = test.duration_s;

                var runMessage = new RunMessage()
                {
                    scene = Scene.Bars,
                    motionSource = test.motionSource,
                    motionDirection = test.motionDirection,
                    amplitude_degrees = test.amplitude_degrees,
                    frequency_Hz = test.frequency_Hz,
                    gain = test.gain,
                    duration_s = test.duration_s
                };

                progressLabel.Text = $"Test {_appSettings.protocolState.nextTest + 1}: motion";
                Log.Information("Motion phase: " + runMessage.ToLogString());

                var response = KTcpClient.SendMessage(_ipEndPoint, "Run", KFile.ToProtoBuf(runMessage));

                progressBar.Maximum = (int)(_phaseDuration / (0.001 * runTimer.Interval));
                progressBar.Value = 0;

                _runStartTime = DateTime.Now;
                _lastStatusCheck = DateTime.Now;
                runTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                runTimer.Enabled = false;
                startButton.Visible = true;
                startButton.Enabled = true;

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EndRun(bool userAbort, bool vrStopped)
        {
            if (!vrStopped)
            {
                Log.Information("Ending run");
                KTcpClient.SendMessage(_ipEndPoint, "Abort");
            }

            startButton.Visible = true;
            startButton.Enabled = true;
            progressBar.Value = 0;

            if (vrStopped)
            {
                Log.Error("VR stopped unexpectedly");
                elapsedTimeLabel.Text = "error";
                KLib.Controls.MsgBox.Show("VR stopped unexpectedly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (userAbort)
            {
                Log.Information("Run stopped by user");
            }
            else
            {
                _appSettings.protocolState.Advance();
                _appSettings.Save();
                ShowProtocol();
            }

            progressLabel.Text = "";
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _userAbort = true;
        }

        private void runTimer_Tick(object sender, EventArgs e)
        {
            var elapsedTime = (DateTime.Now - _runStartTime);
            progressBar.Value = Math.Min(progressBar.Value + 1, progressBar.Maximum);
            elapsedTimeLabel.Text = elapsedTime.ToString(@"mm\:ss");

            bool vrStopped = false;
            if ((DateTime.Now - _lastStatusCheck).TotalSeconds > 2)
            {
                if (!_haveFileName)
                {
                    var fn = KTcpClient.SendMessageReceiveString(_ipEndPoint, "GetFilename");
                    datafileTextBox.Text = "File: " +  fn;
                    Log.Information("Datafile=" + fn);
                    _haveFileName = true;
                }

                _lastStatusCheck = DateTime.Now;
                vrStopped = KTcpClient.SendMessage(_ipEndPoint, "GetStatus") < 0;
            }

            if (elapsedTime.TotalSeconds > _phaseDuration || vrStopped || _userAbort)
            {
                runTimer.Enabled = false;
                if (_runPhase == RunPhase.Baseline && !vrStopped && !_userAbort)
                {
                    EndBaseline();
                }
                else
                {
                    EndRun(_userAbort, vrStopped);
                }
            }
        }

        private void mmToolsHeadset_Click(object sender, EventArgs e)
        {
            var dlg = new HeadsetDialog(_ipEndPoint);
            dlg.ShowDialog();
        }

        private void mmToolsMoog_Click(object sender, EventArgs e)
        {
            KTcpClient.SendMessage(_ipEndPoint, "DotProperties", KFile.ToProtoBuf(_controllerSettings.dotProperties));
            KTcpClient.SendMessage(_ipEndPoint, "GratingProperties", KFile.ToProtoBuf(_controllerSettings.wallProperties));

            var dlg = new MoogDialog(_ipEndPoint, _appSettings.protocolState.CurrentTest);
            dlg.ShowDialog();
        }

        private void randomizeButton_Click(object sender, EventArgs e)
        {
            ReadSettings();

            var tests = new List<TestSpecification>();

            foreach (var s in _controllerSettings.baselineScenes)
            foreach (var src in _controllerSettings.motionSources)
            foreach (var d in _controllerSettings.motionDirections)
            foreach (var p in _controllerSettings.linkedParams.FindAll(x => x.isActive))
                tests.Add(
                    new TestSpecification
                    {
                        baselineScene = s,
                        baselineDuration_s = _controllerSettings.defaultBaselineDuration_s,
                        motionSource = src,
                        motionDirection = d,
                        amplitude_degrees = _controllerSettings.defaultAmplitude_degrees,
                        frequency_Hz = p.frequency_Hz,
                        gain = (d == MotionDirection.RollTilt) ? 1 : p.gain,
                        duration_s = p.duration_s
                    }
                    );

            var randomized = new List<TestSpecification>();
            foreach (int i in KLib.KMath.MathUtils.Permute(tests.Count))
            {
                randomized.Add(tests[i]);
            }

            _appSettings.protocolState = new ProtocolState(randomized);
            _appSettings.Save();

            ShowProtocol();
        }

        private void ShowProtocol()
        {
            testTable.FillTable(_appSettings.protocolState.protocol, _appSettings.protocolState.nextTest);

            lockButton.Checked = _appSettings.protocolState != null && !_appSettings.protocolState.IsFinished;
            lockButton.Enabled = lockButton.Checked;

            startButton.Enabled = lockButton.Checked;
        }

        private void lockButton_CheckedChanged(object sender, EventArgs e)
        {
            lockButton.Text = lockButton.Checked ? "Locked" : "Lock";
            lockButton.ImageIndex = lockButton.Checked ? 1 : 0;

            baselineSceneListBox.Enabled = !lockButton.Checked;
            motionSourceListBox.Enabled = !lockButton.Checked;
            motionDirectionListBox.Enabled = !lockButton.Checked;
            linkedParamsTable.Enabled = !lockButton.Checked;
            randomizeButton.Enabled = !lockButton.Checked;
        }
    }
}
