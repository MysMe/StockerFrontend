using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Utility
{
    internal class Information
    {
        public StatusTracker statusTracker = new StatusTracker();
        public List<Delivery> deliveries = new List<Delivery>();
        public List<Transfer> transfers = new List<Transfer>();
        public NoteTracker notes = new NoteTracker();
    }

    class InformationTracker
    {
        private static Information Information = new Information();

        public static Information Get()
        {
            return Information;
        }
    }
}
