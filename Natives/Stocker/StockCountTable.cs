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
        StockCountTable parent;

        [DllImport("Stocker.dll")]
        private static extern uint stockTable_full_search_size(IntPtr ptr);

        [DllImport("Stocker.dll")]
        private static extern uint stockTable_full_search_get(IntPtr list, IntPtr ptr, uint index);

        [DllImport("Stocker.dll")]
        private static extern void stockTable_full_search_search_delete(IntPtr ptr);

        public FullSearchResult(StockCountTable owner, IntPtr contents)
        {
            ptr = contents;
            parent = owner;
        }

        public uint Size()
        {
            return stockTable_full_search_size(ptr);
        }

        public uint Get(uint index)
        {
            return stockTable_full_search_get(parent.Ptr(), ptr, index);
        }

        ~FullSearchResult()
        {
            stockTable_full_search_search_delete(ptr);
        }
    }

    public class FullSearchList
    {
        private IntPtr ptr = IntPtr.Zero;
        private StockCountTable parent;

        [DllImport("Stocker.dll")]
        private static extern IntPtr stockTable_full_search_search_new(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string data);

        [DllImport("Stocker.dll")]
        private static extern uint stockTable_full_search_list_delete(IntPtr ptr);

        public FullSearchList(StockCountTable owner, IntPtr contents)
        {
            ptr = contents;
            parent = owner;
        }

        public FullSearchResult Search(string name)
        {
            return new FullSearchResult(parent, stockTable_full_search_search_new(ptr, name));
        }

        ~FullSearchList()
        {
            stockTable_full_search_list_delete(ptr);
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
        private static extern IntPtr stockTable_get_full_search_list_new(IntPtr table);

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

        public FullSearchList GetSearchList()
        {
            return new FullSearchList(this, stockTable_get_full_search_list_new(table));
        }
    }
}
