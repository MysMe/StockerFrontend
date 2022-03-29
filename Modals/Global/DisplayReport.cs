using StockerFrontend.Other;
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

        private static string[] SpliteLine(string line)
        {
            List<string> result = new List<string>();
            StringBuilder currentStr = new StringBuilder("");
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++) // For each character
            {
                if (line[i] == '\"') // Quotes are closing or opening
                    inQuotes = !inQuotes;
                else if (line[i] == ',') // Comma
                {
                    if (!inQuotes) // If not in quotes, end of current string, add it to result
                    {
                        result.Add(currentStr.ToString());
                        currentStr.Clear();
                    }
                    else
                        currentStr.Append(line[i]); // If in quotes, just add it 
                }
                else // Add any other character to current string
                    currentStr.Append(line[i]);
            }
            result.Add(currentStr.ToString());
            return result.ToArray(); // Return array of all strings
        }

        private void Populate()
        {
            var lines = report.Split('\n');
            foreach (string line in lines)
            {
                if (line.Count() == 0)
                    continue;
                var columns = SpliteLine(line);
                while (columns.Length > reportDisplay.Columns.Count)
                {
                    reportDisplay.Columns.Add("", "");
                    reportDisplay.Columns[reportDisplay.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                reportDisplay.Rows.Add(columns);
            }
            if (reportDisplay.Columns.Count > 0)
                reportDisplay.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public DisplayReport(string report)
        {
            this.report = report;
            InitializeComponent();
            Populate();
            GridDoubleBufferring.Enable(reportDisplay);
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
