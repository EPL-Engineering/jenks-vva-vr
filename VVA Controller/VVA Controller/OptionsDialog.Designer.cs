namespace VVA_Controller
{
    partial class OptionsDialog
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
            this.dotSizeNumeric = new KLib.Controls.KNumericBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dotDensityNumeric = new KLib.Controls.KNumericBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dotVelocityNumeric = new KLib.Controls.KNumericBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.barDensityNumeric = new KLib.Controls.KNumericBox();
            this.label7 = new System.Windows.Forms.Label();
            this.barWidthNumeric = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // dotSizeNumeric
            // 
            this.dotSizeNumeric.AllowInf = false;
            this.dotSizeNumeric.AutoSize = true;
            this.dotSizeNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dotSizeNumeric.ClearOnDisable = false;
            this.dotSizeNumeric.FloatValue = 0F;
            this.dotSizeNumeric.IntValue = 0;
            this.dotSizeNumeric.IsInteger = false;
            this.dotSizeNumeric.Location = new System.Drawing.Point(147, 63);
            this.dotSizeNumeric.MaxCoerce = false;
            this.dotSizeNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.dotSizeNumeric.MaxValue = 1.7976931348623157E+308D;
            this.dotSizeNumeric.MinCoerce = false;
            this.dotSizeNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.dotSizeNumeric.MinValue = 0D;
            this.dotSizeNumeric.Name = "dotSizeNumeric";
            this.dotSizeNumeric.Size = new System.Drawing.Size(100, 20);
            this.dotSizeNumeric.TabIndex = 0;
            this.dotSizeNumeric.TextFormat = "K4";
            this.dotSizeNumeric.ToolTip = "";
            this.dotSizeNumeric.Units = "";
            this.dotSizeNumeric.Value = 0D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(142, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Random dots";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dot size (degrees)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Density (dots/deg2)";
            // 
            // dotDensityNumeric
            // 
            this.dotDensityNumeric.AllowInf = false;
            this.dotDensityNumeric.AutoSize = true;
            this.dotDensityNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dotDensityNumeric.ClearOnDisable = false;
            this.dotDensityNumeric.FloatValue = 0F;
            this.dotDensityNumeric.IntValue = 0;
            this.dotDensityNumeric.IsInteger = false;
            this.dotDensityNumeric.Location = new System.Drawing.Point(147, 89);
            this.dotDensityNumeric.MaxCoerce = false;
            this.dotDensityNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.dotDensityNumeric.MaxValue = 1.7976931348623157E+308D;
            this.dotDensityNumeric.MinCoerce = false;
            this.dotDensityNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.dotDensityNumeric.MinValue = 0D;
            this.dotDensityNumeric.Name = "dotDensityNumeric";
            this.dotDensityNumeric.Size = new System.Drawing.Size(100, 20);
            this.dotDensityNumeric.TabIndex = 3;
            this.dotDensityNumeric.TextFormat = "K4";
            this.dotDensityNumeric.ToolTip = "";
            this.dotDensityNumeric.Units = "";
            this.dotDensityNumeric.Value = 0D;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Velocity (s.d.)";
            // 
            // dotVelocityNumeric
            // 
            this.dotVelocityNumeric.AllowInf = false;
            this.dotVelocityNumeric.AutoSize = true;
            this.dotVelocityNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dotVelocityNumeric.ClearOnDisable = false;
            this.dotVelocityNumeric.FloatValue = 0F;
            this.dotVelocityNumeric.IntValue = 0;
            this.dotVelocityNumeric.IsInteger = false;
            this.dotVelocityNumeric.Location = new System.Drawing.Point(147, 115);
            this.dotVelocityNumeric.MaxCoerce = false;
            this.dotVelocityNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.dotVelocityNumeric.MaxValue = 1.7976931348623157E+308D;
            this.dotVelocityNumeric.MinCoerce = false;
            this.dotVelocityNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.dotVelocityNumeric.MinValue = 0D;
            this.dotVelocityNumeric.Name = "dotVelocityNumeric";
            this.dotVelocityNumeric.Size = new System.Drawing.Size(100, 20);
            this.dotVelocityNumeric.TabIndex = 5;
            this.dotVelocityNumeric.TextFormat = "K4";
            this.dotVelocityNumeric.ToolTip = "";
            this.dotVelocityNumeric.Units = "";
            this.dotVelocityNumeric.Value = 0D;
            // 
            // cancelButton
            // 
            this.cancelButton.Image = global::VVA_Controller.Properties.Resources.delete;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(396, 187);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cancelButton.Size = new System.Drawing.Size(100, 38);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Image = global::VVA_Controller.Properties.Resources.ok;
            this.applyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applyButton.Location = new System.Drawing.Point(290, 187);
            this.applyButton.Name = "applyButton";
            this.applyButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.applyButton.Size = new System.Drawing.Size(100, 38);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "Apply";
            this.applyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(412, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Grating";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Density (bars / degree)";
            // 
            // barDensityNumeric
            // 
            this.barDensityNumeric.AllowInf = false;
            this.barDensityNumeric.AutoSize = true;
            this.barDensityNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.barDensityNumeric.ClearOnDisable = false;
            this.barDensityNumeric.FloatValue = 0F;
            this.barDensityNumeric.IntValue = 0;
            this.barDensityNumeric.IsInteger = false;
            this.barDensityNumeric.Location = new System.Drawing.Point(396, 85);
            this.barDensityNumeric.MaxCoerce = false;
            this.barDensityNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.barDensityNumeric.MaxValue = 1.7976931348623157E+308D;
            this.barDensityNumeric.MinCoerce = false;
            this.barDensityNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.barDensityNumeric.MinValue = 0D;
            this.barDensityNumeric.Name = "barDensityNumeric";
            this.barDensityNumeric.Size = new System.Drawing.Size(100, 20);
            this.barDensityNumeric.TabIndex = 12;
            this.barDensityNumeric.TextFormat = "K4";
            this.barDensityNumeric.ToolTip = "";
            this.barDensityNumeric.Units = "";
            this.barDensityNumeric.Value = 0D;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Bar width degrees)";
            // 
            // barWidthNumeric
            // 
            this.barWidthNumeric.AllowInf = false;
            this.barWidthNumeric.AutoSize = true;
            this.barWidthNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.barWidthNumeric.ClearOnDisable = false;
            this.barWidthNumeric.FloatValue = 0F;
            this.barWidthNumeric.IntValue = 0;
            this.barWidthNumeric.IsInteger = false;
            this.barWidthNumeric.Location = new System.Drawing.Point(396, 59);
            this.barWidthNumeric.MaxCoerce = false;
            this.barWidthNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.barWidthNumeric.MaxValue = 1.7976931348623157E+308D;
            this.barWidthNumeric.MinCoerce = false;
            this.barWidthNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.barWidthNumeric.MinValue = 0D;
            this.barWidthNumeric.Name = "barWidthNumeric";
            this.barWidthNumeric.Size = new System.Drawing.Size(100, 20);
            this.barWidthNumeric.TabIndex = 10;
            this.barWidthNumeric.TextFormat = "K4";
            this.barWidthNumeric.ToolTip = "";
            this.barWidthNumeric.Units = "";
            this.barWidthNumeric.Value = 0D;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 253);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.barDensityNumeric);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.barWidthNumeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dotVelocityNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dotDensityNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dotSizeNumeric);
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VVA Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KLib.Controls.KNumericBox dotSizeNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private KLib.Controls.KNumericBox dotDensityNumeric;
        private System.Windows.Forms.Label label4;
        private KLib.Controls.KNumericBox dotVelocityNumeric;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private KLib.Controls.KNumericBox barDensityNumeric;
        private System.Windows.Forms.Label label7;
        private KLib.Controls.KNumericBox barWidthNumeric;
    }
}