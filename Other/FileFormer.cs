using StockerFrontend.Natives;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace StockerFrontend.Other
{
    public class FileFormer
    {

        public string Form(List<UnifiedEntry> entries)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UnifiedEntry));

            using (StringWriter textWriter = new StringWriter())
            {
                foreach (var entry in entries)
                {
                    xmlSerializer.Serialize(textWriter, entry);
                }
                return textWriter.ToString();
            }
        }

        public List<UnifiedEntry> Deform(string contents)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UnifiedEntry));
            using (StringReader textReader = new StringReader(contents))
            {
                List<UnifiedEntry> entries = new List<UnifiedEntry>();

                while (true)
                {
                    object? obj = xmlSerializer.Deserialize(textReader);
                    if (obj == null)
                        return entries;
                    entries.Add((UnifiedEntry)obj);
                }
                return entries;
            }
        }
    }
}
