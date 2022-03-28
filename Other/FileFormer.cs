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

        public static string? ReadString(StreamReader sr)
        {
            string? line = sr.ReadLine();
            if (line == null)
                return null;
            int count = int.Parse(line);
            string ret = "";
            for (int i = 0; i < count; i++)
            {
                int next = sr.Read();
                if (next == -1)
                    return null;
                ret += (char)next;
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

            string? line;

            line = ReadString(sr);
            if (line == null)
                return false;

            if (!table.LoadFromString(line))
                return false;

            for (uint i = 0; i < table.Count(); i++)
            {
                UnifiedEntry? entry = UnifiedEntry.DeserialiseExtra(sr);
                if (entry == null)
                    return false;
                entryAdditional.Add(entry);
            }

            line = sr.ReadLine();
            if (line == null)
                return false;
            int count = int.Parse(line);

            for (int i = 0; i < count; i++)
            {
                Delivery? delivery = Delivery.unpack(sr);
                if (delivery == null)
                    return false;
                deliveries.Add(delivery);
            }

            line = sr.ReadLine();
            if (line == null)
                return false;
            count = int.Parse(line);

            for (int i = 0; i < count; i++)
            {
                Transfer? transfer = Transfer.unpack(sr);
                if (transfer == null)
                    return false;
                transfers.Add(transfer);
            }
            return true;
        }
    }
}
