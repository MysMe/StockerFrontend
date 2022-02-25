using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockerFrontend.Modals.Global
{
    public partial class DisplayReport : Form
    {

        private void Populate(string report)
        {
            var lines = report.Split('\n');
            foreach (string line in lines)
            {
                var columns = line.Split(',');
                while (columns.Length > reportDisplay.Columns.Count)
                    reportDisplay.Columns.Add("", "");

                reportDisplay.Rows.Add(columns);
            }
        }

        public DisplayReport(string report)
        {
            InitializeComponent();
            Populate(report);
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
