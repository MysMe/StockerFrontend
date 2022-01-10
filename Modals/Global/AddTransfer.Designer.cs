namespace StockerFrontend.Modals.Global
{
    partial class AddTransfer
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.deliveredProductList = new System.Windows.Forms.ListBox();
            this.quantityInput = new System.Windows.Forms.TextBox();
            this.productInput = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.productLabel = new System.Windows.Forms.Label();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.supplierInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(276, 261);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(357, 261);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 16;
            this.confirmButton.Text = "Done";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // deliveredProductList
            // 
            this.deliveredProductList.FormattingEnabled = true;
            this.deliveredProductList.ItemHeight = 15;
            this.deliveredProductList.Location = new System.Drawing.Point(176, 12);
            this.deliveredProductList.Name = "deliveredProductList";
            this.deliveredProductList.Size = new System.Drawing.Size(120, 94);
            this.deliveredProductList.TabIndex = 15;
            // 
            // quantityInput
            // 
            this.quantityInput.Location = new System.Drawing.Point(70, 70);
            this.quantityInput.Name = "quantityInput";
            this.quantityInput.Size = new System.Drawing.Size(100, 23);
            this.quantityInput.TabIndex = 14;
            // 
            // productInput
            // 
            this.productInput.Location = new System.Drawing.Point(70, 41);
            this.productInput.Name = "productInput";
            this.productInput.Size = new System.Drawing.Size(100, 23);
            this.productInput.TabIndex = 13;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(8, 73);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(56, 15);
            this.quantityLabel.TabIndex = 12;
            this.quantityLabel.Text = "Quantity:";
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(12, 44);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(52, 15);
            this.productLabel.TabIndex = 11;
            this.productLabel.Text = "Product:";
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Location = new System.Drawing.Point(11, 15);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(53, 15);
            this.supplierLabel.TabIndex = 10;
            this.supplierLabel.Text = "Supplier:";
            // 
            // supplierInput
            // 
            this.supplierInput.Location = new System.Drawing.Point(70, 12);
            this.supplierInput.Name = "supplierInput";
            this.supplierInput.Size = new System.Drawing.Size(100, 23);
            this.supplierInput.TabIndex = 9;
            // 
            // AddTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 296);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.deliveredProductList);
            this.Controls.Add(this.quantityInput);
            this.Controls.Add(this.productInput);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.supplierLabel);
            this.Controls.Add(this.supplierInput);
            this.Name = "AddTransfer";
            this.Text = "AddTransfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.ListBox deliveredProductList;
        private System.Windows.Forms.TextBox quantityInput;
        private System.Windows.Forms.TextBox productInput;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label supplierLabel;
        private System.Windows.Forms.TextBox supplierInput;
    }
}