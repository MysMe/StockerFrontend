using StockerFrontend.Natives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Other
{
    public class Transfer
    {
        public List<int> products = new List<int>();
        public List<float> deltas = new List<float>();
        public string destination = "";
        public string date = "";

        public void Apply(List<UnifiedEntry> entries)
        {
            for (int i = 0; i < products.Count; i++)
            {
                entries[products[i]].Transferred += deltas[i];
            }
        }

        public void Remove(List<UnifiedEntry> entries)
        {
            for (int i = 0; i < products.Count; i++)
            {
                entries[products[i]].Transferred -= deltas[i];
            }
        }
    }
}
