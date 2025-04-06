using System;
using System.Collections.Generic;
using CerbDesk.API.Models.Categories;
using CerbDesk.API.Models.SLA; // Namespace SLA
using CerbDesk.API.Models.Core;
using CerbDesk.API.Models.Tagging; // Namespace Core

namespace CerbDesk.API.Models.Core
{
    public class Ticket
    {
        public int Id { get; set; }

        // Relacja do tabeli Users
        public int UserId { get; set; }
        public User User { get; set; }

        // G³ówne pola zg³oszenia
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; } = "Open";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relacja do kategorii (opcjonalna)
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        // Relacja do SLA (opcjonalna)
        public int? SLAId { get; set; }
        public SLA.SLA SLA { get; set; }

        // Nawigacja do komentarzy
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        // Nawigacja do za³¹czników
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

        // Relacja do tagów zg³oszenia
        public ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
    }
}
