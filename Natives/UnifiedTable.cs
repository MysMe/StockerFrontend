using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    public class OutstandingTranslation
    {
        public uint UnifiedIndex = 0;
        public uint CountIndex = 0;
    }

    public class UnifiedEntry
    {
        public String Name = "";
        public float Count = 0;
        public float Variance = 0;
    }

    public class UnifiedTable
    {

        [DllImport("Stocker.dll")]
        private static extern IntPtr unifiedTable_new();

        [DllImport("Stocker.dll")]
        private static extern void unifiedTable_delete(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern int unifiedTable_load(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string XLS, IntPtr count);



        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_loadTranslations(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);

        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_saveTranslations(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);



        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_ready(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_getOutstandingCount(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_getTranslationUnifiedIndex(IntPtr table, uint index);
        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_getTranslationUnmatchedIndex(IntPtr table, uint index);

        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_provideTranslation(IntPtr table, uint index, float ratio, IntPtr stockTable);

        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_applyTranslations(IntPtr table, IntPtr stockTable);



        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_entryCount(IntPtr table);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr unifiedTable_getName(IntPtr table, uint index);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr unifiedTable_getSize(IntPtr table, uint index);

        [DllImport("Stocker.dll")]
        private static extern float unifiedTable_getCount(IntPtr table, uint index);

        private IntPtr table = IntPtr.Zero;

        public UnifiedTable()
        {
            table = unifiedTable_new();
        }

        public int load(string XLSSource, StockCountTable count)
        {
            return unifiedTable_load(table, XLSSource, count.Ptr());
        }

        public string GetNameSize(uint index)
        {
            return Marshal.PtrToStringAnsi(unifiedTable_getName(table, index)) +
                Marshal.PtrToStringAnsi(unifiedTable_getSize(table, index));
        }

        public bool ProvideTranslation(uint index, float ratio, IntPtr stockTable)
        {
            return unifiedTable_provideTranslation(table, index, ratio, stockTable);
        }

        public bool Ready()
        {
            return unifiedTable_ready(table);
        }

        public OutstandingTranslation GetTranslation(uint index)
        {
            OutstandingTranslation ret = new OutstandingTranslation();
            ret.UnifiedIndex = unifiedTable_getTranslationUnifiedIndex(table, index);
            ret.CountIndex = unifiedTable_getTranslationUnmatchedIndex(table, index);
            return ret;
        }

        ~UnifiedTable()
        {
            unifiedTable_delete(table);
        }

    }
}
