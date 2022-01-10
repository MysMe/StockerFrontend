namespace StockerFrontend.Modals.Global
{
    partial class AddDelivery
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
            this.supplierInput = new System.Windows.Forms.TextBox();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.productLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.productInput = new System.Windows.Forms.TextBox();
            this.quantityInput = new System.Windows.Forms.TextBox();
            this.deliveredProductList = new System.Windows.Forms.ListBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // supplierInput
            // 
            this.supplierInput.Location = new System.Drawing.Point(71, 6);
            this.supplierInput.Name = "supplierInput";
            this.supplierInput.Size = new System.Drawing.Size(100, 23);
            this.supplierInput.TabIndex = 0;
            // 
            // supplierLabel
            // 
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Location = new System.Drawing.Point(12, 9);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(53, 15);
            this.supplierLabel.TabIndex = 1;
            this.supplierLabel.Text = "Supplier:";
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(13, 38);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(52, 15);
            this.productLabel.TabIndex = 2;
            this.productLabel.Text = "Product:";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(9, 67);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(56, 15);
            this.quantityLabel.TabIndex = 3;
            this.quantityLabel.Text = "Quantity:";
            // 
            // productInput
            // 
            this.productInput.Location = new System.Drawing.Point(71, 35);
            this.productInput.Name = "productInput";
            this.productInput.Size = new System.Drawing.Size(100, 23);
            this.productInput.TabIndex = 4;
            // 
            // quantityInput
            // 
            this.quantityInput.Location = new System.Drawing.Point(71, 64);
            this.quantityInput.Name = "quantityInput";
            this.quantityInput.Size = new System.Drawing.Size(100, 23);
            this.quantityInput.TabIndex = 5;
            // 
            // deliveredProductList
            // 
            this.deliveredProductList.FormattingEnabled = true;
            this.deliveredProductList.ItemHeight = 15;
            this.deliveredProductList.Location = new System.Drawing.Point(177, 6);
            this.deliveredProductList.Name = "deliveredProductList";
            this.deliveredProductList.Size = new System.Drawing.Size(120, 94);
            this.deliveredProductList.TabIndex = 6;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(349, 260);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Done";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(268, 260);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AddDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 295);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.deliveredProductList);
            this.Controls.Add(this.quantityInput);
            this.Controls.Add(this.productInput);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.supplierLabel);
            this.Controls.Add(this.supplierInput);
            this.Name = "AddDelivery";
            this.Text = "AddDelivery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox supplierInput;
        private System.Windows.Forms.Label supplierLabel;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.TextBox productInput;
        private System.Windows.Forms.TextBox quantityInput;
        private System.Windows.Forms.ListBox deliveredProductList;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}