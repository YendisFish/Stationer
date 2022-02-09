using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationer.Types
{
    public class ProgramData
    {
        string? TicketChannelId { get; set; }

        public ProgramData(string TicketChannelId)
        {
            this.TicketChannelId = TicketChannelId;
        }
    }
}
