namespace StockerFrontend.Modals.Global
{
    partial class DisplayReport
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
            this.doneButton = new System.Windows.Forms.Button();
            this.reportDisplay = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.Location = new System.Drawing.Point(713, 415);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // reportDisplay
            // 
            this.reportDisplay.AllowUserToAddRows = false;
            this.reportDisplay.AllowUserToDeleteRows = false;
            this.reportDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDisplay.ColumnHeadersVisible = false;
            this.reportDisplay.Location = new System.Drawing.Point(12, 12);
            this.reportDisplay.Name = "reportDisplay";
            this.reportDisplay.ReadOnly = true;
            this.reportDisplay.RowHeadersVisible = false;
            this.reportDisplay.RowTemplate.Height = 25;
            this.reportDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportDisplay.ShowEditingIcon = false;
            this.reportDisplay.ShowRowErrors = false;
            this.reportDisplay.Size = new System.Drawing.Size(776, 397);
            this.reportDisplay.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(632, 415);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // DisplayReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.reportDisplay);
            this.Controls.Add(this.doneButton);
            this.Name = "DisplayReport";
            this.Text = "DisplayReport";
            ((System.ComponentModel.ISupportInitialize)(this.reportDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.DataGridView reportDisplay;
        private System.Windows.Forms.Button saveButton;
    }
}