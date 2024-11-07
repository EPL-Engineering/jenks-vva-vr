
namespace VVA_Controller
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.headsetLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.elapsedTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.runTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmFileRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.mmFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mmFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmToolsHeadset = new System.Windows.Forms.ToolStripMenuItem();
            this.mmToolsMoog = new System.Windows.Forms.ToolStripMenuItem();
            this.mmToolsScene = new System.Windows.Forms.ToolStripMenuItem();
            this.datafileTextBox = new System.Windows.Forms.TextBox();
            this.motionSourceListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.baselineSceneListBox = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.motionDirectionListBox = new System.Windows.Forms.CheckedListBox();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.imageList32 = new System.Windows.Forms.ImageList(this.components);
            this.lockButton = new System.Windows.Forms.CheckBox();
            this.progressLabel = new System.Windows.Forms.Label();
            this.testTable = new VVA_Controller.TestTable();
            this.linkedParamsTable = new VVA_Controller.LinkedParamsTable();
            this.statusStrip.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatusLabel,
            this.headsetLabel,
            this.progressBar,
            this.elapsedTimeLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 538);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(598, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = false;
            this.connectionStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.connectionStatusLabel.DoubleClickEnabled = true;
            this.connectionStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(275, 17);
            this.connectionStatusLabel.Text = "Not connected to VR";
            this.connectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectionStatusLabel.DoubleClick += new System.EventHandler(this.connectionStatusLabel_DoubleClick);
            // 
            // headsetLabel
            // 
            this.headsetLabel.AutoSize = false;
            this.headsetLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.headsetLabel.Name = "headsetLabel";
            this.headsetLabel.Size = new System.Drawing.Size(75, 17);
            this.headsetLabel.Text = "---";
            this.headsetLabel.DoubleClick += new System.EventHandler(this.headsetLabel_DoubleClick);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.DoubleClickEnabled = true;
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "nav_plain_red.png");
            this.imageList.Images.SetKeyName(1, "nav_plain_yellow.png");
            this.imageList.Images.SetKeyName(2, "nav_plain_green.png");
            this.imageList.Images.SetKeyName(3, "lock_open.png");
            this.imageList.Images.SetKeyName(4, "lock.png");
            // 
            // runTimer
            // 
            this.runTimer.Interval = 250;
            this.runTimer.Tick += new System.EventHandler(this.runTimer_Tick);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(598, 23);
            this.mainMenu.TabIndex = 22;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmFileRestore,
            this.mmFileSave,
            this.toolStripSeparator1,
            this.mmFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mmFileRestore
            // 
            this.mmFileRestore.Name = "mmFileRestore";
            this.mmFileRestore.Size = new System.Drawing.Size(158, 22);
            this.mmFileRestore.Text = "&Restore defaults";
            this.mmFileRestore.Click += new System.EventHandler(this.mmFileRestore_Click);
            // 
            // mmFileSave
            // 
            this.mmFileSave.Name = "mmFileSave";
            this.mmFileSave.Size = new System.Drawing.Size(158, 22);
            this.mmFileSave.Text = "&Save defaults";
            this.mmFileSave.Click += new System.EventHandler(this.mmFileSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // mmFileExit
            // 
            this.mmFileExit.Name = "mmFileExit";
            this.mmFileExit.Size = new System.Drawing.Size(158, 22);
            this.mmFileExit.Text = "E&xit";
            this.mmFileExit.Click += new System.EventHandler(this.mmFileExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmToolsHeadset,
            this.mmToolsMoog,
            this.mmToolsScene});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.editToolStripMenuItem.Text = "&Tools";
            // 
            // mmToolsHeadset
            // 
            this.mmToolsHeadset.Enabled = false;
            this.mmToolsHeadset.Name = "mmToolsHeadset";
            this.mmToolsHeadset.Size = new System.Drawing.Size(161, 22);
            this.mmToolsHeadset.Text = "&Headset";
            this.mmToolsHeadset.Click += new System.EventHandler(this.mmToolsHeadset_Click);
            // 
            // mmToolsMoog
            // 
            this.mmToolsMoog.Name = "mmToolsMoog";
            this.mmToolsMoog.Size = new System.Drawing.Size(161, 22);
            this.mmToolsMoog.Text = "&Moog";
            this.mmToolsMoog.Click += new System.EventHandler(this.mmToolsMoog_Click);
            // 
            // mmToolsScene
            // 
            this.mmToolsScene.Name = "mmToolsScene";
            this.mmToolsScene.Size = new System.Drawing.Size(161, 22);
            this.mmToolsScene.Text = "&Scene properties";
            this.mmToolsScene.Click += new System.EventHandler(this.mmToolsScene_Click);
            // 
            // datafileTextBox
            // 
            this.datafileTextBox.Location = new System.Drawing.Point(196, 470);
            this.datafileTextBox.Name = "datafileTextBox";
            this.datafileTextBox.ReadOnly = true;
            this.datafileTextBox.Size = new System.Drawing.Size(374, 20);
            this.datafileTextBox.TabIndex = 28;
            // 
            // motionSourceListBox
            // 
            this.motionSourceListBox.CheckOnClick = true;
            this.motionSourceListBox.FormattingEnabled = true;
            this.motionSourceListBox.IntegralHeight = false;
            this.motionSourceListBox.Items.AddRange(new object[] {
            "Internal",
            "Moog"});
            this.motionSourceListBox.Location = new System.Drawing.Point(126, 66);
            this.motionSourceListBox.Name = "motionSourceListBox";
            this.motionSourceListBox.Size = new System.Drawing.Size(100, 87);
            this.motionSourceListBox.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Motion control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Baseline scene";
            // 
            // baselineSceneListBox
            // 
            this.baselineSceneListBox.CheckOnClick = true;
            this.baselineSceneListBox.FormattingEnabled = true;
            this.baselineSceneListBox.IntegralHeight = false;
            this.baselineSceneListBox.Items.AddRange(new object[] {
            "Black"});
            this.baselineSceneListBox.Location = new System.Drawing.Point(20, 66);
            this.baselineSceneListBox.Name = "baselineSceneListBox";
            this.baselineSceneListBox.Size = new System.Drawing.Size(100, 87);
            this.baselineSceneListBox.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Motion direction";
            // 
            // motionDirectionListBox
            // 
            this.motionDirectionListBox.CheckOnClick = true;
            this.motionDirectionListBox.IntegralHeight = false;
            this.motionDirectionListBox.Items.AddRange(new object[] {
            "Roll-Tilt",
            "Translation"});
            this.motionDirectionListBox.Location = new System.Drawing.Point(233, 66);
            this.motionDirectionListBox.Name = "motionDirectionListBox";
            this.motionDirectionListBox.Size = new System.Drawing.Size(100, 87);
            this.motionDirectionListBox.TabIndex = 34;
            // 
            // randomizeButton
            // 
            this.randomizeButton.Image = global::VVA_Controller.Properties.Resources.dice_blue1;
            this.randomizeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.randomizeButton.Location = new System.Drawing.Point(21, 159);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.randomizeButton.Size = new System.Drawing.Size(169, 56);
            this.randomizeButton.TabIndex = 37;
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.UseVisualStyleBackColor = true;
            this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Image = global::VVA_Controller.Properties.Resources.media_play_green;
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.Location = new System.Drawing.Point(21, 453);
            this.startButton.Name = "startButton";
            this.startButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.startButton.Size = new System.Drawing.Size(144, 51);
            this.startButton.TabIndex = 20;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Image = global::VVA_Controller.Properties.Resources.media_stop_red;
            this.stopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopButton.Location = new System.Drawing.Point(21, 453);
            this.stopButton.Name = "stopButton";
            this.stopButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.stopButton.Size = new System.Drawing.Size(144, 51);
            this.stopButton.TabIndex = 21;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // imageList32
            // 
            this.imageList32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32.ImageStream")));
            this.imageList32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList32.Images.SetKeyName(0, "lock_open.png");
            this.imageList32.Images.SetKeyName(1, "lock.png");
            // 
            // lockButton
            // 
            this.lockButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.lockButton.Enabled = false;
            this.lockButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lockButton.ImageIndex = 0;
            this.lockButton.ImageList = this.imageList32;
            this.lockButton.Location = new System.Drawing.Point(401, 159);
            this.lockButton.Name = "lockButton";
            this.lockButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lockButton.Size = new System.Drawing.Size(169, 56);
            this.lockButton.TabIndex = 41;
            this.lockButton.Text = "Lock";
            this.lockButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lockButton.UseVisualStyleBackColor = true;
            this.lockButton.CheckedChanged += new System.EventHandler(this.lockButton_CheckedChanged);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(193, 453);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(47, 13);
            this.progressLabel.TabIndex = 42;
            this.progressLabel.Text = "progress";
            // 
            // testTable
            // 
            this.testTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.testTable.Location = new System.Drawing.Point(21, 221);
            this.testTable.Name = "testTable";
            this.testTable.Size = new System.Drawing.Size(589, 211);
            this.testTable.TabIndex = 39;
            // 
            // linkedParamsTable
            // 
            this.linkedParamsTable.BackColor = System.Drawing.Color.White;
            this.linkedParamsTable.Location = new System.Drawing.Point(339, 66);
            this.linkedParamsTable.Name = "linkedParamsTable";
            this.linkedParamsTable.Size = new System.Drawing.Size(231, 94);
            this.linkedParamsTable.TabIndex = 36;
            this.linkedParamsTable.Value = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 560);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.lockButton);
            this.Controls.Add(this.testTable);
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.linkedParamsTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.motionDirectionListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.baselineSceneListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.motionSourceListBox);
            this.Controls.Add(this.datafileTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.stopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Timer runTimer;
        private System.Windows.Forms.ToolStripStatusLabel elapsedTimeLabel;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmFileRestore;
        private System.Windows.Forms.ToolStripMenuItem mmFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mmFileExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmToolsScene;
        private System.Windows.Forms.ToolStripStatusLabel headsetLabel;
        private System.Windows.Forms.TextBox datafileTextBox;
        private System.Windows.Forms.ToolStripMenuItem mmToolsHeadset;
        private System.Windows.Forms.ToolStripMenuItem mmToolsMoog;
        private System.Windows.Forms.CheckedListBox motionSourceListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox baselineSceneListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox motionDirectionListBox;
        private System.Windows.Forms.Button randomizeButton;
        private TestTable testTable;
        private LinkedParamsTable linkedParamsTable;
        private System.Windows.Forms.ImageList imageList32;
        private System.Windows.Forms.CheckBox lockButton;
        private System.Windows.Forms.Label progressLabel;
    }
}

