using StockerFrontend.Natives;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void pack(StreamWriter sw)
        {
            sw.WriteLine(products.Count.ToString());
            foreach (int i in products)
                sw.WriteLine(i.ToString());

            sw.WriteLine(deltas.Count.ToString());
            foreach (float f in deltas)
                sw.WriteLine(f.ToString());

            FileFormer.WriteString(destination, sw);
            FileFormer.WriteString(date, sw);
        }

        public static Transfer unpack(StreamReader sr)
        {
            Transfer ret = new Transfer();
            int count = int.Parse(sr.ReadLine());
            for (int i = 0; i < count; i++)
                ret.products.Add(int.Parse(sr.ReadLine()));

            count = int.Parse(sr.ReadLine());
            for (int i = 0; i < count; i++)
                ret.deltas.Add(float.Parse(sr.ReadLine()));

            ret.destination = FileFormer.ReadString(sr);
            ret.date = FileFormer.ReadString(sr);

            return ret;
        }

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
