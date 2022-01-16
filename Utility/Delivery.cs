using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Utility
{

    class Delivery
    {
        public class DeliveryEntry
        {
            public uint EntryIndex = 0;
            public float Quantity = 0;
        }
        public String InvoiceNumber = "";
        public List<DeliveryEntry> Entries = new List<DeliveryEntry>();
    }
}
