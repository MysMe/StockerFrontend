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

        public class FileData
        {
            public UnifiedTable table = new UnifiedTable();
            public List<UnifiedEntry> entries = new List<UnifiedEntry>();
            public List<Delivery> deliveries = new List<Delivery>();
            public List<Transfer> transfers = new List<Transfer>();
        }

        public static FileData? Deform(StreamReader sr)
        {
            FileData ret = new FileData();

            ret.table.LoadFromString(ReadString(sr));

            int count = int.Parse(sr.ReadLine());
            for (int i = 0; i < count; i++)
            {
                ret.deliveries.Add(Delivery.unpack(sr));
            }

            count = int.Parse(sr.ReadLine());
            for (int i = 0; i < count; i++)
            {
                ret.transfers.Add(Transfer.unpack(sr));
            }

            return ret;
        }
    }
}
