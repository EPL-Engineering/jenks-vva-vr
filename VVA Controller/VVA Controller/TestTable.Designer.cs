﻿namespace VVA_Controller
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Scene = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Motion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Amplitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gain = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Source,
            this.Motion,
            this.Amplitude,
            this.Velocity,
            this.Gain,
            this.Duration});
            this.dgv.Location = new System.Drawing.Point(3, 3);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(572, 118);
            this.dgv.TabIndex = 24;
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            this.dgv.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgv_CurrentCellDirtyStateChanged);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // Scene
            // 
            this.Scene.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Scene.HeaderText = "Scene";
            this.Scene.Name = "Scene";
            this.Scene.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Scene.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Scene.Width = 75;
            // 
            // Source
            // 
            this.Source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            this.Source.Width = 75;
            // 
            // Motion
            // 
            this.Motion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Motion.HeaderText = "Motion";
            this.Motion.Name = "Motion";
            // 
            // Amplitude
            // 
            this.Amplitude.HeaderText = "Amplitude";
            this.Amplitude.Name = "Amplitude";
            this.Amplitude.Width = 75;
            // 
            // Velocity
            // 
            this.Velocity.HeaderText = "Velocity";
            this.Velocity.Name = "Velocity";
            this.Velocity.Width = 75;
            // 
            // Gain
            // 
            this.Gain.HeaderText = "Gain";
            this.Gain.Name = "Gain";
            this.Gain.Width = 75;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Seconds";
            this.Duration.Name = "Duration";
            this.Duration.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.Size = new System.Drawing.Size(578, 124);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewComboBoxColumn Scene;
        private System.Windows.Forms.DataGridViewComboBoxColumn Source;
        private System.Windows.Forms.DataGridViewComboBoxColumn Motion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amplitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Velocity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gain;
        private CSUST.Data.TNumEditDataGridViewColumn Duration;
    }
}
