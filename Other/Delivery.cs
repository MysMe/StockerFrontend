using StockerFrontend.Natives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Other
{
    public class Delivery
    {
        public List<int> products = new List<int>();
        public List<float> deltas = new List<float>();
        public string supplier = "";
        public string invoice = "";
        public string date = "";


        public void pack(StreamWriter sw)
        {
            sw.WriteLine(products.Count.ToString());
            foreach (int i in products)
                sw.WriteLine(i.ToString());

            sw.WriteLine(deltas.Count.ToString());
            foreach (float f in deltas)
                sw.WriteLine(f.ToString());

            FileFormer.WriteString(supplier, sw);
            FileFormer.WriteString(invoice, sw);
            FileFormer.WriteString(date, sw);
        }

        public static Delivery? unpack(StreamReader sr)
        {
            Delivery ret = new Delivery();
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
            ret.supplier = line;

            line = FileFormer.ReadString(sr);
            if (line == null)
                return null;
            ret.invoice = line;

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
                entries[products[i]].Delivered += deltas[i];
            }
        }

        public void Remove(List<UnifiedEntry> entries)
        {
            for (int i = 0; i < products.Count; i++)
            {
                entries[products[i]].Delivered -= deltas[i];
            }
        }
    }
}
