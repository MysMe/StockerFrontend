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
            this.parseOutputBox = new System.Windows.Forms.TextBox();
            this.resolveTranslationButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectCountButton
            // 
            this.SelectCountButton.Location = new System.Drawing.Point(12, 12);
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
            this.SelectStockFile.Location = new System.Drawing.Point(12, 68);
            this.SelectStockFile.Name = "SelectStockFile";
            this.SelectStockFile.Size = new System.Drawing.Size(100, 50);
            this.SelectStockFile.TabIndex = 1;
            this.SelectStockFile.Text = "Select Stock File";
            this.SelectStockFile.UseVisualStyleBackColor = true;
            this.SelectStockFile.Click += new System.EventHandler(this.SelectStockFile_Click);
            // 
            // parseOutputBox
            // 
            this.parseOutputBox.Location = new System.Drawing.Point(118, 12);
            this.parseOutputBox.Multiline = true;
            this.parseOutputBox.Name = "parseOutputBox";
            this.parseOutputBox.ReadOnly = true;
            this.parseOutputBox.Size = new System.Drawing.Size(670, 218);
            this.parseOutputBox.TabIndex = 2;
            // 
            // resolveTranslationButton
            // 
            this.resolveTranslationButton.Enabled = false;
            this.resolveTranslationButton.Location = new System.Drawing.Point(12, 124);
            this.resolveTranslationButton.Name = "resolveTranslationButton";
            this.resolveTranslationButton.Size = new System.Drawing.Size(100, 50);
            this.resolveTranslationButton.TabIndex = 3;
            this.resolveTranslationButton.Text = "Resolve Translation";
            this.resolveTranslationButton.UseVisualStyleBackColor = true;
            // 
            // doneButton
            // 
            this.doneButton.Enabled = false;
            this.doneButton.Location = new System.Drawing.Point(12, 180);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(100, 50);
            this.doneButton.TabIndex = 4;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            // 
            // FileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.resolveTranslationButton);
            this.Controls.Add(this.parseOutputBox);
            this.Controls.Add(this.SelectStockFile);
            this.Controls.Add(this.SelectCountButton);
            this.Name = "FileSelector";
            this.Text = "FileSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectCountButton;
        private System.Windows.Forms.Button SelectStockFile;
        private System.Windows.Forms.TextBox parseOutputBox;
        private System.Windows.Forms.Button resolveTranslationButton;
        private System.Windows.Forms.Button doneButton;
    }
}