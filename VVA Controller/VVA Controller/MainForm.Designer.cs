
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datafileTextBox = new System.Windows.Forms.TextBox();
            this.testTable = new VVA_Controller.TestTable();
            this.controlTable = new VVA_Controller.TestTable();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
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
            this.statusStrip.Location = new System.Drawing.Point(0, 498);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(604, 22);
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
            this.elapsedTimeLabel.DoubleClick += new System.EventHandler(this.elapsedTimeLabel_DoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "nav_plain_red.png");
            this.imageList.Images.SetKeyName(1, "nav_plain_yellow.png");
            this.imageList.Images.SetKeyName(2, "nav_plain_green.png");
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
            this.mainMenu.Size = new System.Drawing.Size(604, 23);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Controls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(17, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 24);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tests";
            // 
            // datafileTextBox
            // 
            this.datafileTextBox.Location = new System.Drawing.Point(200, 446);
            this.datafileTextBox.Name = "datafileTextBox";
            this.datafileTextBox.ReadOnly = true;
            this.datafileTextBox.Size = new System.Drawing.Size(379, 20);
            this.datafileTextBox.TabIndex = 28;
            // 
            // testTable
            // 
            this.testTable.AutoSize = true;
            this.testTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.testTable.Location = new System.Drawing.Point(21, 235);
            this.testTable.Name = "testTable";
            this.testTable.Size = new System.Drawing.Size(578, 120);
            this.testTable.TabIndex = 30;
            this.testTable.Type = Jenks.VVA.MotionSource.Internal;
            this.testTable.Value = null;
            this.testTable.SelectionChanged += new System.EventHandler(this.testTable_SelectionChanged);
            // 
            // controlTable
            // 
            this.controlTable.AutoSize = true;
            this.controlTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlTable.Location = new System.Drawing.Point(21, 66);
            this.controlTable.Name = "controlTable";
            this.controlTable.Size = new System.Drawing.Size(578, 120);
            this.controlTable.TabIndex = 29;
            this.controlTable.Type = Jenks.VVA.MotionSource.Internal;
            this.controlTable.Value = null;
            this.controlTable.SelectionChanged += new System.EventHandler(this.controlTable_SelectionChanged);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Image = global::VVA_Controller.Properties.Resources.media_play_green;
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.Location = new System.Drawing.Point(21, 429);
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
            this.stopButton.Location = new System.Drawing.Point(21, 429);
            this.stopButton.Name = "stopButton";
            this.stopButton.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.stopButton.Size = new System.Drawing.Size(144, 51);
            this.stopButton.TabIndex = 21;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 520);
            this.Controls.Add(this.testTable);
            this.Controls.Add(this.controlTable);
            this.Controls.Add(this.datafileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmFileRestore;
        private System.Windows.Forms.ToolStripMenuItem mmFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mmFileExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmToolsScene;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel headsetLabel;
        private System.Windows.Forms.TextBox datafileTextBox;
        private TestTable controlTable;
        private TestTable testTable;
        private System.Windows.Forms.ToolStripMenuItem mmToolsHeadset;
        private System.Windows.Forms.ToolStripMenuItem mmToolsMoog;
    }
}

