using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    public class LookupTableSearchResult
    {
        IntPtr array = IntPtr.Zero;


        [DllImport("Stocker.dll")]
        private static extern void lookupTable_search_delete(IntPtr array);


        [DllImport("Stocker.dll")]
        private static extern int lookupTable_search_size(IntPtr array);


        [DllImport("Stocker.dll")]
        private static extern int lookupTable_search_value(IntPtr array, int index);

        public LookupTableSearchResult(IntPtr arrPtr)
        {
            array = arrPtr;
        }

        ~LookupTableSearchResult()
        {
            lookupTable_search_delete(array);
        }

        public bool valid()
        {
            return array != IntPtr.Zero;
        }

        public int Get(int index)
        {
            return lookupTable_search_value(array, index);
        }

        public int Size()
        {
            return lookupTable_search_size(array);
        }
    }
    public class LookupTable
    {
        IntPtr table = IntPtr.Zero;


        [DllImport("Stocker.dll")]
        private static extern IntPtr lookupTable_new_from_stockTable(IntPtr stockTable);

        [DllImport("Stocker.dll")]
        private static extern IntPtr lookupTable_new_from_unifiedTable(IntPtr unifiedTable);


        [DllImport("Stocker.dll")]
        private static extern IntPtr lookupTable_delete(IntPtr table);


        [DllImport("Stocker.dll")]
        private static extern IntPtr lookupTable_search_new(IntPtr stockTable, [MarshalAs(UnmanagedType.LPStr)] string toSearch);

        public LookupTable(StockCountTable stock)
        {
            table = lookupTable_new_from_stockTable(stock.Ptr());
        }

        public LookupTable(UnifiedTable unified)
        {
            table = lookupTable_new_from_unifiedTable(unified.Ptr());
        }

        public LookupTable()
        {

        }

        ~LookupTable()
        {
            lookupTable_delete(table);
        }

        public LookupTableSearchResult search(string toSearch)
        {
            return new LookupTableSearchResult(lookupTable_search_new(table, toSearch));
        }
    }
}
