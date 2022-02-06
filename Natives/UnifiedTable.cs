using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    class OutstandingTranslation
    {
        public uint UnifiedIndex = 0;
        public uint CountIndex = 0;
    }

    class UnifiedEntry
    {
        public String Name = "";
        public float Count = 0;
        public float Variance = 0;
    }

    internal class UnifiedTable
    {

        [DllImport("Stocker.dll")]
        private static extern IntPtr unifiedTable_new();

        [DllImport("Stocker.dll")]
        private static extern void unifiedTable_delete(IntPtr table);



        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_loadTranslations(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);

        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_saveTranslations(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);



        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_ready(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_getOutstandingCount(IntPtr table);

        [DllImport("Stocker.dll")] //Returns a const pointer
        private static extern IntPtr unifiedTable_getTranslation(IntPtr table, uint index);

        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_provideTranslation(IntPtr table, uint index, float ratio, IntPtr stockTable);

        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_applyTranslations(IntPtr table, IntPtr stockTable);



        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_entryCount(IntPtr table);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr unifiedTable_getName(IntPtr table);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr unifiedTable_getSize(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern float unifiedTable_getCount(IntPtr table, uint index);

        private IntPtr table = IntPtr.Zero;

        public UnifiedTable()
        {
            table = unifiedTable_new();
        }

        ~UnifiedTable()
        {
            unifiedTable_delete(table);
        }

    }
}
