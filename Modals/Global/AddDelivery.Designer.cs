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
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dateLabel = new System.Windows.Forms.Label();
            this.datePerformed = new System.Windows.Forms.DateTimePicker();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.supplierInput = new System.Windows.Forms.TextBox();
            this.orderContents = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderedProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderedProductSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.invoiceLabel = new System.Windows.Forms.Label();
            this.invoiceInput = new System.Windows.Forms.TextBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchInput = new System.Windows.Forms.TextBox();
            this.searchResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderContents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Location = new System.Drawing.Point(921, 362);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Done";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(840, 362);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 100, 3, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dateLabel);
            this.splitContainer1.Panel1.Controls.Add(this.datePerformed);
            this.splitContainer1.Panel1.Controls.Add(this.supplierLabel);
            this.splitContainer1.Panel1.Controls.Add(this.supplierInput);
            this.splitContainer1.Panel1.Controls.Add(this.orderContents);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.invoiceLabel);
            this.splitContainer1.Panel2.Controls.Add(this.invoiceInput);
            this.splitContainer1.Panel2.Controls.Add(this.searchLabel);
            this.splitContainer1.Panel2.Controls.Add(this.searchInput);
            this.splitContainer1.Panel2.Controls.Add(this.searchResults);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 397);
            this.splitContainer1.SplitterDistance = 504;
            this.splitContainer1.TabIndex = 15;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 44);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(93, 15);
            this.dateLabel.TabIndex = 19;
            this.dateLabel.Text = "Date Performed:";
            // 
            // datePerformed
            // 
            this.datePerformed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePerformed.Location = new System.Drawing.Point(111, 41);
            this.datePerformed.Name = "datePerformed";
            this.datePerformed.Size = new System.Drawing.Size(390, 23);
            this.datePerformed.TabIndex = 18;
            this.datePerformed.Value = new System.DateTime(2022, 2, 21, 21, 44, 53, 0);
            // 
            // supplierLabel
            // 
            this.supplierLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierLabel.AutoSize = true;
            this.supplierLabel.Location = new System.Drawing.Point(12, 15);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(53, 15);
            this.supplierLabel.TabIndex = 16;
            this.supplierLabel.Text = "Supplier:";
            // 
            // supplierInput
            // 
            this.supplierInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierInput.Location = new System.Drawing.Point(83, 12);
            this.supplierInput.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.supplierInput.Name = "supplierInput";
            this.supplierInput.Size = new System.Drawing.Size(418, 23);
            this.supplierInput.TabIndex = 17;
            // 
            // orderContents
            // 
            this.orderContents.AllowUserToAddRows = false;
            this.orderContents.AllowUserToDeleteRows = false;
            this.orderContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderContents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.OrderedProductName,
            this.OrderedProductSize,
            this.Delivered,
            this.Remove});
            this.orderContents.Location = new System.Drawing.Point(12, 70);
            this.orderContents.Name = "orderContents";
            this.orderContents.RowHeadersVisible = false;
            this.orderContents.RowTemplate.Height = 25;
            this.orderContents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.orderContents.Size = new System.Drawing.Size(489, 286);
            this.orderContents.TabIndex = 16;
            this.orderContents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderContents_CellContentClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // OrderedProductName
            // 
            this.OrderedProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderedProductName.HeaderText = "Name";
            this.OrderedProductName.Name = "OrderedProductName";
            this.OrderedProductName.ReadOnly = true;
            // 
            // OrderedProductSize
            // 
            this.OrderedProductSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrderedProductSize.HeaderText = "Size";
            this.OrderedProductSize.Name = "OrderedProductSize";
            this.OrderedProductSize.ReadOnly = true;
            this.OrderedProductSize.Width = 52;
            // 
            // Delivered
            // 
            this.Delivered.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delivered.HeaderText = "Delivered";
            this.Delivered.Name = "Delivered";
            this.Delivered.Width = 81;
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Remove.HeaderText = "Remove";
            this.Remove.Name = "Remove";
            this.Remove.Text = ">>";
            this.Remove.Width = 56;
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceLabel.AutoSize = true;
            this.invoiceLabel.Location = new System.Drawing.Point(3, 15);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.Size = new System.Drawing.Size(67, 15);
            this.invoiceLabel.TabIndex = 19;
            this.invoiceLabel.Text = "Invoice No:";
            // 
            // invoiceInput
            // 
            this.invoiceInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceInput.Location = new System.Drawing.Point(76, 12);
            this.invoiceInput.Name = "invoiceInput";
            this.invoiceInput.Size = new System.Drawing.Size(412, 23);
            this.invoiceInput.TabIndex = 18;
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(3, 44);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(45, 15);
            this.searchLabel.TabIndex = 17;
            this.searchLabel.Text = "Search:";
            // 
            // searchInput
            // 
            this.searchInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchInput.Location = new System.Drawing.Point(54, 41);
            this.searchInput.Name = "searchInput";
            this.searchInput.Size = new System.Drawing.Size(434, 23);
            this.searchInput.TabIndex = 16;
            this.searchInput.TextChanged += new System.EventHandler(this.searchInput_TextChanged);
            // 
            // searchResults
            // 
            this.searchResults.AllowUserToAddRows = false;
            this.searchResults.AllowUserToDeleteRows = false;
            this.searchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewButtonColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.searchResults.Location = new System.Drawing.Point(3, 70);
            this.searchResults.Name = "searchResults";
            this.searchResults.RowHeadersVisible = false;
            this.searchResults.RowTemplate.Height = 25;
            this.searchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.searchResults.Size = new System.Drawing.Size(485, 286);
            this.searchResults.TabIndex = 15;
            this.searchResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchResults_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewButtonColumn1.HeaderText = "Move";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "<<";
            this.dataGridViewButtonColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Size";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 52;
            // 
            // AddDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 397);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AddDelivery";
            this.Text = "Add Delivery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderContents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView orderContents;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderedProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderedProductSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delivered;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.DataGridView searchResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label supplierLabel;
        private System.Windows.Forms.TextBox supplierInput;
        private System.Windows.Forms.Label invoiceLabel;
        private System.Windows.Forms.TextBox invoiceInput;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchInput;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker datePerformed;
    }
}