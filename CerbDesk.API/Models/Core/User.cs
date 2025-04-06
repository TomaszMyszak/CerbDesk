using System.Collections.Generic;

namespace CerbDesk.API.Models.Core
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string PasswordHash { get; set; } = string.Empty;


        // Nawigacja do Analytics
        public ICollection<Analytics> Analytics { get; set; } = new List<Analytics>();

        // Inne relacje
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
