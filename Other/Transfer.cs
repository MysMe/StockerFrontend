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

        public static Transfer? unpack(StreamReader sr)
        {
            Transfer ret = new Transfer();

            string? line;

            line = sr.ReadLine();
            if (line == null)
                return null;
            int count = int.Parse(line);

            for (int i = 0; i < count; i++)
            {
                line = sr.ReadLine();
                if (line == null)
                    return null;
                ret.products.Add(int.Parse(line));
            }

            line = sr.ReadLine();
            if (line == null)
                return null;
            count = int.Parse(line);

            for (int i = 0; i < count; i++)
            {
                line = sr.ReadLine();
                if (line == null)
                    return null;
                ret.deltas.Add(float.Parse(line));
            }

            line = FileFormer.ReadString(sr);
            if (line == null)
                return null;
            ret.destination = line;
            line = FileFormer.ReadString(sr);
            if (line == null)
                return null;
            ret.date = line;

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
