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
            noteInput.KeyPress += AddNote_KeyPress;
            this.KeyPress += AddNote_KeyPress;
        }

        private void AddNote_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                //Shift + escape does not save
                if (Control.ModifierKeys != Keys.Shift)
                    entry.notes = noteInput.Text;
                Close();
            }
            else
            {
                e.Handled = false;
            }
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
