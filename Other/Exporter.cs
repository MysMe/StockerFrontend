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

        public enum Mode
        {
            None        = 0,
            Ordered     = 0b000000,
            Categorised = 0b000001,
            Normal      = 0b000010,
            Confirmed   = 0b000100,
            Recount     = 0b001000,
            Critical    = 0b010000,
            Transfers   = 0b100000
        }

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

        private static bool ModeIncludes(UnifiedEntry.status status, Mode mode)
        {
            switch(status)
            {
                case UnifiedEntry.status.normal:
                    return (mode & Mode.Normal) != 0;
                case UnifiedEntry.status.confirmed:
                    return (mode & Mode.Confirmed) != 0;
                case UnifiedEntry.status.recount:
                    return (mode & Mode.Recount) != 0;
                case UnifiedEntry.status.critical:
                    return (mode & Mode.Critical) != 0;
                default:
                    return false;
            }
        }

        private static void ExportOrdered(List<UnifiedEntry> entries, StringBuilder sb, Mode mode)
        {
            foreach (UnifiedEntry entry in entries)
            {
                if (ModeIncludes(entry.Status, mode))
                    AppendEntry(entry, sb);
            }
        }

        //Adds the header before the first element if any are added
        //Does not add the header otherwise
        //The header will automatically include the product table header
        private static void ExportMatching(List<UnifiedEntry> entries, UnifiedEntry.status status, StringBuilder sb, string header)
        {
            bool hasWrittenHeader = false;
            foreach (UnifiedEntry entry in entries)
            {
                if (entry.Status == status)
                {
                    if (!hasWrittenHeader)
                    {
                        sb.AppendLine(header);
                        AppendHeader(sb);
                        hasWrittenHeader = true;
                    }
                    AppendEntry(entry, sb);
                }
            }
        }

        private static void ExportCategorised(List<UnifiedEntry> entries, StringBuilder sb, Mode mode)
        {
            if (ModeIncludes(UnifiedEntry.status.critical, mode))
                ExportMatching(entries, UnifiedEntry.status.critical, sb, "Critical products:");

            if (ModeIncludes(UnifiedEntry.status.recount, mode))
                ExportMatching(entries, UnifiedEntry.status.recount, sb, "Recounted products:");

            if (ModeIncludes(UnifiedEntry.status.confirmed, mode))
                ExportMatching(entries, UnifiedEntry.status.confirmed, sb, "Confirmed products:");

            if (ModeIncludes(UnifiedEntry.status.normal, mode))
                ExportMatching(entries, UnifiedEntry.status.normal, sb, "Normal products:");
        }

        private static void ExportTransfers(List<UnifiedEntry> entries, List<Delivery> deliveries, List<Transfer> transfers, StringBuilder sb)
        {
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

        }

        public static string Export(List<UnifiedEntry> entries, List<Delivery> deliveries, List<Transfer> transfers, Mode mode)
        {

            StringBuilder sb = new StringBuilder();

            if ((Mode.Categorised & mode) != 0)
            {
                ExportCategorised(entries, sb, mode);
            }
            else
            {
                ExportOrdered(entries, sb, mode);
            }

            if ((Mode.Transfers & mode) != 0)
            {
                ExportTransfers(entries, deliveries, transfers, sb);
            }

            return sb.ToString();
        }
    }
}
