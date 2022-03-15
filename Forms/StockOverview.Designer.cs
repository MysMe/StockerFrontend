namespace StockerFrontend.Forms
{
    partial class StockOverview
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
            this.CountTable = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Counted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowHide = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Confirm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Recount = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Critical = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Notes = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRecountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unhideAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapShownHiddenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConfirmedConfirmedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRecountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCriticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllReviewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideOnReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllReviewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transfersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeliveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTransferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDeliveriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTransfersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoConfirmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ACL01ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ACL05ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ACL1ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCriticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ACG1ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ACG3ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.ACG5ToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmAllUnreviewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recountAllUnreviewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criticalAllUnreviewedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CountTable)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CountTable
            // 
            this.CountTable.AllowUserToAddRows = false;
            this.CountTable.AllowUserToDeleteRows = false;
            this.CountTable.AllowUserToOrderColumns = true;
            this.CountTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CountTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CountTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.StockName,
            this.StockSize,
            this.Expected,
            this.Counted,
            this.Variance,
            this.ShowHide,
            this.Confirm,
            this.Recount,
            this.Critical,
            this.Notes});
            this.CountTable.Location = new System.Drawing.Point(9, 57);
            this.CountTable.MultiSelect = false;
            this.CountTable.Name = "CountTable";
            this.CountTable.ReadOnly = true;
            this.CountTable.RowHeadersVisible = false;
            this.CountTable.RowTemplate.Height = 25;
            this.CountTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.CountTable.Size = new System.Drawing.Size(1225, 381);
            this.CountTable.TabIndex = 8;
            this.CountTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CountTable_CellContentClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // StockName
            // 
            this.StockName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockName.HeaderText = "Product Name";
            this.StockName.Name = "StockName";
            this.StockName.ReadOnly = true;
            // 
            // StockSize
            // 
            this.StockSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StockSize.HeaderText = "Size";
            this.StockSize.Name = "StockSize";
            this.StockSize.ReadOnly = true;
            this.StockSize.Width = 52;
            // 
            // Expected
            // 
            this.Expected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Expected.HeaderText = "Expected";
            this.Expected.Name = "Expected";
            this.Expected.ReadOnly = true;
            this.Expected.Width = 80;
            // 
            // Counted
            // 
            this.Counted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Counted.HeaderText = "Counted";
            this.Counted.Name = "Counted";
            this.Counted.ReadOnly = true;
            this.Counted.Width = 78;
            // 
            // Variance
            // 
            this.Variance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Variance.HeaderText = "Variance";
            this.Variance.Name = "Variance";
            this.Variance.ReadOnly = true;
            this.Variance.Width = 76;
            // 
            // ShowHide
            // 
            this.ShowHide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ShowHide.HeaderText = "Hide";
            this.ShowHide.Name = "ShowHide";
            this.ShowHide.ReadOnly = true;
            this.ShowHide.Text = "H";
            this.ShowHide.Width = 38;
            // 
            // Confirm
            // 
            this.Confirm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Confirm.HeaderText = "Confirm";
            this.Confirm.Name = "Confirm";
            this.Confirm.ReadOnly = true;
            this.Confirm.Text = "Co";
            this.Confirm.Width = 57;
            // 
            // Recount
            // 
            this.Recount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Recount.HeaderText = "Recount";
            this.Recount.Name = "Recount";
            this.Recount.ReadOnly = true;
            this.Recount.Text = "R";
            this.Recount.Width = 57;
            // 
            // Critical
            // 
            this.Critical.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Critical.HeaderText = "Critical";
            this.Critical.Name = "Critical";
            this.Critical.ReadOnly = true;
            this.Critical.Text = "Cr";
            this.Critical.Width = 50;
            // 
            // Notes
            // 
            this.Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            this.Notes.Text = "N";
            this.Notes.Width = 44;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.visibilityToolStripMenuItem,
            this.transfersToolStripMenuItem,
            this.bulkActionsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1246, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.importRecountToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // importRecountToolStripMenuItem
            // 
            this.importRecountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromFileToolStripMenuItem,
            this.fromNetworkToolStripMenuItem});
            this.importRecountToolStripMenuItem.Name = "importRecountToolStripMenuItem";
            this.importRecountToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importRecountToolStripMenuItem.Text = "Import Recount";
            // 
            // fromFileToolStripMenuItem
            // 
            this.fromFileToolStripMenuItem.Name = "fromFileToolStripMenuItem";
            this.fromFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fromFileToolStripMenuItem.Text = "From File";
            this.fromFileToolStripMenuItem.Click += new System.EventHandler(this.fromFileToolStripMenuItem_Click);
            // 
            // fromNetworkToolStripMenuItem
            // 
            this.fromNetworkToolStripMenuItem.Name = "fromNetworkToolStripMenuItem";
            this.fromNetworkToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fromNetworkToolStripMenuItem.Text = "From Network";
            this.fromNetworkToolStripMenuItem.Click += new System.EventHandler(this.fromNetworkToolStripMenuItem_Click);
            // 
            // visibilityToolStripMenuItem
            // 
            this.visibilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unhideAllToolStripMenuItem,
            this.swapShownHiddenToolStripMenuItem,
            this.showConfirmedConfirmedToolStripMenuItem,
            this.showRecountToolStripMenuItem,
            this.showCriticalToolStripMenuItem,
            this.hideAllReviewedToolStripMenuItem,
            this.hideOnReviewToolStripMenuItem,
            this.clearAllReviewsToolStripMenuItem,
            this.resetSortingToolStripMenuItem});
            this.visibilityToolStripMenuItem.Name = "visibilityToolStripMenuItem";
            this.visibilityToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.visibilityToolStripMenuItem.Text = "Visibility";
            // 
            // unhideAllToolStripMenuItem
            // 
            this.unhideAllToolStripMenuItem.Name = "unhideAllToolStripMenuItem";
            this.unhideAllToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.unhideAllToolStripMenuItem.Text = "Unhide All";
            this.unhideAllToolStripMenuItem.Click += new System.EventHandler(this.unhideAllToolStripMenuItem_Click);
            // 
            // swapShownHiddenToolStripMenuItem
            // 
            this.swapShownHiddenToolStripMenuItem.CheckOnClick = true;
            this.swapShownHiddenToolStripMenuItem.Name = "swapShownHiddenToolStripMenuItem";
            this.swapShownHiddenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.swapShownHiddenToolStripMenuItem.Text = "Swap Shown/Hidden";
            this.swapShownHiddenToolStripMenuItem.ToolTipText = "If checked, the table will only display hidden entries. Otherwise, the table will" +
    " only\r\n display unhidden entries.";
            this.swapShownHiddenToolStripMenuItem.Click += new System.EventHandler(this.swapShownHiddenToolStripMenuItem_Click);
            // 
            // showConfirmedConfirmedToolStripMenuItem
            // 
            this.showConfirmedConfirmedToolStripMenuItem.Checked = true;
            this.showConfirmedConfirmedToolStripMenuItem.CheckOnClick = true;
            this.showConfirmedConfirmedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showConfirmedConfirmedToolStripMenuItem.Name = "showConfirmedConfirmedToolStripMenuItem";
            this.showConfirmedConfirmedToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showConfirmedConfirmedToolStripMenuItem.Text = "Show Confirmed";
            this.showConfirmedConfirmedToolStripMenuItem.Click += new System.EventHandler(this.showConfirmedToolStripMenuItem_Click);
            // 
            // showRecountToolStripMenuItem
            // 
            this.showRecountToolStripMenuItem.Checked = true;
            this.showRecountToolStripMenuItem.CheckOnClick = true;
            this.showRecountToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showRecountToolStripMenuItem.Name = "showRecountToolStripMenuItem";
            this.showRecountToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showRecountToolStripMenuItem.Text = "Show Recount";
            this.showRecountToolStripMenuItem.Click += new System.EventHandler(this.showRecountToolStripMenuItem_Click);
            // 
            // showCriticalToolStripMenuItem
            // 
            this.showCriticalToolStripMenuItem.Checked = true;
            this.showCriticalToolStripMenuItem.CheckOnClick = true;
            this.showCriticalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCriticalToolStripMenuItem.Name = "showCriticalToolStripMenuItem";
            this.showCriticalToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.showCriticalToolStripMenuItem.Text = "Show Critical";
            this.showCriticalToolStripMenuItem.Click += new System.EventHandler(this.showCriticalToolStripMenuItem_Click);
            // 
            // hideAllReviewedToolStripMenuItem
            // 
            this.hideAllReviewedToolStripMenuItem.Name = "hideAllReviewedToolStripMenuItem";
            this.hideAllReviewedToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.hideAllReviewedToolStripMenuItem.Text = "Hide All Reviewed";
            this.hideAllReviewedToolStripMenuItem.ToolTipText = "Hides all entries that have been marked as confirmed, recount or critical.";
            this.hideAllReviewedToolStripMenuItem.Click += new System.EventHandler(this.hideAllReviewedToolStripMenuItem_Click);
            // 
            // hideOnReviewToolStripMenuItem
            // 
            this.hideOnReviewToolStripMenuItem.Checked = true;
            this.hideOnReviewToolStripMenuItem.CheckOnClick = true;
            this.hideOnReviewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideOnReviewToolStripMenuItem.Name = "hideOnReviewToolStripMenuItem";
            this.hideOnReviewToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.hideOnReviewToolStripMenuItem.Text = "Hide On Review";
            this.hideOnReviewToolStripMenuItem.ToolTipText = "If enabled, setting a product state also automatically hides it.";
            this.hideOnReviewToolStripMenuItem.Click += new System.EventHandler(this.hideOnReviewToolStripMenuItem_Click);
            // 
            // clearAllReviewsToolStripMenuItem
            // 
            this.clearAllReviewsToolStripMenuItem.Name = "clearAllReviewsToolStripMenuItem";
            this.clearAllReviewsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.clearAllReviewsToolStripMenuItem.Text = "Clear All Reviews";
            this.clearAllReviewsToolStripMenuItem.Click += new System.EventHandler(this.clearAllReviewsToolStripMenuItem_Click);
            // 
            // resetSortingToolStripMenuItem
            // 
            this.resetSortingToolStripMenuItem.Name = "resetSortingToolStripMenuItem";
            this.resetSortingToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.resetSortingToolStripMenuItem.Text = "Reset Sorting";
            this.resetSortingToolStripMenuItem.Click += new System.EventHandler(this.resetSortingToolStripMenuItem_Click);
            // 
            // transfersToolStripMenuItem
            // 
            this.transfersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDeliveryToolStripMenuItem,
            this.addTransferToolStripMenuItem,
            this.manageDeliveriesToolStripMenuItem,
            this.manageTransfersToolStripMenuItem});
            this.transfersToolStripMenuItem.Name = "transfersToolStripMenuItem";
            this.transfersToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.transfersToolStripMenuItem.Text = "Transfers";
            // 
            // addDeliveryToolStripMenuItem
            // 
            this.addDeliveryToolStripMenuItem.Name = "addDeliveryToolStripMenuItem";
            this.addDeliveryToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addDeliveryToolStripMenuItem.Text = "Add Delivery";
            this.addDeliveryToolStripMenuItem.Click += new System.EventHandler(this.addDeliveryToolStripMenuItem_Click);
            // 
            // addTransferToolStripMenuItem
            // 
            this.addTransferToolStripMenuItem.Name = "addTransferToolStripMenuItem";
            this.addTransferToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addTransferToolStripMenuItem.Text = "Add Transfer";
            this.addTransferToolStripMenuItem.Click += new System.EventHandler(this.addTransferToolStripMenuItem_Click);
            // 
            // manageDeliveriesToolStripMenuItem
            // 
            this.manageDeliveriesToolStripMenuItem.Name = "manageDeliveriesToolStripMenuItem";
            this.manageDeliveriesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.manageDeliveriesToolStripMenuItem.Text = "Manage Deliveries";
            this.manageDeliveriesToolStripMenuItem.Click += new System.EventHandler(this.manageDeliveriesToolStripMenuItem_Click);
            // 
            // manageTransfersToolStripMenuItem
            // 
            this.manageTransfersToolStripMenuItem.Name = "manageTransfersToolStripMenuItem";
            this.manageTransfersToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.manageTransfersToolStripMenuItem.Text = "Manage Transfers";
            this.manageTransfersToolStripMenuItem.Click += new System.EventHandler(this.manageTransfersToolStripMenuItem_Click);
            // 
            // bulkActionsToolStripMenuItem
            // 
            this.bulkActionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoConfirmToolStripMenuItem,
            this.autoCriticalToolStripMenuItem,
            this.confirmAllUnreviewedToolStripMenuItem,
            this.recountAllUnreviewedToolStripMenuItem,
            this.criticalAllUnreviewedToolStripMenuItem});
            this.bulkActionsToolStripMenuItem.Name = "bulkActionsToolStripMenuItem";
            this.bulkActionsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.bulkActionsToolStripMenuItem.Text = "Bulk Actions";
            // 
            // autoConfirmToolStripMenuItem
            // 
            this.autoConfirmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ACL01ToolStripMenuItem2,
            this.ACL05ToolStripMenuItem3,
            this.ACL1ToolStripMenuItem4});
            this.autoConfirmToolStripMenuItem.Name = "autoConfirmToolStripMenuItem";
            this.autoConfirmToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.autoConfirmToolStripMenuItem.Text = "Auto Confirm";
            // 
            // ACL01ToolStripMenuItem2
            // 
            this.ACL01ToolStripMenuItem2.Name = "ACL01ToolStripMenuItem2";
            this.ACL01ToolStripMenuItem2.Size = new System.Drawing.Size(108, 22);
            this.ACL01ToolStripMenuItem2.Text = "<= 0.1";
            this.ACL01ToolStripMenuItem2.Click += new System.EventHandler(this.ACL01ToolStripMenuItem2_Click);
            // 
            // ACL05ToolStripMenuItem3
            // 
            this.ACL05ToolStripMenuItem3.Name = "ACL05ToolStripMenuItem3";
            this.ACL05ToolStripMenuItem3.Size = new System.Drawing.Size(108, 22);
            this.ACL05ToolStripMenuItem3.Text = "<= 0.5";
            this.ACL05ToolStripMenuItem3.Click += new System.EventHandler(this.ACL05ToolStripMenuItem3_Click);
            // 
            // ACL1ToolStripMenuItem4
            // 
            this.ACL1ToolStripMenuItem4.Name = "ACL1ToolStripMenuItem4";
            this.ACL1ToolStripMenuItem4.Size = new System.Drawing.Size(108, 22);
            this.ACL1ToolStripMenuItem4.Text = "<= 1";
            this.ACL1ToolStripMenuItem4.Click += new System.EventHandler(this.ACL1ToolStripMenuItem4_Click);
            // 
            // autoCriticalToolStripMenuItem
            // 
            this.autoCriticalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ACG1ToolStripMenuItem5,
            this.ACG3ToolStripMenuItem6,
            this.ACG5ToolStripMenuItem7});
            this.autoCriticalToolStripMenuItem.Name = "autoCriticalToolStripMenuItem";
            this.autoCriticalToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.autoCriticalToolStripMenuItem.Text = "Auto Critical";
            // 
            // ACG1ToolStripMenuItem5
            // 
            this.ACG1ToolStripMenuItem5.Name = "ACG1ToolStripMenuItem5";
            this.ACG1ToolStripMenuItem5.Size = new System.Drawing.Size(91, 22);
            this.ACG1ToolStripMenuItem5.Text = "> 1";
            this.ACG1ToolStripMenuItem5.Click += new System.EventHandler(this.ACG1ToolStripMenuItem5_Click);
            // 
            // ACG3ToolStripMenuItem6
            // 
            this.ACG3ToolStripMenuItem6.Name = "ACG3ToolStripMenuItem6";
            this.ACG3ToolStripMenuItem6.Size = new System.Drawing.Size(91, 22);
            this.ACG3ToolStripMenuItem6.Text = "> 3";
            this.ACG3ToolStripMenuItem6.Click += new System.EventHandler(this.ACG3ToolStripMenuItem6_Click);
            // 
            // ACG5ToolStripMenuItem7
            // 
            this.ACG5ToolStripMenuItem7.Name = "ACG5ToolStripMenuItem7";
            this.ACG5ToolStripMenuItem7.Size = new System.Drawing.Size(91, 22);
            this.ACG5ToolStripMenuItem7.Text = "> 5";
            this.ACG5ToolStripMenuItem7.Click += new System.EventHandler(this.ACG5ToolStripMenuItem7_Click);
            // 
            // confirmAllUnreviewedToolStripMenuItem
            // 
            this.confirmAllUnreviewedToolStripMenuItem.Name = "confirmAllUnreviewedToolStripMenuItem";
            this.confirmAllUnreviewedToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.confirmAllUnreviewedToolStripMenuItem.Text = "Confirm All Unreviewed";
            this.confirmAllUnreviewedToolStripMenuItem.Click += new System.EventHandler(this.confirmAllUnreviewedToolStripMenuItem_Click);
            // 
            // recountAllUnreviewedToolStripMenuItem
            // 
            this.recountAllUnreviewedToolStripMenuItem.Name = "recountAllUnreviewedToolStripMenuItem";
            this.recountAllUnreviewedToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.recountAllUnreviewedToolStripMenuItem.Text = "Recount All Unreviewed";
            this.recountAllUnreviewedToolStripMenuItem.Click += new System.EventHandler(this.recountAllUnreviewedToolStripMenuItem_Click);
            // 
            // criticalAllUnreviewedToolStripMenuItem
            // 
            this.criticalAllUnreviewedToolStripMenuItem.Name = "criticalAllUnreviewedToolStripMenuItem";
            this.criticalAllUnreviewedToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.criticalAllUnreviewedToolStripMenuItem.Text = "Critical All Unreviewed";
            this.criticalAllUnreviewedToolStripMenuItem.Click += new System.EventHandler(this.criticalAllUnreviewedToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basicReportToolStripMenuItem,
            this.customReportToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.exportToolStripMenuItem.Text = "Report";
            // 
            // basicReportToolStripMenuItem
            // 
            this.basicReportToolStripMenuItem.Name = "basicReportToolStripMenuItem";
            this.basicReportToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.basicReportToolStripMenuItem.Text = "Basic Report";
            this.basicReportToolStripMenuItem.Click += new System.EventHandler(this.basicReportToolStripMenuItem_Click);
            // 
            // customReportToolStripMenuItem
            // 
            this.customReportToolStripMenuItem.Name = "customReportToolStripMenuItem";
            this.customReportToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.customReportToolStripMenuItem.Text = "Custom Report";
            this.customReportToolStripMenuItem.Click += new System.EventHandler(this.customReportToolStripMenuItem_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(12, 28);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(1222, 23);
            this.searchBox.TabIndex = 10;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // StockOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1246, 450);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.CountTable);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StockOverview";
            this.Text = "StockOverview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.CountTable)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView CountTable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem visibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unhideAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapShownHiddenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showConfirmedConfirmedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRecountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCriticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideAllReviewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideOnReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transfersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bulkActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoConfirmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ACL01ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ACL05ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ACL1ToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem autoCriticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ACG1ToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ACG3ToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem ACG5ToolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem confirmAllUnreviewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recountAllUnreviewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criticalAllUnreviewedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllReviewsToolStripMenuItem;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ToolStripMenuItem addDeliveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTransferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDeliveriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTransfersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variance;
        private System.Windows.Forms.DataGridViewButtonColumn ShowHide;
        private System.Windows.Forms.DataGridViewButtonColumn Confirm;
        private System.Windows.Forms.DataGridViewButtonColumn Recount;
        private System.Windows.Forms.DataGridViewButtonColumn Critical;
        private System.Windows.Forms.DataGridViewButtonColumn Notes;
        private System.Windows.Forms.ToolStripMenuItem resetSortingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRecountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromNetworkToolStripMenuItem;
    }
}