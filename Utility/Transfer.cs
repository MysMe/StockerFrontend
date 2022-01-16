using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Utility
{
    internal class Transfer
    {
        public class TransferEntry
        {
            public uint EntryIndex = 0;
            public float Quantity = 0;
        }
        public String Destination = "";
        public List<TransferEntry> Entries = new List<TransferEntry>();
    }
}
