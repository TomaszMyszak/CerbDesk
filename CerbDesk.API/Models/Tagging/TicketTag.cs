using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.Tagging
{
    public class TicketTag
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } // Powiązanie ze zgłoszeniem

        public int TagId { get; set; }
        public Tag Tag { get; set; } // Powiązanie z tagiem
    }
}
