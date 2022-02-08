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

        private void SelectCountButton_Click(object sender, EventArgs e)
        {
            string? file = getFile();
            if (file != null)
            {
                if (count.Load(file) == 0)
                {
                    parseOutputBox.Text += "Stock count parsed successfully.\r\n";
                    SelectStockFile.Enabled = true;
                    SelectCountButton.Enabled = false;
                }
                else
                {
                    parseOutputBox.Text += "Failed to parse stock count.\r\n";
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
                    parseOutputBox.Text += "Unified table parsed successfully, all translations present.\r\n";
                    SelectStockFile.Enabled = false;
                    resolveTranslationButton.Enabled = false;
                    doneButton.Enabled = true;
                }
                else if (res == -1)
                {
                    parseOutputBox.Text += "Unable to parse input XLS file.\r\n";
                    resolveTranslationButton.Enabled = false;
                    doneButton.Enabled = false;
                }
                else
                {
                    parseOutputBox.Text += "Unified table parsed successfully, translations required.\r\n";
                    SelectStockFile.Enabled = false;
                    resolveTranslationButton.Enabled = true;
                    doneButton.Enabled = false;
                }
            }
        }
    }
}
