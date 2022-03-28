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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StockerFrontend.Forms
{
    public partial class StockOverview : Form
    {
        private UnifiedTable unified = new UnifiedTable();
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
            entries.Clear();
            for (uint i = 0;i < unified.Count(); i++)
            {
                entries.Add(unified.Get(i));
            }

            lookup = new LookupTable(unified);
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
                        i,                                          //Column 0, ID
                        entries[i].Name,                            //Column 1, Name
                        entries[i].Size,                            //Column 2, Product size
                        Math.Round(entries[i].GetExpected(), 2),    //Column 3, Expected
                        Math.Round(entries[i].GetCount(), 2),       //Column 4, Counted
                        Math.Round(entries[i].GetVariance(), 2));   //Column 5, Variance
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

            //Datagridviews support double bufferring (a common visual smoothing technique)
            //While more performance intensive, this vastly improves the visual quality of the table
            //which has a tendency to lag.
            //However, the attribute is normally hidden. As such, we enable it by using reflection
            //to bypass the access restriction.
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null,
                CountTable, new object[] { true });

            this.KeyPress += StockOverview_KeyPress;
            Hide();
            while (true)
            {
                FileSelector selector = new FileSelector(unified);
                if (selector.ShowDialog() != DialogResult.OK)
                {
                    if (selector.deferLoad)
                    {
                        if (!load())
                            continue;
                        else
                            break;
                    }
                    else
                    {
                        //Closing a form calls dispose(), which requires a fully constructed object
                        //As such, it is impossible to close a form directly from the constructor
                        //Instead, we add an event to the load handler, which is invoked immediately after the constructor completes
                        Load += (s, e) => Close();
                        return;
                    }
                }
                else
                {
                    Populate();
                    Regenerate();
                    break;
                }
            }


            //Due to the order of window creation/destruction, this window is
            //put at the back of all others (including other applications).
            //Hence we minimise, update and maximise to force it back to the front
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

        private void StockOverview_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (CountTable.Rows.Count == 0)
                return;

            int rowIndex = 0;
            if (CountTable.SelectedCells.Count != 0)
                rowIndex = CountTable.SelectedCells[0].RowIndex;

            switch (e.KeyChar)
            {
                default:
                    return;

                case (char)Keys.D4:
                    ActOnRow(rowIndex, Columns.hide);
                    return;

                case (char)Keys.D1:
                    ActOnRow(rowIndex, Columns.confirm);
                    break;

                case (char)Keys.D2:
                    ActOnRow(rowIndex, Columns.recount);
                    break;

                case (char)Keys.D3:
                    ActOnRow(rowIndex, Columns.critical);
                    break;

                case (char)Keys.D5:
                    ActOnRow(rowIndex, Columns.notes);
                    break;
            }
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

            ActOnRow(e.RowIndex, (Columns)e.ColumnIndex);
        }

        private void ActOnRow(int rowIndex, Columns action)
        {
            string? contents = CountTable.Rows[rowIndex]
                .Cells[(int)Columns.id].Value
                .ToString();
            if (contents == null)
                return;


            int index = int.Parse(contents);
            switch (action)
            {
                default:
                    return;

                case Columns.hide:
                    //If we are showing hidden items then unhide this one and vice versa
                    SetHideAndRemove(rowIndex, !invertHiddenDisplay);
                    return;

                case Columns.confirm:
                    entries[index].Status = UnifiedEntry.status.confirmed;
                    break;

                case Columns.recount:
                    entries[index].Status = UnifiedEntry.status.recount;
                    break;

                case Columns.critical:
                    entries[index].Status = UnifiedEntry.status.critical;
                    break;

                case Columns.notes:
                    AddNote form = new AddNote(entries[index]);
                    form.ShowDialog();
                    return;
            }
            if (autohide && !invertHiddenDisplay) //Do not autohide if hidden items are being displayed
                SetHideAndRemove(rowIndex, true); //Otherwise, always hide if autohide is on
            else
                ApplyColour(rowIndex); //Don't apply colour changes to hidden rows
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
                    Math.Abs(i.GetVariance()) <= 0.1)
                    i.Status = UnifiedEntry.status.confirmed;
            }
            Regenerate();
        }

        private void ACL05ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    Math.Abs(i.GetVariance()) <= 0.5)
                    i.Status = UnifiedEntry.status.confirmed;
            }
            Regenerate();
        }

        private void ACL1ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    Math.Abs(i.GetVariance()) <= 1)
                    i.Status = UnifiedEntry.status.confirmed;
            }
            Regenerate();
        }

        private void ACG1ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    Math.Abs(i.GetVariance()) >= 1)
                    i.Status = UnifiedEntry.status.critical;
            }
            Regenerate();
        }

        private void ACG3ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    Math.Abs(i.GetVariance()) >= 3)
                    i.Status = UnifiedEntry.status.critical;
            }
            Regenerate();
        }

        private void ACG5ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            foreach (var i in entries)
            {
                if (i.Status == UnifiedEntry.status.normal &&
                    Math.Abs(i.GetVariance()) >= 5)
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
            DisplayReport form = new DisplayReport(Exporter.Export(entries, deliveries, transfers, 
                Exporter.Mode.Categorised | Exporter.Mode.Normal | Exporter.Mode.Confirmed |
                Exporter.Mode.Recount | Exporter.Mode.Critical));
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
                        sw.Write(Exporter.Export(entries, deliveries, transfers,
                            Exporter.Mode.Categorised | Exporter.Mode.Normal | Exporter.Mode.Confirmed |
                            Exporter.Mode.Recount | Exporter.Mode.Critical).ToString());
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

        private void basicReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayReport form = new DisplayReport(Exporter.Export(entries, deliveries, transfers,
                Exporter.Mode.Categorised | Exporter.Mode.Normal | Exporter.Mode.Confirmed |
                Exporter.Mode.Recount | Exporter.Mode.Critical));
            form.ShowDialog();
        }

        private void customReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomiseReport form1 = new CustomiseReport();
            var result = form1.ShowDialog();
            if (result == DialogResult.Cancel)
                return;

            DisplayReport form2 = new DisplayReport(Exporter.Export(
                entries, deliveries, transfers, form1.mode));
            form2.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "stk";
            save.AddExtension = true;
            save.FileName = "Stock";
            save.Filter = "Stock Report Files (*.stk)|*.stk";
            DialogResult res = save.ShowDialog();
            if (res != DialogResult.OK)
                return;
            using (StreamWriter sw = new StreamWriter(save.FileName))
                FileFormer.Form(sw, unified, entries, deliveries, transfers);
        }

        private bool load()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Stock Report Files (*.stk)|*.stk";
            DialogResult res = open.ShowDialog();
            if (res != DialogResult.OK)
                return false;

            List<UnifiedEntry> entryAdditional;

            try
            {
                using (StreamReader sr = new StreamReader(open.FileName))
                    if (!FileFormer.Deform(sr, out unified, out entryAdditional, out deliveries, out transfers))
                        return false;
            }
            catch
            {
                return false;
            }

            unified.LoadTranslations(TranslationManager.translationFile);
            Populate();
            for (int i = 0; i < entryAdditional.Count(); i++)
            {
                entries[i].MergeAdditional(entryAdditional[i]);
            }

            Regenerate();

            return true;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load();
        }

        private void ImportRecount(StockCountTable table) 
        {
            ManageRecount form = new ManageRecount(unified, lookup, table, entries);
            form.ShowDialog();
            Regenerate();
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() != DialogResult.OK)
                return;
            StockCountTable count = new StockCountTable();
            if (count.Load(file.FileName) != 0)
            {
                MessageBox.Show("Unable to open file.", "Error");
                return;
            }
            ImportRecount(count);
        }

        private void fromNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UDPListen form = new UDPListen();
            form.ShowDialog();

            if (form.receiver == null)
            {
                return;
            }
            if (form.message == null)
            {
                //Recover the socket so it can be reused
                form.receiver.Destruct();
                return;
            }


            var form1 = new MessageReceive(form.receiver, form.message, form.message.GetAdditional());
            form1.ShowDialog();

            //Recover the socket so it can be reused
            form.receiver.Destruct();

            string? contents = form1.output;
            if (contents == null)
                return;

            StockCountTable count = new StockCountTable();

            if (count.LoadFromMemory(contents) != 0)
            {
                MessageBox.Show("Unable to parse count file.", "Error");
                return;
            }
            ImportRecount(count);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The main grid shows a list of all counted products and their expected values." + Environment.NewLine +
                "The variance column indicates how many are missing or surplus from the count." + Environment.NewLine +
                "The buttons on the right can be used to perform various actions." + Environment.NewLine +
                "Hiding an entry means it will not be visible until unhidden or the view is changed. This can be done under the visibility tab." + Environment.NewLine +
                "Confirming an entry indicates that the count is the expected value. Multiple entries can be confirmed with the bulk actions tab." + Environment.NewLine +
                "Recounting an entry indicates that the count is wrong, but likely due to counter error. Recounts can be imported from the file tab." + Environment.NewLine +
                "A critical entry is notably wrong for an unknown reason and requires further investigation. You can also bulk critical entries." + Environment.NewLine +
                "When marking an entry, it will automatically be hidden unless hide on review (in the visibility tab) is turned off." + Environment.NewLine +
                "An entry can have notes added that show up in the final report." + Environment.NewLine +
                "All these actions have a keyboard shortcut:" + Environment.NewLine +
                "   NUM1 - Confirm selected or topmost entry." + Environment.NewLine +
                "   NUM2 - Recount selected or topmost entry." + Environment.NewLine +
                "   NUM3 - Mark selected or topmost entry as critical." + Environment.NewLine +
                "   NUM4 - Hide the selected or topmost entry." + Environment.NewLine +
                "   NUM5 - Open notes for the selected or topmost entry.", "Information");
        }
    }
}
