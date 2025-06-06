using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CerbDesk.API.Models.Core;


namespace CerbDesk.API.Models.Core
{
    public class Comment
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } // Relacja do tabeli Tickets
        public int UserId { get; set; }
        public User User { get; set; } // Relacja do tabeli Users
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}