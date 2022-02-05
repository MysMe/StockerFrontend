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

        [DllImport("Stocker.dll")]
        private static extern IntPtr stockTable_new();

        [DllImport("Stocker.dll")]
        private static extern void stockTable_delete(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern int stockTable_import(IntPtr table);

        public bool Load(String sourceFile)
        {
            return sourceFile != "";
        }
    }
}
