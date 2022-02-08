using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    internal class StockCountTable
    {
        IntPtr table = IntPtr.Zero;

        [DllImport("Stocker.dll")]
        private static extern IntPtr stockTable_new();

        [DllImport("Stocker.dll")]
        private static extern void stockTable_delete(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern int stockTable_reuse(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);

        public StockCountTable()
        {
            table = stockTable_new();
        }

        ~StockCountTable()
        {
            stockTable_delete(table);
        }

        public int Load(string file)
        {
            return stockTable_reuse(table, file);
        }

        public IntPtr Ptr()
        {
            return table;
        }
    }
}
