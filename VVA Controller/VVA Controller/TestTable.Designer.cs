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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new VVA_Controller.CustomDataGridView();
            this.BaselineScene = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaselineDuration = new CSUST.Data.TNumEditDataGridViewColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BaselineScene,
            this.BaselineDuration,
            this.Source,
            this.Direction,
            this.Amplitude,
            this.Frequency,
            this.Gain,
            this.Duration});
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 50;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(581, 275);
            this.dgv.TabIndex = 24;
            // 
            // BaselineScene
            // 
            this.BaselineScene.HeaderText = "Baseline";
            this.BaselineScene.Name = "BaselineScene";
            this.BaselineScene.ReadOnly = true;
            this.BaselineScene.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BaselineScene.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BaselineScene.Width = 60;
            // 
            // BaselineDuration
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "F0";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.BaselineDuration.DefaultCellStyle = dataGridViewCellStyle2;
            this.BaselineDuration.HeaderText = "Dur (s)";
            this.BaselineDuration.Name = "BaselineDuration";
            this.BaselineDuration.ReadOnly = true;
            this.BaselineDuration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BaselineDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BaselineDuration.Width = 50;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Source.Width = 65;
            // 
            // Direction
            // 
            this.Direction.HeaderText = "Direction";
            this.Direction.Name = "Direction";
            this.Direction.ReadOnly = true;
            this.Direction.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Direction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Direction.Width = 75;
            // 
            // Amplitude
            // 
            this.Amplitude.DecimalLength = 1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "F1";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Amplitude.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amplitude.HeaderText = "Ampl (deg)";
            this.Amplitude.Name = "Amplitude";
            this.Amplitude.ReadOnly = true;
            this.Amplitude.RemoveTrailingZeros = true;
            this.Amplitude.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Amplitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Amplitude.Width = 75;
            // 
            // Frequency
            // 
            this.Frequency.DecimalLength = 2;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F2";
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Frequency.DefaultCellStyle = dataGridViewCellStyle4;
            this.Frequency.HeaderText = "Freq (Hz)";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.RemoveTrailingZeros = true;
            this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency.Width = 75;
            // 
            // Gain
            // 
            this.Gain.DecimalLength = 4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F4";
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Gain.DefaultCellStyle = dataGridViewCellStyle5;
            this.Gain.HeaderText = "Gain";
            this.Gain.Name = "Gain";
            this.Gain.ReadOnly = true;
            this.Gain.RemoveTrailingZeros = true;
            this.Gain.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Gain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Gain.Width = 50;
            // 
            // Duration
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "F0";
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Duration.DefaultCellStyle = dataGridViewCellStyle6;
            this.Duration.DividerWidth = 1;
            this.Duration.HeaderText = "Dur (s)";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Duration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Duration.Width = 50;
            // 
            // TestTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.dgv);
            this.Name = "TestTable";
            this.Size = new System.Drawing.Size(593, 284);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaselineScene;
        private CSUST.Data.TNumEditDataGridViewColumn BaselineDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private CSUST.Data.TNumEditDataGridViewColumn Amplitude;
        private CSUST.Data.TNumEditDataGridViewColumn Frequency;
        private CSUST.Data.TNumEditDataGridViewColumn Gain;
        private CSUST.Data.TNumEditDataGridViewColumn Duration;
    }
}
