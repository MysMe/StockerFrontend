﻿namespace StockerFrontend.Forms
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
            this.toggleRecounts = new System.Windows.Forms.Button();
            this.toggleCleared = new System.Windows.Forms.Button();
            this.toggleCritical = new System.Windows.Forms.Button();
            this.completeButton = new System.Windows.Forms.Button();
            this.addDelivery = new System.Windows.Forms.Button();
            this.addTransfer = new System.Windows.Forms.Button();
            this.viewDeliveries = new System.Windows.Forms.Button();
            this.viewTransfers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toggleRecounts
            // 
            this.toggleRecounts.Location = new System.Drawing.Point(12, 12);
            this.toggleRecounts.Name = "toggleRecounts";
            this.toggleRecounts.Size = new System.Drawing.Size(75, 39);
            this.toggleRecounts.TabIndex = 0;
            this.toggleRecounts.Text = "Show/Hide Recounts";
            this.toggleRecounts.UseVisualStyleBackColor = true;
            // 
            // toggleCleared
            // 
            this.toggleCleared.Location = new System.Drawing.Point(93, 12);
            this.toggleCleared.Name = "toggleCleared";
            this.toggleCleared.Size = new System.Drawing.Size(75, 39);
            this.toggleCleared.TabIndex = 1;
            this.toggleCleared.Text = "Show/Hide Cleared";
            this.toggleCleared.UseVisualStyleBackColor = true;
            // 
            // toggleCritical
            // 
            this.toggleCritical.Location = new System.Drawing.Point(174, 12);
            this.toggleCritical.Name = "toggleCritical";
            this.toggleCritical.Size = new System.Drawing.Size(75, 39);
            this.toggleCritical.TabIndex = 2;
            this.toggleCritical.Text = "Show/Hide Critical";
            this.toggleCritical.UseVisualStyleBackColor = true;
            // 
            // completeButton
            // 
            this.completeButton.Location = new System.Drawing.Point(255, 12);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(75, 39);
            this.completeButton.TabIndex = 3;
            this.completeButton.Text = "Complete";
            this.completeButton.UseVisualStyleBackColor = true;
            // 
            // addDelivery
            // 
            this.addDelivery.Location = new System.Drawing.Point(336, 12);
            this.addDelivery.Name = "addDelivery";
            this.addDelivery.Size = new System.Drawing.Size(75, 39);
            this.addDelivery.TabIndex = 4;
            this.addDelivery.Text = "Add Delivery";
            this.addDelivery.UseVisualStyleBackColor = true;
            // 
            // addTransfer
            // 
            this.addTransfer.Location = new System.Drawing.Point(417, 12);
            this.addTransfer.Name = "addTransfer";
            this.addTransfer.Size = new System.Drawing.Size(75, 39);
            this.addTransfer.TabIndex = 5;
            this.addTransfer.Text = "Add Transfer";
            this.addTransfer.UseVisualStyleBackColor = true;
            // 
            // viewDeliveries
            // 
            this.viewDeliveries.Location = new System.Drawing.Point(498, 12);
            this.viewDeliveries.Name = "viewDeliveries";
            this.viewDeliveries.Size = new System.Drawing.Size(75, 39);
            this.viewDeliveries.TabIndex = 6;
            this.viewDeliveries.Text = "View Deliveries";
            this.viewDeliveries.UseVisualStyleBackColor = true;
            // 
            // viewTransfers
            // 
            this.viewTransfers.Location = new System.Drawing.Point(579, 12);
            this.viewTransfers.Name = "viewTransfers";
            this.viewTransfers.Size = new System.Drawing.Size(75, 39);
            this.viewTransfers.TabIndex = 7;
            this.viewTransfers.Text = "View Transfers";
            this.viewTransfers.UseVisualStyleBackColor = true;
            // 
            // StockOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewTransfers);
            this.Controls.Add(this.viewDeliveries);
            this.Controls.Add(this.addTransfer);
            this.Controls.Add(this.addDelivery);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.toggleCritical);
            this.Controls.Add(this.toggleCleared);
            this.Controls.Add(this.toggleRecounts);
            this.Name = "StockOverview";
            this.Text = "StockOverview";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toggleRecounts;
        private System.Windows.Forms.Button toggleCleared;
        private System.Windows.Forms.Button toggleCritical;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Button addDelivery;
        private System.Windows.Forms.Button addTransfer;
        private System.Windows.Forms.Button viewDeliveries;
        private System.Windows.Forms.Button viewTransfers;
    }
}