using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CerbDesk.API.Models.Categories;
using CerbDesk.API.Models.Core;
using CerbDesk.API.Models.SLA;

namespace CerbDesk.API.Models.Core
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } // Relacja do tabeli Users
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; } = "Open";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? CategoryId { get; set; } // Opcjonalna kategoria zg�oszenia
        public Category Category { get; set; } // Nawigacja do kategorii
        public int? SLAId { get; set; } // Powi�zanie ze SLA
        public SLA.SLA SLA { get; set; } // U�ycie aliasu // Nawigacja do SLA
        public object TicketTags { get; internal set; }
        public object Comments { get; internal set; }
        public object Attachments { get; internal set; }
    }

}