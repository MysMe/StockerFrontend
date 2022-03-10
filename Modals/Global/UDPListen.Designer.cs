namespace StockerFrontend.Modals.Global
{
    partial class UDPListen
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.addressList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 27);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(611, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your device is now waiting for connections on UDP port: ";
            // 
            // addressList
            // 
            this.addressList.Location = new System.Drawing.Point(12, 71);
            this.addressList.Multiline = true;
            this.addressList.Name = "addressList";
            this.addressList.ReadOnly = true;
            this.addressList.Size = new System.Drawing.Size(611, 197);
            this.addressList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "So far, the following devices have been detected:";
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(285, 274);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(80, 25);
            this.Stop.TabIndex = 4;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // UDPListen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 311);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addressList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Name = "UDPListen";
            this.Text = "UDPListen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addressList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Stop;
    }
}