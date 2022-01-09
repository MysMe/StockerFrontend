using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend
{
    public partial class FileSelector : Form
    {
        public FileSelector()
        {
            InitializeComponent();
        }

        private static string? getFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                return openFileDialog1.FileName;
            }
            return null;
        }

        private void SelectCountButton_Click(object sender, EventArgs e)
        {
            string? file = getFile();
        }

        private void SelectStockFile_Click(object sender, EventArgs e)
        {
            string? file = getFile();
        }
    }
}
