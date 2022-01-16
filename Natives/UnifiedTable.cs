using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    class OutstandingTranslation
    {
        public uint UnifiedIndex = 0;
        public uint CountIndex = 0;
    }

    class UnifiedEntry
    {
        public String Name = "";
        public float Count = 0;
        public float Variance = 0;
    }

    internal class UnifiedTable
    {
        private List<OutstandingTranslation> translations = new List<OutstandingTranslation>();
        private List<UnifiedEntry> unifiedEntries = new List<UnifiedEntry>();

        public UnifiedTable()
        {
            for (int i = 0; i < 5; i++)
                unifiedEntries.Add(new UnifiedEntry());

            for (int i = 0; i < unifiedEntries.Count(); i++)
            {
                unifiedEntries[i].Name = "Product " + i.ToString();
                unifiedEntries[i].Count = i;
                unifiedEntries[i].Variance = i;
            }
            

            translations.Add(new OutstandingTranslation());
            translations.Add(new OutstandingTranslation());
            translations[0].UnifiedIndex = 2;
            translations[1].UnifiedIndex = 4;
        }

        public bool Ready()
        {
            return translations.Count() == 0;
        }

        public uint CountOutstandingTranslations()
        {
            return (uint)translations.Count();
        }

        public OutstandingTranslation GetOutstandingTranslation(uint Index)
        {
            return translations[(int)Index];
        }

        public void ProvideTranslation(uint StockIndex, float ratio, StockCountTable stockCountTable)
        {
            translations.RemoveAt((int)StockIndex);
        }

        public void ApplyTranslations()
        {

        }

        public uint GetSize()
        {
            return (uint)unifiedEntries.Count();
        }

        public UnifiedEntry Get(uint Index)
        {
            return unifiedEntries[(int)Index];
        }
    }
}
