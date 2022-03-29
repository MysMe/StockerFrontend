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
    public partial class AddDelivery : Form
    {

        UnifiedTable unified = new UnifiedTable();
        LookupTable lookups = new LookupTable();

        public Delivery? delivery = null;
        public Transfer? transfer = null;

        bool isTransfer = false;

        private void SetForTransfer()
        {
            supplierLabel.Text = "Destination:";
            invoiceLabel.Hide();
            invoiceInput.Hide();
            this.Text = "Add Transfer";
            orderContents.Columns[3].HeaderCell.Value = "Transferred";
        }

        private void PopulateSearch()
        {
            searchResults.Rows.Clear();
            for (uint i = 0; i < unified.Count(); i++)
            {
                searchResults.Rows.Add(
                    i,
                    "<<",
                    unified.GetName(i),
                    unified.GetSize(i));
            }
        }

        private void PopulateSearch(LookupTableSearchResult restrict)
        {
            searchResults.Rows.Clear();
            for (int u = 0; u < restrict.Size(); u++)
            {
                if (FindInOrder(u) != -1)
                    continue;

                uint i = (uint)restrict.Get(u);

                searchResults.Rows.Add(
                    i,
                    "<<",
                    unified.GetName(i),
                    unified.GetSize(i));
            }
        }

        private int FindInOrder(int index)
        {
            for (int i = 0; i < orderContents.Rows.Count; i++)
            {
                if (orderContents.Rows[i].Cells[0].ToString() == index.ToString())
                    return i;
            }
            return -1;
        }

        private void AddToOrder(int index, float quantity = 0)
        {
            orderContents.Rows.Add(
                index,
                unified.GetName((uint)index),
                unified.GetSize((uint)index),
                quantity,
                ">>");
        }

        private void RemoveFromOrder(int index)
        {
            int pos = FindInOrder(index);
            if (pos == -1)
                return;
            orderContents.Rows.RemoveAt(pos);
        }

        public AddDelivery(UnifiedTable unifiedTable, LookupTable lookupTable, bool transfer)
        {
            unified = unifiedTable;
            lookups = lookupTable;

            InitializeComponent();
            PopulateSearch();
            isTransfer = transfer;
            if (isTransfer)
                SetForTransfer();

            GridDoubleBufferring.Enable(searchResults);
            GridDoubleBufferring.Enable(orderContents);
        }

        public void PreFill(Delivery delivery)
        {
            this.delivery = delivery;

            supplierInput.Text = delivery.supplier;
            invoiceInput.Text = delivery.invoice;
            datePerformed.Value = DateTime.Parse(delivery.date);

            for (int i = 0; i < delivery.products.Count; i++)
            {
                AddToOrder(i, delivery.deltas[i]);
            }
        }

        public void PreFill(Transfer trx)
        {
            this.transfer = trx;

            supplierInput.Text = trx.destination;
            datePerformed.Value = DateTime.Parse(trx.date);

            for (int i = 0; i < trx.products.Count; i++)
            {
                AddToOrder(i, trx.deltas[i]);
            }
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            if (searchInput.Text.Length == 0)
                PopulateSearch();
            else
                PopulateSearch(lookups.search(searchInput.Text));
        }

        private void searchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string? contents = searchResults.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (contents == null)
                    return;
                AddToOrder(int.Parse(contents));
                searchResults.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (isTransfer)
            {
                transfer = new Transfer();
                transfer.destination = supplierInput.Text;
                transfer.date = datePerformed.Text;
                for (int i = 0; i < orderContents.Rows.Count; i++)
                {
                    string? contents = orderContents.Rows[i].Cells[0].Value.ToString();
                    if (contents == null)
                        continue;
                    transfer.products.Add(int.Parse(contents));

                    contents = orderContents.Rows[i].Cells[3].Value.ToString();
                    if (contents == null)
                        continue;
                    transfer.deltas.Add(float.Parse(contents));
                }
            }
            else
            {
                delivery = new Delivery();
                delivery.supplier = supplierInput.Text;
                delivery.date = datePerformed.Text;
                delivery.invoice = invoiceInput.Text;

                for (int i = 0; i < orderContents.Rows.Count; i++)
                {
                    string? contents = orderContents.Rows[i].Cells[0].Value.ToString();
                    if (contents == null)
                        continue;
                    delivery.products.Add(int.Parse(contents));

                    contents = orderContents.Rows[i].Cells[3].Value.ToString();
                    if (contents == null)
                        continue;
                    delivery.deltas.Add(float.Parse(contents));
                }
            }
            Close();
        }

        private void orderContents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string? contents = orderContents.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (contents == null)
                    return;
                RemoveFromOrder(int.Parse(contents));
                orderContents.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
