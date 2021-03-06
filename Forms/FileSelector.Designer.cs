namespace StockerFrontend
{
    partial class FileSelector
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
            this.SelectCountButton = new System.Windows.Forms.Button();
            this.SelectStockFile = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.ReceiveCountButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectCountButton
            // 
            this.SelectCountButton.Location = new System.Drawing.Point(12, 27);
            this.SelectCountButton.Name = "SelectCountButton";
            this.SelectCountButton.Size = new System.Drawing.Size(100, 50);
            this.SelectCountButton.TabIndex = 0;
            this.SelectCountButton.Text = "Select Count File";
            this.SelectCountButton.UseVisualStyleBackColor = true;
            this.SelectCountButton.Click += new System.EventHandler(this.SelectCountButton_Click);
            // 
            // SelectStockFile
            // 
            this.SelectStockFile.Enabled = false;
            this.SelectStockFile.Location = new System.Drawing.Point(224, 27);
            this.SelectStockFile.Name = "SelectStockFile";
            this.SelectStockFile.Size = new System.Drawing.Size(100, 50);
            this.SelectStockFile.TabIndex = 1;
            this.SelectStockFile.Text = "Select Stock File";
            this.SelectStockFile.UseVisualStyleBackColor = true;
            this.SelectStockFile.Click += new System.EventHandler(this.SelectStockFile_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(337, 15);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "To begin, please select a stock count file and a stock report file.";
            // 
            // ReceiveCountButton
            // 
            this.ReceiveCountButton.Location = new System.Drawing.Point(118, 27);
            this.ReceiveCountButton.Name = "ReceiveCountButton";
            this.ReceiveCountButton.Size = new System.Drawing.Size(100, 50);
            this.ReceiveCountButton.TabIndex = 3;
            this.ReceiveCountButton.Text = "Receive Count File";
            this.ReceiveCountButton.UseVisualStyleBackColor = true;
            this.ReceiveCountButton.Click += new System.EventHandler(this.ReceiveCountButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(330, 27);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(100, 50);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load From Existing";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(512, 83);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.ReceiveCountButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.SelectStockFile);
            this.Controls.Add(this.SelectCountButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Select Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectCountButton;
        private System.Windows.Forms.Button SelectStockFile;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button ReceiveCountButton;
        private System.Windows.Forms.Button loadButton;
    }
}