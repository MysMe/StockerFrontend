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

        [DllImport("Stocker.dll")]
        private static extern int stockTable_reuse_from_string(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string data);

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

        public int LoadFromMemory(string data)
        {
            return stockTable_reuse_from_string(table, data);
        }

        public string GetNameSize(uint index)
        {
            string? l = Marshal.PtrToStringAnsi(stockTable_getStockName(table, index));
            string? r = Marshal.PtrToStringAnsi(stockTable_getStockSize(table, index));
            if (l == null || r == null)
                return "";
            return l + r;
        }

        public string GetName(uint index)
        {
            string? v = Marshal.PtrToStringAnsi(stockTable_getStockName(table, index));
            if (v == null)
                return "";
            return v;
        }

        public string GetSize(uint index)
        {
            string? v = Marshal.PtrToStringAnsi(stockTable_getStockSize(table, index));
            if (v == null)
                return "";
            return v;
        }

        public IntPtr Ptr()
        {
            return table;
        }
    }
}
