using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    internal class StockCountTable
    {

        public bool Load(String sourceFile)
        {
            return sourceFile != "";
        }

        public uint Count()
        {
            return 0;
        }

        public int GetCount(uint index)
        {
            return (int)index;
        }

    }
}
