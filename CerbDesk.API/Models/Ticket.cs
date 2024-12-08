using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
}
    }
}