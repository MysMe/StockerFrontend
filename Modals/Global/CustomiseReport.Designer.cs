namespace StockerFrontend.Modals.Global
{
    partial class CustomiseReport
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.itemsUnreviewed = new System.Windows.Forms.CheckBox();
            this.itemsConfirmed = new System.Windows.Forms.CheckBox();
            this.itemsRecounted = new System.Windows.Forms.CheckBox();
            this.itemsCritical = new System.Windows.Forms.CheckBox();
            this.orderOriginal = new System.Windows.Forms.RadioButton();
            this.orderCategorised = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orderLabel = new System.Windows.Forms.Label();
            this.itemsTransfers = new System.Windows.Forms.CheckBox();
            this.showButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(12, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(286, 15);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Please select which elements to include in the report:";
            // 
            // itemsUnreviewed
            // 
            this.itemsUnreviewed.AutoSize = true;
            this.itemsUnreviewed.Checked = true;
            this.itemsUnreviewed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemsUnreviewed.Location = new System.Drawing.Point(18, 133);
            this.itemsUnreviewed.Name = "itemsUnreviewed";
            this.itemsUnreviewed.Size = new System.Drawing.Size(120, 19);
            this.itemsUnreviewed.TabIndex = 1;
            this.itemsUnreviewed.Text = "Unreviewed Items";
            this.itemsUnreviewed.UseVisualStyleBackColor = true;
            // 
            // itemsConfirmed
            // 
            this.itemsConfirmed.AutoSize = true;
            this.itemsConfirmed.Checked = true;
            this.itemsConfirmed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemsConfirmed.Location = new System.Drawing.Point(154, 133);
            this.itemsConfirmed.Name = "itemsConfirmed";
            this.itemsConfirmed.Size = new System.Drawing.Size(115, 19);
            this.itemsConfirmed.TabIndex = 2;
            this.itemsConfirmed.Text = "Confirmed Items";
            this.itemsConfirmed.UseVisualStyleBackColor = true;
            // 
            // itemsRecounted
            // 
            this.itemsRecounted.AutoSize = true;
            this.itemsRecounted.Checked = true;
            this.itemsRecounted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemsRecounted.Location = new System.Drawing.Point(18, 158);
            this.itemsRecounted.Name = "itemsRecounted";
            this.itemsRecounted.Size = new System.Drawing.Size(115, 19);
            this.itemsRecounted.TabIndex = 3;
            this.itemsRecounted.Text = "Recounted Items";
            this.itemsRecounted.UseVisualStyleBackColor = true;
            // 
            // itemsCritical
            // 
            this.itemsCritical.AutoSize = true;
            this.itemsCritical.Checked = true;
            this.itemsCritical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemsCritical.Location = new System.Drawing.Point(154, 158);
            this.itemsCritical.Name = "itemsCritical";
            this.itemsCritical.Size = new System.Drawing.Size(95, 19);
            this.itemsCritical.TabIndex = 4;
            this.itemsCritical.Text = "Critical Items";
            this.itemsCritical.UseVisualStyleBackColor = true;
            // 
            // orderOriginal
            // 
            this.orderOriginal.AutoSize = true;
            this.orderOriginal.Checked = true;
            this.orderOriginal.Location = new System.Drawing.Point(142, 22);
            this.orderOriginal.Name = "orderOriginal";
            this.orderOriginal.Size = new System.Drawing.Size(100, 19);
            this.orderOriginal.TabIndex = 5;
            this.orderOriginal.TabStop = true;
            this.orderOriginal.Text = "Original Order";
            this.orderOriginal.UseVisualStyleBackColor = true;
            this.orderOriginal.CheckedChanged += new System.EventHandler(this.orderOriginal_CheckedChanged);
            // 
            // orderCategorised
            // 
            this.orderCategorised.AutoSize = true;
            this.orderCategorised.Location = new System.Drawing.Point(142, 47);
            this.orderCategorised.Name = "orderCategorised";
            this.orderCategorised.Size = new System.Drawing.Size(88, 19);
            this.orderCategorised.TabIndex = 6;
            this.orderCategorised.Text = "Categorised";
            this.orderCategorised.UseVisualStyleBackColor = true;
            this.orderCategorised.CheckedChanged += new System.EventHandler(this.orderCategorised_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.orderLabel);
            this.groupBox1.Controls.Add(this.orderOriginal);
            this.groupBox1.Controls.Add(this.orderCategorised);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // orderLabel
            // 
            this.orderLabel.AutoSize = true;
            this.orderLabel.Location = new System.Drawing.Point(6, 24);
            this.orderLabel.Name = "orderLabel";
            this.orderLabel.Size = new System.Drawing.Size(105, 30);
            this.orderLabel.TabIndex = 7;
            this.orderLabel.Text = "What order should\r\nthe report be in:";
            // 
            // itemsTransfers
            // 
            this.itemsTransfers.AutoSize = true;
            this.itemsTransfers.Checked = true;
            this.itemsTransfers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemsTransfers.Location = new System.Drawing.Point(18, 183);
            this.itemsTransfers.Name = "itemsTransfers";
            this.itemsTransfers.Size = new System.Drawing.Size(192, 19);
            this.itemsTransfers.TabIndex = 8;
            this.itemsTransfers.Text = "Include Transfers And Deliveries";
            this.itemsTransfers.UseVisualStyleBackColor = true;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(223, 219);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 9;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(135, 219);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CustomiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(303, 249);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.itemsTransfers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.itemsCritical);
            this.Controls.Add(this.itemsRecounted);
            this.Controls.Add(this.itemsConfirmed);
            this.Controls.Add(this.itemsUnreviewed);
            this.Controls.Add(this.headerLabel);
            this.Name = "CustomiseReport";
            this.Text = "Customise Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.CheckBox itemsUnreviewed;
        private System.Windows.Forms.CheckBox itemsConfirmed;
        private System.Windows.Forms.CheckBox itemsRecounted;
        private System.Windows.Forms.CheckBox itemsCritical;
        private System.Windows.Forms.RadioButton orderOriginal;
        private System.Windows.Forms.RadioButton orderCategorised;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label orderLabel;
        private System.Windows.Forms.CheckBox itemsTransfers;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button cancelButton;
    }
}