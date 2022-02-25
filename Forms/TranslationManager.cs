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

namespace StockerFrontend.Forms
{
    public partial class TranslationManager : Form
    {

        private UnifiedTable unified = new UnifiedTable();
        private StockCountTable count = new StockCountTable();

        private const string translationFile = "Translations.txt";

        private void Populate()
        {
            translationList.Rows.Clear();
            for (uint i = 0; i < unified.GetTranslationCount(); i++)
            {
                var translation = unified.GetTranslation(i);
                translationList.Rows.Add(
                    i,
                    unified.GetName(translation.UnifiedIndex) + Environment.NewLine + count.GetName(translation.CountIndex),
                    unified.GetSize(translation.UnifiedIndex) + Environment.NewLine + count.GetSize(translation.CountIndex),
                    1);
            }
        }

        public TranslationManager(UnifiedTable unified, StockCountTable count)
        {
            this.unified = unified;
            this.count = count;
            InitializeComponent();
            translationList.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            translationList.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Populate();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (!unified.LoadTranslations(translationFile))
            {
                MessageBox.Show("Unable to load translation file");
            }
            else
            {
                unified.ApplyTranslations(count.Ptr());
                Close();
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Warning: These translations will overwrite any saved translations. Continue?", 
                "Confirm overwrite", 
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < translationList.Rows.Count; i++)
                {
                    string? contents = translationList.Rows[i].Cells[0].Value.ToString();
                    if (contents == null)
                        continue;

                    uint ID = uint.Parse(contents);

                    contents = translationList.Rows[i].Cells[3].Value.ToString();
                    if (contents == null)
                        continue;

                    float ratio = float.Parse(contents);

                    unified.ProvideTranslation(ID, ratio, count.Ptr());
                }
                unified.ApplyTranslations(count.Ptr());
                unified.SaveTranslations(translationFile);
                Close();
            }
        }
    }
}
