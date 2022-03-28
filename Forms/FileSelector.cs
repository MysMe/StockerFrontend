using StockerFrontend.Forms;
using StockerFrontend.Modals.Global;
using StockerFrontend.Natives;
using StockerFrontend.Natives.LanCon;
using StockerFrontend.Other;
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
        public bool deferLoad = false;

        public FileSelector(UnifiedTable unified)
        {
            this.unified = unified;
            InitializeComponent();
        }

        private static string? getFile(string extension)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = extension;
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        private void SelectCountButton_Click(object sender, EventArgs e)
        {
            string? file = getFile("CSV Stock Counts (*.csv)|*.csv");
            if (file != null)
            {
                if (count.Load(file) == 0)
                {
                    SelectStockFile.Enabled = true;
                    SelectCountButton.Enabled = false;
                    ReceiveCountButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Unable to parse count file.");
                }
            }
        }

        private void SelectStockFile_Click(object sender, EventArgs e)
        {
            string? file = getFile("XLS Stock Reports (*.xls)|*.xls");
            if (file != null)
            {
                //Note that translations are allowed to fail loading silently
                unified.LoadTranslations(TranslationManager.translationFile);

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
                    DialogResult = form.DialogResult;
                    Close();
                }
            }
        }

        private void ReceiveCountButton_Click(object sender, EventArgs e)
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

            if (count.LoadFromMemory(contents) == 0)
            {
                SelectStockFile.Enabled = true;
                SelectCountButton.Enabled = false;
                ReceiveCountButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Unable to parse count file.");
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            deferLoad = true;
            Close();
        }
    }
}
