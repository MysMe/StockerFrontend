using StockerFrontend.Natives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace StockerFrontend.Other
{
    public class FileFormer
    {

        public static void WriteString(string val, StreamWriter sw)
        {
            sw.WriteLine(val.Length.ToString());
            sw.Write(val);
        }

        public static string ReadString(StreamReader sr)
        {
            int count = int.Parse(sr.ReadLine());
            string ret = "";
            for (int i = 0; i < count; i++)
            {
                ret += (char)sr.Read();
            }
            return ret;
        }

        public static void Form(StreamWriter sw, UnifiedTable unified, List<UnifiedEntry> entries, List<Delivery> deliveries, List<Transfer> transfers)
        {
            WriteString(unified.SaveToString().Get(), sw);

            foreach (var entry in entries)
                entry.SerialiseExtra(sw);

            sw.WriteLine(deliveries.Count.ToString());
            foreach (Delivery del in deliveries)
            {
                del.pack(sw);
            }

            sw.WriteLine(transfers.Count.ToString());
            foreach (Transfer trx in transfers)
            {
                trx.pack(sw);
            }
        }

        public static bool Deform(StreamReader sr, out UnifiedTable table, out List<UnifiedEntry> entryAdditional,
            out List<Delivery> deliveries, out List<Transfer> transfers)
        {
            deliveries = new List<Delivery>();
            transfers = new List<Transfer>();
            table = new UnifiedTable();
            entryAdditional = new List<UnifiedEntry>();

            if (!table.LoadFromString(ReadString(sr)))
                return false;

            for (uint i = 0; i < table.Count(); i++)
            {
                entryAdditional.Add(UnifiedEntry.DeserialiseExtra(sr));
            }

            int count = int.Parse(sr.ReadLine());
            for (int i = 0; i < count; i++)
            {
                deliveries.Add(Delivery.unpack(sr));
            }

            count = int.Parse(sr.ReadLine());
            for (int i = 0; i < count; i++)
            {
                transfers.Add(Transfer.unpack(sr));
            }
            return true;
        }
    }
}
