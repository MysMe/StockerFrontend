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

        public FileSelector(UnifiedTable unified, StockCountTable count)
        {
            this.unified = unified;
            this.count = count;
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
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
                    SelectStockFile.Enabled = true;
                    SelectCountButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Unable to parse count file.");
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
                    //All translations present
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (res == -1)
                {
                    //Error
                    MessageBox.Show("Unable to parse input XLS file.");
                }
                else
                {
                    //Translations required
                    TranslationManager form = new TranslationManager(unified, count);
                    this.Hide();
                    form.ShowDialog();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
