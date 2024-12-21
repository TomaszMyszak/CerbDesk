using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CerbDesk.API.Models.Categories;
using CerbDesk.API.Models.Core;
using SLA_Core = CerbDesk.API.Models.Core; // Alias dla przestrzeni nazw

namespace CerbDesk.API.Models
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

        public int? CategoryId { get; set; } // Opcjonalna kategoria zg³oszenia
        public Category Category { get; set; } // Nawigacja do kategorii
        public int? SLAId { get; set; } // Powi¹zanie ze SLA
        public SLA_Core.SLA SLA { get; set; } // U¿ycie aliasu // Nawigacja do SLA
    }

}