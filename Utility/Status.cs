using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Utility
{
    enum StatusType
    {
        Unassigned,
        Confirmed,
        Recount,
        Critical
    };
    internal class StatusTracker
    {
        private Dictionary<uint, StatusType> statuses = new Dictionary<uint, StatusType>();

        public bool HasStatus(uint Index)
        {
            return statuses.ContainsKey(Index);
        }

        public StatusType GetStatus(uint Index)
        {
           if (HasStatus(Index))
                return statuses[Index];
            return StatusType.Unassigned;
        }

        public void SetStatus(uint Index, StatusType status)
        {
            statuses[Index] = status;
        }
    }
}
