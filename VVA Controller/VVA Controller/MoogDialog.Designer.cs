namespace VVA_Controller
{
    partial class MoogDialog
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
            this.simulateButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Image = global::VVA_Controller.Properties.Resources.delete;
            this.closeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeButton.Location = new System.Drawing.Point(87, 321);
            this.closeButton.Name = "closeButton";
            this.closeButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.closeButton.Size = new System.Drawing.Size(100, 38);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Close";
            this.closeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // simulateButton
            // 
            this.simulateButton.Image = global::VVA_Controller.Properties.Resources.media_play_green;
            this.simulateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.simulateButton.Location = new System.Drawing.Point(87, 277);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.simulateButton.Size = new System.Drawing.Size(100, 38);
            this.simulateButton.TabIndex = 11;
            this.simulateButton.Text = "Simulate";
            this.simulateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.simulateButton.UseVisualStyleBackColor = true;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Image = global::VVA_Controller.Properties.Resources.media_stop_red;
            this.stopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopButton.Location = new System.Drawing.Point(87, 277);
            this.stopButton.Name = "stopButton";
            this.stopButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.stopButton.Size = new System.Drawing.Size(100, 38);
            this.stopButton.TabIndex = 12;
            this.stopButton.Text = "Stop";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // MoogDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(278, 387);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.stopButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MoogDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Moog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.Button stopButton;
    }
}