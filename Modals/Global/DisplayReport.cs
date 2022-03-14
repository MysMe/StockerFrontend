using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend.Modals.Global
{
    public partial class DisplayReport : Form
    {

        private string report;

        private void Populate()
        {
            var lines = report.Split('\n');
            foreach (string line in lines)
            {
                var columns = line.Split(',');
                while (columns.Length > reportDisplay.Columns.Count)
                {
                    reportDisplay.Columns.Add("", "");
                    reportDisplay.Columns[reportDisplay.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                reportDisplay.Rows.Add(columns);
            }
        }

        public DisplayReport(string report)
        {
            this.report = report;
            InitializeComponent();
            Populate();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult result = saveFileDialog.ShowDialog(); // Show the dialog.
            if (result != DialogResult.OK) // Test result.
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
            {
                sw.Write(report);
            }
        }
    }
}
