using StockerFrontend.Modals.Bound;
using StockerFrontend.Modals.Global;
using StockerFrontend.Natives;
using StockerFrontend.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StockerFrontend.Forms
{
    public partial class StockOverview : Form
    {
        private UnifiedTable unified = new UnifiedTable();
        private StockCountTable stockCount = new StockCountTable();
        private List<UnifiedEntry> entries = new List<UnifiedEntry>();
        private LookupTable lookup = new LookupTable();

        private List<Delivery> deliveries = new List<Delivery>();
        private List<Transfer> transfers = new List<Transfer>();

        //Determines whether or not the list exclusively contains hidden or unhidden items
        private bool invertHiddenDisplay = false;

        private bool showingConfirmed = true;
        private bool showingRecount = true;
        private bool showingCritical = true;

        private bool autohide = true;

        private enum Columns
        {
            id = 0,
            hide = 6,
            confirm = 7,
            recount = 8,
            critical = 9,
            notes = 10
        }

        private void Populate()
        {
            for (uint i = 0;i < unified.Count(); i++)
            {
                entries.Add(unified.Get(i));
            }
            lookup = new LookupTable(unified);
            Regenerate();
        }

        private bool ShouldShow(UnifiedEntry entry)
        {
            return
                (invertHiddenDisplay == entry.isHidden) && //Filter primarily by whether or not this entry is hidden and these are/n't being shown
                (
                    (entry.Status == UnifiedEntry.status.normal) || //Always allow uncategorised entries
                    (entry.Status == UnifiedEntry.status.confirmed && showingConfirmed) ||
                    (entry.Status == UnifiedEntry.status.recount && showingRecount) ||
                    (entry.Status == UnifiedEntry.status.critical && showingCritical)
                );
        }

        private void Regenerate()
        {
            CountTable.SuspendLayout();
            CountTable.Rows.Clear();
            for (int i = 0; i < (int)entries.Count(); i++)
            {
                if (ShouldShow(entries[i]))
                {
                    CountTable.Rows.Add(
                        i,                          //Column 0, ID
                        entries[i].Name,            //Column 1, Name
                        entries[i].Size,            //Column 2, Product size
                        entries[i].GetExpected(),   //Column 3, Expected
                        entries[i].GetCount(),      //Column 4, Counted
                        entries[i].GetVariance());  //Column 5, Variance
                    ApplyColour(CountTable.Rows.Count - 1);
                }
            }
            CountTable.ResumeLayout();
        }

        private void Regenerate(LookupTableSearchResult restrict)
        {
            CountTable.SuspendLayout();
            CountTable.Rows.Clear();
            for (int u = 0; u < restrict.Size(); u++)
            {
                int i = restrict.Get(u);
                if (ShouldShow(entries[i]))
                {
                    CountTable.Rows.Add(
                        i,                          //Column 0, ID
                        entries[i].Name,            //Column 1, Name
                        entries[i].Size,            //Column 2, Product size
                        entries[i].GetExpected(),   //Column 3, Expected
                        entries[i].GetCount(),      //Column 4, Counted
                        entries[i].GetVariance());  //Column 5, Variance
                    ApplyColour(CountTable.Rows.Count - 1);
                }
            }
            CountTable.ResumeLayout();
        }

        private void ApplyColour(int index)
        {
            string? contents = CountTable.Rows[index]
                                .Cells[(int)Columns.id].Value
                                .ToString();
            if (contents == null)
                return;

            switch (entries[int.Parse(contents)].Status)
            {
                default:
                    CountTable.Rows[index].DefaultCellStyle.BackColor = Color.White;
                    return;
                case UnifiedEntry.status.confirmed:
                    CountTable.Rows[index].DefaultCellStyle.BackColor = Color.Green;
                    return;
                case UnifiedEntry.status.recount:
                    CountTable.Rows[index].DefaultCellStyle.BackColor = Color.Orange;
                    return;
                case UnifiedEntry.status.critical:
                    CountTable.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                    return;
            }
        }

        public StockOverview()
        {
            InitializeComponent();
            Hide();
            FileSelector selector = new FileSelector(unified, stockCount);
            if (selector.ShowDialog() != DialogResult.OK)
            {
                //Closing a fowm calls dispose(), which requires a fully constructed object
                //As such, it is impossible to close a form directly from the constructor
                //Instead, we add an event to the load handler, which is invoked immediately after the constructor completes
                Load += (s, e) => Close();
            }

            Populate();
        }

        private void SetHideAndRemove(int index, bool hidden)
        {
            string? contents = CountTable.Rows[index]
                                         .Cells[(int)Columns.id].Value
                                         .ToString();
            if (contents != null)
            {
                entries[int.Parse(contents)].isHidden = hidden;
                CountTable.Rows.RemoveAt(index);
            }
        }

        private void CountTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            string? contents = CountTable.Rows[e.RowIndex]
                    .Cells[(int)Columns.id].Value
                    .ToString();
            if (contents == null)
                return;


            int index = int.Parse(contents);
            switch (e.ColumnIndex)
            {
                default:
                    return;

                case (int)Columns.hide:
                    //If we are showing hidden items then unhide this one and vice versa
                    SetHideAndRemove(e.RowIndex, !invertHiddenDisplay);
                    return;

                case (int)Columns.confirm:
                    entries[index].Status = UnifiedEntry.status.confirmed;
                    break;

                case (int)Columns.recount:
                    entries[index].Status = UnifiedEntry.status.recount;
                    break;

                case (int)Columns.critical:
                    entries[index].Status = UnifiedEntry.status.critical;
                    break;

                case (int)Columns.notes:
                    AddNote form = new AddNote(entries[index]);
                    form.ShowDialog();
                    return;
            }
            if (autohide && !invertHiddenDisplay) //Do not autohide if hidden items are being displayed
                SetHideAndRemove(e.RowIndex, true); //Otherwise, always hide if autohide is on
            else
                ApplyColour(e.RowIndex); //Don't apply colour changes to hidden rows
        }

        private void unhideAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
                i.isHidden = false;
            Regenerate();
        }

        private void swapShownHiddenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invertHiddenDisplay = !invertHiddenDisplay;
            Regenerate();
            if (invertHiddenDisplay)
                CountTable.Columns[(int)Columns.hide].HeaderText = "Unhide";
            else
                CountTable.Columns[(int)Columns.hide].HeaderText = "Hide";
        }

        private void showConfirmedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showingConfirmed = !showingConfirmed;
            Regenerate();
        }

        private void showRecountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showingRecount = !showingRecount;
            Regenerate();
        }

        private void showCriticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showingCritical = !showingCritical;
            Regenerate();
        }

        private void hideAllReviewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status != UnifiedEntry.status.normal)
                    i.isHidden = true;
            }
            Regenerate();
        }

        private void hideOnReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autohide = !autohide;
        }

        private void confirmAllUnreviewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal)
                    i.Status = UnifiedEntry.status.confirmed;
            }
            Regenerate();
        }

        private void recountAllUnreviewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal)
                    i.Status = UnifiedEntry.status.recount;
            }
            Regenerate();
        }

        private void criticalAllUnreviewedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal)
                    i.Status = UnifiedEntry.status.critical;
            }
            Regenerate();
        }

        private void ACL01ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    i.GetVariance() <= 0.1)
                    i.Status = UnifiedEntry.status.confirmed;
            }
            Regenerate();
        }

        private void ACL05ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    i.GetVariance() <= 0.5)
                    i.Status = UnifiedEntry.status.confirmed;
            }
            Regenerate();
        }

        private void ACL1ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    i.GetVariance() <= 1)
                    i.Status = UnifiedEntry.status.confirmed;
            }
            Regenerate();
        }

        private void ACG1ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    i.GetVariance() >= 1)
                    i.Status = UnifiedEntry.status.critical;
            }
            Regenerate();
        }

        private void ACG3ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    i.GetVariance() >= 3)
                    i.Status = UnifiedEntry.status.critical;
            }
            Regenerate();
        }

        private void ACG5ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    i.GetVariance() >= 5)
                    i.Status = UnifiedEntry.status.critical;
            }
            Regenerate();
        }

        private void clearAllReviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status != UnifiedEntry.status.normal)
                    i.Status = UnifiedEntry.status.normal;
            }
            Regenerate();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (searchBox.Text.Length > 0)
                Regenerate(lookup.search(searchBox.Text));
            else
                Regenerate();
        }

        private void addDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDelivery form = new AddDelivery(unified, lookup, false);
            form.ShowDialog();
            if (form.delivery != null)
            {
                form.delivery.Apply(entries);
                deliveries.Add(form.delivery);
                Regenerate();
            }
        }

        private void addTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDelivery form = new AddDelivery(unified, lookup, true);
            form.ShowDialog();
            if (form.transfer != null)
            {
                form.transfer.Apply(entries);
                transfers.Add(form.transfer);
                Regenerate();
            }
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayReport form = new DisplayReport(Exporter.Export(entries, deliveries, transfers));
            form.ShowDialog();
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".csv";
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        sw.Write(Exporter.Export(entries, deliveries, transfers).ToString());
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void manageDeliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDeliveries form = new ManageDeliveries(unified, lookup, entries, deliveries, transfers, false);
            form.ShowDialog();
            Regenerate();
        }

        private void manageTransfersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDeliveries form = new ManageDeliveries(unified, lookup, entries, deliveries, transfers, true);
            form.ShowDialog();
            Regenerate();
        }

        private void resetSortingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountTable.Sort(CountTable.Columns[0], ListSortDirection.Ascending);
        }
    }
}
