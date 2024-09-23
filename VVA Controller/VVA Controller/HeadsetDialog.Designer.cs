namespace VVA_Controller
{
    partial class HeadsetDialog
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
            this.closeButton = new System.Windows.Forms.Button();
            this.calibrateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Image = global::VVA_Controller.Properties.Resources.delete;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(104, 328);
            this.closeButton.Name = "closeButton";
            this.closeButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.closeButton.Size = new System.Drawing.Size(118, 38);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // calibrateButton
            // 
            this.calibrateButton.Image = global::VVA_Controller.Properties.Resources.tape_measure2;
            this.calibrateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.calibrateButton.Location = new System.Drawing.Point(104, 223);
            this.calibrateButton.Name = "calibrateButton";
            this.calibrateButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.calibrateButton.Size = new System.Drawing.Size(118, 38);
            this.calibrateButton.TabIndex = 10;
            this.calibrateButton.Text = "Calibrate";
            this.calibrateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.calibrateButton.UseVisualStyleBackColor = true;
            // 
            // HeadsetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 396);
            this.Controls.Add(this.calibrateButton);
            this.Controls.Add(this.closeButton);
            this.Name = "HeadsetDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Headset properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button calibrateButton;
    }
}