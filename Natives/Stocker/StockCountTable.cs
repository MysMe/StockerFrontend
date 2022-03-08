using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    public class StockCountTable
    {
        IntPtr table = IntPtr.Zero;

        [DllImport("Stocker.dll")]
        private static extern IntPtr stockTable_new();

        [DllImport("Stocker.dll")]
        private static extern void stockTable_delete(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern int stockTable_reuse(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr stockTable_getStockName(IntPtr table, uint index);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr stockTable_getStockSize(IntPtr table, uint index);

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

        public string GetNameSize(uint index)
        {
            return Marshal.PtrToStringAnsi(stockTable_getStockName(table, index)) + 
                Marshal.PtrToStringAnsi(stockTable_getStockSize(table, index));
        }

        public string GetName(uint index)
        {
            return Marshal.PtrToStringAnsi(stockTable_getStockName(table, index));
        }

        public string GetSize(uint index)
        {
            return Marshal.PtrToStringAnsi(stockTable_getStockSize(table, index));
        }

        public IntPtr Ptr()
        {
            return table;
        }
    }
}
