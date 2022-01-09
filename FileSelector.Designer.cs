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
            this.SuspendLayout();
            // 
            // SelectCountButton
            // 
            this.SelectCountButton.Location = new System.Drawing.Point(12, 12);
            this.SelectCountButton.Name = "SelectCountButton";
            this.SelectCountButton.Size = new System.Drawing.Size(83, 41);
            this.SelectCountButton.TabIndex = 0;
            this.SelectCountButton.Text = "Select Count File";
            this.SelectCountButton.UseVisualStyleBackColor = true;
            this.SelectCountButton.Click += new System.EventHandler(this.SelectCountButton_Click);
            // 
            // SelectStockFile
            // 
            this.SelectStockFile.Location = new System.Drawing.Point(101, 12);
            this.SelectStockFile.Name = "SelectStockFile";
            this.SelectStockFile.Size = new System.Drawing.Size(93, 41);
            this.SelectStockFile.TabIndex = 1;
            this.SelectStockFile.Text = "Select Stock File";
            this.SelectStockFile.UseVisualStyleBackColor = true;
            this.SelectStockFile.Click += new System.EventHandler(this.SelectStockFile_Click);
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectStockFile);
            this.Controls.Add(this.SelectCountButton);
            this.Name = "FileSelector";
            this.Text = "FileSelector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectCountButton;
        private System.Windows.Forms.Button SelectStockFile;
    }
}