namespace VVA_Controller
{
    partial class TestTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new VVA_Controller.CustomDataGridView();
            this.Scene = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BaselineDuration = new CSUST.Data.TNumEditDataGridViewColumn();
            this.Motion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Amplitude = new CSUST.Data.TNumEditDataGridViewColumn();
            this.Frequency = new CSUST.Data.TNumEditDataGridViewColumn();
            this.Gain = new CSUST.Data.TNumEditDataGridViewColumn();
            this.Duration = new CSUST.Data.TNumEditDataGridViewColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Scene,
            this.BaselineDuration,
            this.Motion,
            this.Amplitude,
            this.Frequency,
            this.Gain,
            this.Duration});
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 25;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(583, 114);
            this.dgv.TabIndex = 24;
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            this.dgv.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_CurrentCellDirtyStateChanged);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // Scene
            // 
            this.Scene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Scene.HeaderText = "Baseline";
            this.Scene.Name = "Scene";
            this.Scene.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Scene.Width = 75;
            // 
            // BaselineDuration
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "F0";
            this.BaselineDuration.DefaultCellStyle = dataGridViewCellStyle6;
            this.BaselineDuration.DividerWidth = 3;
            this.BaselineDuration.HeaderText = "Duration (seconds)";
            this.BaselineDuration.Name = "BaselineDuration";
            this.BaselineDuration.Width = 75;
            // 
            // Motion
            // 
            this.Motion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Motion.HeaderText = "Motion Direction";
            this.Motion.Name = "Motion";
            // 
            // Amplitude
            // 
            this.Amplitude.DecimalLength = 1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "F1";
            this.Amplitude.DefaultCellStyle = dataGridViewCellStyle7;
            this.Amplitude.HeaderText = "Amplitude (degrees)";
            this.Amplitude.Name = "Amplitude";
            this.Amplitude.RemoveTrailingZeros = true;
            this.Amplitude.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Amplitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Amplitude.Width = 75;
            // 
            // Frequency
            // 
            this.Frequency.DecimalLength = 2;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "F2";
            this.Frequency.DefaultCellStyle = dataGridViewCellStyle8;
            this.Frequency.HeaderText = "Frequency (Hz)";
            this.Frequency.Name = "Frequency";
            this.Frequency.RemoveTrailingZeros = true;
            this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency.Width = 75;
            // 
            // Gain
            // 
            this.Gain.DecimalLength = 4;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "F4";
            this.Gain.DefaultCellStyle = dataGridViewCellStyle9;
            this.Gain.HeaderText = "Gain";
            this.Gain.Name = "Gain";
            this.Gain.RemoveTrailingZeros = true;
            this.Gain.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Gain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Gain.Width = 75;
            // 
            // Duration
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "F0";
            this.Duration.DefaultCellStyle = dataGridViewCellStyle10;
            this.Duration.HeaderText = "Duration (seconds)";
            this.Duration.Name = "Duration";
            this.Duration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Duration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Duration.Width = 75;
            // 
            // TestTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.dgv);
            this.Name = "TestTable";
            this.Size = new System.Drawing.Size(589, 120);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGridView dgv;
        private System.Windows.Forms.DataGridViewComboBoxColumn Scene;
        private CSUST.Data.TNumEditDataGridViewColumn BaselineDuration;
        private System.Windows.Forms.DataGridViewComboBoxColumn Motion;
        private CSUST.Data.TNumEditDataGridViewColumn Amplitude;
        private CSUST.Data.TNumEditDataGridViewColumn Frequency;
        private CSUST.Data.TNumEditDataGridViewColumn Gain;
        private CSUST.Data.TNumEditDataGridViewColumn Duration;
    }
}
