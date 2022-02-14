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

namespace StockerFrontend.Forms
{
    public partial class TranslationManager : Form
    {

        private UnifiedTable unified = new UnifiedTable();
        private StockCountTable count = new StockCountTable();

        private void Populate()
        {
        }

        public TranslationManager()
        {
            InitializeComponent();
        }
    }
}
