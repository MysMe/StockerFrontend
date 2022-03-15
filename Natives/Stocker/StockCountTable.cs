using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{

    public class FullSearchResult
    {
        private IntPtr ptr = IntPtr.Zero;

        [DllImport("Stocker.dll")]
        private static extern void stockTable_fullSearch_delete(IntPtr ptr);

        [DllImport("Stocker.dll")]
        private static extern uint stockTable_fullSearch_first(IntPtr ptr);

        [DllImport("Stocker.dll")]
        private static extern uint stockTable_fullSearch_last(IntPtr ptr);

        public FullSearchResult(IntPtr contents)
        {
            ptr = contents;
        }

        ~FullSearchResult()
        {
            stockTable_fullSearch_delete(ptr);
        }

        public uint First()
        {
            return stockTable_fullSearch_first(ptr);
        }

        public uint Last()
        {
            return stockTable_fullSearch_last(ptr);
        }

    }
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

        [DllImport("Stocker.dll")]
        private static extern float stockTable_getStockCount(IntPtr table, uint index);

        [DllImport("Stocker.dll")]
        private static extern uint stockTable_entry_count(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern IntPtr stockTable_fullSearch_new(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string product);

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

        public float GetCount(uint index)
        {
            return stockTable_getStockCount(table, index);
        }

        public uint GetEntryCount()
        {
            return stockTable_entry_count(table);
        }

        public IntPtr Ptr()
        {
            return table;
        }

        public FullSearchResult FullSearch(string product)
        {
            return new FullSearchResult(stockTable_fullSearch_new(table, product));
        }
    }
}
