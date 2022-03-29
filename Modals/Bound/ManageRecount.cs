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

namespace StockerFrontend.Modals.Bound
{
    public partial class ManageRecount : Form
    {
        private UnifiedTable unified = new UnifiedTable();
        private LookupTable unifiedLookups = new LookupTable();
        private StockCountTable count = new StockCountTable();
        private List<UnifiedEntry> entries = new List<UnifiedEntry>();
        private List<bool> newSelections = new List<bool>();
        public ManageRecount(UnifiedTable unified, LookupTable lookups, StockCountTable count, List<UnifiedEntry> entries)
        {
            this.unified = unified;
            this.count = count;
            this.unifiedLookups = lookups;
            this.entries = entries;
            InitializeComponent();
            Populate();
            dataGrid.CellClick += new DataGridViewCellEventHandler(dataGrid_CellClick);

            GridDoubleBuffering.Enable(dataGrid);

            if (dataGrid.Rows.Count == 0)
            {
                //Closing a form calls dispose(), which requires a fully constructed object
                //As such, it is impossible to close a form directly from the constructor
                //Instead, we add an event to the load handler, which is invoked immediately after the constructor completes
                MessageBox.Show("No values varied between the new and old count.");
                Load += (s, e) => Close();
                return;
            }
        }

        private void Populate()
        {
            var list = count.GetSearchList();
            var m = count.GetEntryCount();
            for (uint i = 0; i < unified.Count(); i++)
            {
                var matching = list.Search(unified.GetName(i));

                //Does this product appear in the recount?
                if (matching.Size() == 0)
                    continue; //If not, continue

                float total = 0;
                for (uint u = 0; u < matching.Size(); u++)
                {
                    uint pos = matching.Get(u);
                    if (unified.HasTranslation(count.GetNameSize(pos)))
                    {
                        total +=
                            count.GetCount(pos) *
                            unified.GetTranslation(count.GetNameSize(pos));
                    }
                    else
                    {
                        total += count.GetCount(pos);
                    }
                }
                if (unified.GetCount(i) != total)
                    dataGrid.Rows.Add(unified.GetName(i), unified.GetCount(i), total, i);
            }
            newSelections.Clear();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                dataGrid.Rows[i].Cells[1].Style.BackColor = Color.Green;
                newSelections.Add(false);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < newSelections.Count; i++)
            {
                if (newSelections[i])
                {
                    string? contents = dataGrid.Rows[i].Cells[3].Value.ToString();
                    if (contents == null)
                        continue;

                    uint ID = uint.Parse(contents);

                    contents = dataGrid.Rows[i].Cells[2].Value.ToString();
                    if (contents == null)
                        continue;

                    float newVal = float.Parse(contents);

                    unified.provideRecount(ID, newVal);
                    entries[(int)ID].update(unified, ID);
                }
            }
            Close();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.ColumnIndex != 2)
                return;

            dataGrid.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
            dataGrid.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.White;

            newSelections[e.RowIndex] = e.ColumnIndex == 2;
            dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
        }
    }
}
