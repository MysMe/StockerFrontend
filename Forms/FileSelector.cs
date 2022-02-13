using StockerFrontend.Forms;
using StockerFrontend.Natives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend
{
    public partial class FileSelector : Form
    {
        UnifiedTable unified = new UnifiedTable();
        StockCountTable count = new StockCountTable();
        uint translationIndex = 0;

        public FileSelector()
        {
            InitializeComponent();
        }

        private static string? getFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        private void Log(string text)
        {
            parseOutputBox.Text += text + "\r\n";
        }

        private void PrintTranslation()
        {
            var translation = unified.GetTranslation(translationIndex);
            StockCountName.Text = count.GetNameSize(translation.CountIndex);
            UnifiedName.Text= unified.GetNameSize(translation.UnifiedIndex);
            TranslationInput.Text = "1";
        }

        private void SelectCountButton_Click(object sender, EventArgs e)
        {
            string? file = getFile();
            if (file != null)
            {
                if (count.Load(file) == 0)
                {
                    Log("Stock count parsed successfully.");
                    SelectStockFile.Enabled = true;
                    SelectCountButton.Enabled = false;
                }
                else
                {
                    Log("Failed to parse stock count.");
                    SelectStockFile.Enabled = false;
                }
            }
        }

        private void SelectStockFile_Click(object sender, EventArgs e)
        {
            string? file = getFile();
            if (file != null)
            {
                int res = unified.load(file, count);
                if (res == 1)
                {
                    Log("Unified table parsed successfully, all translations present.");
                    SelectStockFile.Enabled = false;
                    resolveTranslationButton.Enabled = false;
                    doneButton.Enabled = true;
                }
                else if (res == -1)
                {
                    Log("Unable to parse input XLS file.");
                    resolveTranslationButton.Enabled = false;
                    doneButton.Enabled = false;
                }
                else
                {
                    Log("Unified table parsed successfully, translations required.");
                    SelectStockFile.Enabled = false;
                    resolveTranslationButton.Enabled = true;
                    doneButton.Enabled = false;
                    doneButton.Enabled = true; /*TODO: Remove this*/
                    PrintTranslation();
                }
            }
        }

        private void TranslationConfirm_Click(object sender, EventArgs e)
        {
            unified.ProvideTranslation(translationIndex, float.Parse(TranslationInput.Text), count.Ptr());
            translationIndex++;
            PrintTranslation();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            StockOverview form = new StockOverview(unified, count);
            form.Show();
        }
    }
}
