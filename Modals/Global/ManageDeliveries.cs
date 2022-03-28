using StockerFrontend.Natives;
using StockerFrontend.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend.Modals.Global
{
    public partial class ManageDeliveries : Form
    {
        List<Delivery> deliveries;
        List<Transfer> transfers;
        List<UnifiedEntry> entries;

        UnifiedTable unified;
        LookupTable lookups;

        bool isTransfers = false;
        int current = 0;

        private void SetForTransfer()
        {
            orderList.Columns.RemoveAt(2);
            invoiceLabel.Hide();
            supplierLabel.Text = "Destination: ";
            orderList.Columns[1].HeaderText = "Destination";
        }

        private void Display(Delivery del)
        {
            ClearDisplay();
            supplierLabel.Text += del.supplier;
            invoiceLabel.Text += del.invoice;
            deliveryDateLabel.Text += del.date.ToString();
            for (int i = 0; i < del.deltas.Count; i++)
            {
                orderContents.Rows.Add(
                    entries[del.products[i]].Name,
                    entries[del.products[i]].Size,
                    del.deltas[i]);
            }
        }

        private void Display(Transfer trx)
        {
            ClearDisplay();
            supplierLabel.Text += trx.destination;
            deliveryDateLabel.Text += trx.date.ToString();
            for (int i = 0; i < trx.deltas.Count; i++)
            {
                orderContents.Rows.Add(
                    entries[trx.products[i]].Name,
                    entries[trx.products[i]].Size,
                    trx.deltas[i]);
            }
        }

        private void ClearDisplay()
        {
            if (isTransfers)
            {
                supplierLabel.Text = "Destination: ";
                deliveryDateLabel.Text = "Delivered on: ";
            }
            else
            {
                supplierLabel.Text = "Supplier: ";
                invoiceLabel.Text = "Invoice No: ";
                deliveryDateLabel.Text = "Delivered on: ";
            }
            orderContents.Rows.Clear();
        }

        private void DisplayCurrent()
        {
            if (current >= orderList.Rows.Count)
            {
                ClearDisplay();
                return;
            }

            if (isTransfers)
            {
                Display(transfers[current]);
            }
            else
            {
                Display(deliveries[current]);
            }
        }

        private void Populate()
        {
            if (isTransfers)
            {
                for (int i = 0; i < transfers.Count; i++)
                {
                    orderList.Rows.Add(
                        i,
                        transfers[i].destination,
                        transfers[i].date.ToString());
                }
            }
            else
            {
                for (int i = 0; i < deliveries.Count; i++)
                {
                    orderList.Rows.Add(
                        i,
                        deliveries[i].supplier,
                        deliveries[i].invoice,
                        deliveries[i].date.ToString());
                }
            }
        }

        public ManageDeliveries(UnifiedTable unified, LookupTable lookups, List<UnifiedEntry> entries, List<Delivery> deliveries, List<Transfer> transfers, bool isTransfers)
        {
            this.entries = entries;
            this.deliveries = deliveries;
            this.transfers = transfers;
            this.isTransfers = isTransfers;

            this.unified = unified;
            this.lookups = lookups;

            InitializeComponent();
            if (isTransfers)
            {
                SetForTransfer();
            }
            Populate();
            DisplayCurrent();
        }

        private void orderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string? contents = orderList.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (contents == null)
                return;

            current = int.Parse(contents);
            DisplayCurrent();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void revokeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to revoke this entry?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (isTransfers)
            {
                transfers[current].Remove(entries);
                transfers.RemoveAt(current);
            }
            else
            {
                deliveries[current].Remove(entries);
                deliveries.RemoveAt(current);
            }
            orderList.Rows.RemoveAt(current);
            current = 0;
            DisplayCurrent();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (isTransfers)
            {
                transfers[current].Remove(entries);
                AddDelivery form = new AddDelivery(unified, lookups, true);
                form.PreFill(transfers[current]);
                form.ShowDialog();
                if (form.transfer == null)
                    return;
                transfers[current] = form.transfer;
                transfers[current].Apply(entries);
                DisplayCurrent();
            }
            else
            {
                deliveries[current].Remove(entries);
                AddDelivery form = new AddDelivery(unified, lookups, false);
                form.PreFill(deliveries[current]);
                form.ShowDialog();
                if (form.delivery == null)
                    return;
                deliveries[current] = form.delivery;
                deliveries[current].Apply(entries);
                DisplayCurrent();
            }
        }
    }
}
