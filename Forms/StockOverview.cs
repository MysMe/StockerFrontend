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
    public partial class StockOverview : Form
    {
        private UnifiedTable unified = new UnifiedTable();
        private StockCountTable stockCount = new StockCountTable();

        private void Populate()
        {
            CountTable.Rows.Add("Test", "Size", "Zero", "Ten", "Minus Ten");
        }

        public StockOverview(UnifiedTable unifiedTable, StockCountTable stockCountTable)
        {
            unified = unifiedTable;
            stockCount = stockCountTable;

            InitializeComponent();

            Populate();
        }
    }
}
