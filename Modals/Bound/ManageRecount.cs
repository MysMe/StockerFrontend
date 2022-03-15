using StockerFrontend.Natives;
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
        }

        private void Populate()
        {
            for (uint i = 0; i < unified.Count(); i++)
            {
                var matching = count.FullSearch(unified.GetName(i));

                //Does this product appear in the recount?
                if (matching.First() == matching.Last())
                    continue; //If not, continue

                float total = 0;
                for (uint pos = matching.First(); pos < matching.Last(); pos++)
                {
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
