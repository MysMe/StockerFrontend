using StockerFrontend.Other;
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
    public partial class CustomiseReport : Form
    {
        public CustomiseReport()
        {
            InitializeComponent();
        }

        public Exporter.Mode mode;

        private void orderOriginal_CheckedChanged(object sender, EventArgs e)
        {
            orderCategorised.Checked = false;
        }

        private void orderCategorised_CheckedChanged(object sender, EventArgs e)
        {
            orderOriginal.Checked = false;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (orderOriginal.Checked)
                mode = Exporter.Mode.Ordered;
            else
                mode = Exporter.Mode.Categorised;

            if (itemsUnreviewed.Checked)
                mode |= Exporter.Mode.Normal;
            if (itemsConfirmed.Checked)
                mode |= Exporter.Mode.Confirmed;
            if (itemsRecounted.Checked)
                mode |= Exporter.Mode.Recount;
            if (itemsCritical.Checked)
                mode |= Exporter.Mode.Critical;
            if (itemsTransfers.Checked)
                mode |= Exporter.Mode.Transfers;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
