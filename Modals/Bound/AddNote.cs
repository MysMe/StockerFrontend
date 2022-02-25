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

namespace StockerFrontend.Modals.Bound
{
    public partial class AddNote : Form
    {

        private UnifiedEntry entry;
        public AddNote(UnifiedEntry unified)
        {
            entry = unified;
            InitializeComponent();
            noteInput.Text = entry.notes;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            entry.notes = noteInput.Text;
            Close();
        }
    }
}
