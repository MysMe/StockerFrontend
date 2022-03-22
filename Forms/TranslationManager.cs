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

        public const string translationFile = "Translations.txt";

        private void Populate()
        {
            translationList.Rows.Clear();
            if (!unified.LoadTranslations(translationFile))
            {
                MessageBox.Show("Unable to load translation file");
            }
            for (uint i = 0; i < unified.GetTranslationCount(); i++)
            {
                var translation = unified.GetTranslation(i);
                translationList.Rows.Add(
                    i,
                    unified.GetName(translation.UnifiedIndex) + Environment.NewLine + count.GetName(translation.CountIndex),
                    unified.GetSize(translation.UnifiedIndex) + Environment.NewLine + count.GetSize(translation.CountIndex),
                    UnifiedTable.suggestTranslation(unified.GetSize(translation.UnifiedIndex), count.GetSize(translation.CountIndex)));
            }
        }

        public TranslationManager(UnifiedTable unified, StockCountTable count)
        {
            this.unified = unified;
            this.count = count;
            InitializeComponent();
            translationList.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            translationList.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            translationList.KeyDown += new KeyEventHandler(dataGrid_KeyDown);
            Populate();
            this.DialogResult = DialogResult.Cancel;
        }

        private enum Check
        {
            good, //All cells contain positive, non-zero values
            notAllNumbers, //Some cells contain non-numeric values
            notAllValid //All cells contain numeric values, but some are <= 0
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                translationList.CurrentCell = translationList[
                    translationList.CurrentCell.ColumnIndex,
                    translationList.CurrentCell.RowIndex + 1];
            }
        }

        private Check CheckContents()
        {
            for (int i = 0; i < translationList.Rows.Count; i++)
            {
                string? contents = translationList.Rows[i].Cells[3].Value.ToString();
                if (contents == null)
                    return Check.notAllNumbers;
                float val;
                if (!float.TryParse(contents, out val))
                    return Check.notAllNumbers;
                if (val <= 0)
                    return Check.notAllValid;
            }
            return Check.good;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            var result = CheckContents();
            if (result == Check.notAllNumbers)
            {
                MessageBox.Show("Error: All cells must contain numbers.");
                return;
            }
            if (result == Check.notAllValid)
            {
                if (MessageBox.Show(
                    "Warning: Some translations have a value less than or equal to zero. Continue?",
                    "Value Warning",
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
            }


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
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
