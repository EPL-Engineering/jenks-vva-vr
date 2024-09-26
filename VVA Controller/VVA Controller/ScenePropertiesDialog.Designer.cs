namespace VVA_Controller
{
    partial class ScenePropertiesDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.wallHeightNumeric = new KLib.Controls.KNumericBox();
            this.wallDistanceNumeric = new KLib.Controls.KNumericBox();
            this.barSpacingNumeric = new KLib.Controls.KNumericBox();
            this.barWidthNumeric = new KLib.Controls.KNumericBox();
            this.dotVelocityNumeric = new KLib.Controls.KNumericBox();
            this.dotDensityNumeric = new KLib.Controls.KNumericBox();
            this.dotSizeNumeric = new KLib.Controls.KNumericBox();
            this.label10 = new System.Windows.Forms.Label();
            this.wallOffsetNumeric = new KLib.Controls.KNumericBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(379, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Random dots";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dot size (degrees)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Density (dots/deg2)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Velocity (s.d.)";
            // 
            // cancelButton
            // 
            this.cancelButton.Image = global::VVA_Controller.Properties.Resources.delete;
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(396, 188);
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
            this.applyButton.Location = new System.Drawing.Point(290, 188);
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
            this.label5.Location = new System.Drawing.Point(127, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Wall";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bar spacing (m)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Bar width (m)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Wall height (m)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "wallDistance (m)";
            // 
            // wallHeightNumeric
            // 
            this.wallHeightNumeric.AllowInf = false;
            this.wallHeightNumeric.AutoSize = true;
            this.wallHeightNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wallHeightNumeric.ClearOnDisable = false;
            this.wallHeightNumeric.FloatValue = 0F;
            this.wallHeightNumeric.IntValue = 0;
            this.wallHeightNumeric.IsInteger = false;
            this.wallHeightNumeric.Location = new System.Drawing.Point(101, 125);
            this.wallHeightNumeric.MaxCoerce = false;
            this.wallHeightNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.wallHeightNumeric.MaxValue = 1.7976931348623157E+308D;
            this.wallHeightNumeric.MinCoerce = false;
            this.wallHeightNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.wallHeightNumeric.MinValue = 0D;
            this.wallHeightNumeric.Name = "wallHeightNumeric";
            this.wallHeightNumeric.Size = new System.Drawing.Size(100, 20);
            this.wallHeightNumeric.TabIndex = 16;
            this.wallHeightNumeric.TextFormat = "K4";
            this.wallHeightNumeric.ToolTip = "";
            this.wallHeightNumeric.Units = "";
            this.wallHeightNumeric.Value = 0D;
            // 
            // wallDistanceNumeric
            // 
            this.wallDistanceNumeric.AllowInf = false;
            this.wallDistanceNumeric.AutoSize = true;
            this.wallDistanceNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wallDistanceNumeric.ClearOnDisable = false;
            this.wallDistanceNumeric.FloatValue = 0F;
            this.wallDistanceNumeric.IntValue = 0;
            this.wallDistanceNumeric.IsInteger = false;
            this.wallDistanceNumeric.Location = new System.Drawing.Point(101, 99);
            this.wallDistanceNumeric.MaxCoerce = false;
            this.wallDistanceNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.wallDistanceNumeric.MaxValue = 1.7976931348623157E+308D;
            this.wallDistanceNumeric.MinCoerce = false;
            this.wallDistanceNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.wallDistanceNumeric.MinValue = 0D;
            this.wallDistanceNumeric.Name = "wallDistanceNumeric";
            this.wallDistanceNumeric.Size = new System.Drawing.Size(100, 20);
            this.wallDistanceNumeric.TabIndex = 14;
            this.wallDistanceNumeric.TextFormat = "K4";
            this.wallDistanceNumeric.ToolTip = "";
            this.wallDistanceNumeric.Units = "";
            this.wallDistanceNumeric.Value = 0D;
            // 
            // barSpacingNumeric
            // 
            this.barSpacingNumeric.AllowInf = false;
            this.barSpacingNumeric.AutoSize = true;
            this.barSpacingNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.barSpacingNumeric.ClearOnDisable = false;
            this.barSpacingNumeric.FloatValue = 0F;
            this.barSpacingNumeric.IntValue = 0;
            this.barSpacingNumeric.IsInteger = false;
            this.barSpacingNumeric.Location = new System.Drawing.Point(101, 73);
            this.barSpacingNumeric.MaxCoerce = false;
            this.barSpacingNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.barSpacingNumeric.MaxValue = 1.7976931348623157E+308D;
            this.barSpacingNumeric.MinCoerce = false;
            this.barSpacingNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.barSpacingNumeric.MinValue = 0D;
            this.barSpacingNumeric.Name = "barSpacingNumeric";
            this.barSpacingNumeric.Size = new System.Drawing.Size(100, 20);
            this.barSpacingNumeric.TabIndex = 12;
            this.barSpacingNumeric.TextFormat = "K4";
            this.barSpacingNumeric.ToolTip = "";
            this.barSpacingNumeric.Units = "";
            this.barSpacingNumeric.Value = 0D;
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
            this.barWidthNumeric.Location = new System.Drawing.Point(101, 47);
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
            // dotVelocityNumeric
            // 
            this.dotVelocityNumeric.AllowInf = false;
            this.dotVelocityNumeric.AutoSize = true;
            this.dotVelocityNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dotVelocityNumeric.ClearOnDisable = false;
            this.dotVelocityNumeric.FloatValue = 0F;
            this.dotVelocityNumeric.IntValue = 0;
            this.dotVelocityNumeric.IsInteger = false;
            this.dotVelocityNumeric.Location = new System.Drawing.Point(384, 427);
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
            // dotDensityNumeric
            // 
            this.dotDensityNumeric.AllowInf = false;
            this.dotDensityNumeric.AutoSize = true;
            this.dotDensityNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dotDensityNumeric.ClearOnDisable = false;
            this.dotDensityNumeric.FloatValue = 0F;
            this.dotDensityNumeric.IntValue = 0;
            this.dotDensityNumeric.IsInteger = false;
            this.dotDensityNumeric.Location = new System.Drawing.Point(384, 401);
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
            // dotSizeNumeric
            // 
            this.dotSizeNumeric.AllowInf = false;
            this.dotSizeNumeric.AutoSize = true;
            this.dotSizeNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dotSizeNumeric.ClearOnDisable = false;
            this.dotSizeNumeric.FloatValue = 0F;
            this.dotSizeNumeric.IntValue = 0;
            this.dotSizeNumeric.IsInteger = false;
            this.dotSizeNumeric.Location = new System.Drawing.Point(384, 375);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Wall offset (m)";
            // 
            // wallOffsetNumeric
            // 
            this.wallOffsetNumeric.AllowInf = false;
            this.wallOffsetNumeric.AutoSize = true;
            this.wallOffsetNumeric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wallOffsetNumeric.ClearOnDisable = false;
            this.wallOffsetNumeric.FloatValue = 0F;
            this.wallOffsetNumeric.IntValue = 0;
            this.wallOffsetNumeric.IsInteger = false;
            this.wallOffsetNumeric.Location = new System.Drawing.Point(101, 151);
            this.wallOffsetNumeric.MaxCoerce = false;
            this.wallOffsetNumeric.MaximumSize = new System.Drawing.Size(20000, 20);
            this.wallOffsetNumeric.MaxValue = 1.7976931348623157E+308D;
            this.wallOffsetNumeric.MinCoerce = false;
            this.wallOffsetNumeric.MinimumSize = new System.Drawing.Size(10, 20);
            this.wallOffsetNumeric.MinValue = 0D;
            this.wallOffsetNumeric.Name = "wallOffsetNumeric";
            this.wallOffsetNumeric.Size = new System.Drawing.Size(100, 20);
            this.wallOffsetNumeric.TabIndex = 18;
            this.wallOffsetNumeric.TextFormat = "K4";
            this.wallOffsetNumeric.ToolTip = "";
            this.wallOffsetNumeric.Units = "";
            this.wallOffsetNumeric.Value = 0D;
            // 
            // ScenePropertiesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 522);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.wallOffsetNumeric);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.wallHeightNumeric);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.wallDistanceNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.barSpacingNumeric);
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
            this.Name = "ScenePropertiesDialog";
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
        private KLib.Controls.KNumericBox barSpacingNumeric;
        private System.Windows.Forms.Label label7;
        private KLib.Controls.KNumericBox barWidthNumeric;
        private System.Windows.Forms.Label label8;
        private KLib.Controls.KNumericBox wallHeightNumeric;
        private System.Windows.Forms.Label label9;
        private KLib.Controls.KNumericBox wallDistanceNumeric;
        private System.Windows.Forms.Label label10;
        private KLib.Controls.KNumericBox wallOffsetNumeric;
    }
}