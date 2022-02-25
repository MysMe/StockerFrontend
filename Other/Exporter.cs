using StockerFrontend.Natives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Other
{
    public class Exporter
    {
        private static void AppendHeader(StringBuilder sb)
        {
            sb.AppendLine("Product Name,Size,Count,Variance,Notes");
        }

        private static void AppendEntry(UnifiedEntry entry, StringBuilder sb)
        {
            sb.Append(entry.Name);
            sb.Append(',');
            sb.Append(entry.Size);
            sb.Append(',');
            sb.Append(entry.GetCount());
            sb.Append(',');
            sb.Append(entry.GetVariance());
            if(entry.notes.Length > 0)
            {
                sb.Append(",\"");
                sb.Append(entry.notes);
                sb.Append("\"");
            }
            sb.AppendLine("");
        }

        private static void AppendDelivery(Delivery del, StringBuilder sb, List<UnifiedEntry> entries)
        {
            sb.Append("Delivery from: ");
            sb.AppendLine(del.supplier);
            sb.Append("Invoice: ");
            sb.AppendLine(del.invoice);
            sb.Append("Date delivered: ");
            sb.AppendLine(del.date);

            sb.AppendLine("Product, Size, Quantity delivered");
            for (int i = 0; i < del.products.Count; i++)
            {
                sb.Append(entries[del.products[i]].Name);
                sb.Append(',');
                sb.Append(entries[del.products[i]].Size);
                sb.Append(',');
                sb.AppendLine(del.deltas[i].ToString());
            }
            sb.AppendLine("");
        }

        private static void AppendTransfer(Transfer trx, StringBuilder sb, List<UnifiedEntry> entries)
        {
            sb.Append("Transferred to: ");
            sb.AppendLine(trx.destination);
            sb.Append("Date transferred: ");
            sb.AppendLine(trx.date);

            sb.AppendLine("Product, Size, Quantity transferred");
            for (int i = 0; i < trx.products.Count; i++)
            {
                sb.Append(entries[trx.products[i]].Name);
                sb.Append(',');
                sb.Append(entries[trx.products[i]].Size);
                sb.Append(',');
                sb.AppendLine(trx.deltas[i].ToString());
            }
            sb.AppendLine("");
        }

        public static string Export(List<UnifiedEntry> entries, List<Delivery> deliveries, List<Transfer> transfers)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Stock Count Report:");

            bool hasbrittenCriticalHeader = false;
            foreach (UnifiedEntry entry in entries)
            {
                if (entry.Status == UnifiedEntry.status.critical)
                {
                    if (!hasbrittenCriticalHeader)
                    {
                        sb.AppendLine("Critical products:");
                        AppendHeader(sb);
                        hasbrittenCriticalHeader = true;
                    }
                    AppendEntry(entry, sb);
                }
            }

            bool hasbrittenRecountHeader = false;
            foreach (UnifiedEntry entry in entries)
            {
                if (entry.Status == UnifiedEntry.status.recount)
                {
                    if (!hasbrittenRecountHeader)
                    {
                        sb.AppendLine("Products due recount:");
                        AppendHeader(sb);
                        hasbrittenRecountHeader = true;
                    }
                    AppendEntry(entry, sb);
                }
            }

            bool hasbrittenConfirmedHeader = false;
            foreach (UnifiedEntry entry in entries)
            {
                if (entry.Status == UnifiedEntry.status.confirmed ||
                    entry.Status == UnifiedEntry.status.normal)
                {
                    if (!hasbrittenConfirmedHeader)
                    {
                        sb.AppendLine("Products:");
                        AppendHeader(sb);
                        hasbrittenConfirmedHeader = true;
                    }
                    AppendEntry(entry, sb);
                }
            }

            sb.AppendLine("");

            if (deliveries.Count > 0)
            {
                sb.AppendLine("Deliveries:");
                foreach (Delivery i in deliveries)
                {
                    AppendDelivery(i, sb, entries);
                }
            }

            if (transfers.Count > 0)
            {
                sb.AppendLine("Transfers:");
                foreach (Transfer trx in transfers)
                {
                    AppendTransfer(trx, sb, entries);
                }
            }

            return sb.ToString();
        }
    }
}
