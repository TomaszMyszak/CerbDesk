using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.Notifications
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Użytkownik, który otrzyma powiadomienie
        public User User { get; set; } // Nawigacja do użytkownika

        public int? TicketId { get; set; } // Powiązane zgłoszenie (opcjonalne)
        public Ticket Ticket { get; set; }

        public string Message { get; set; } // Treść powiadomienia
        public string Status { get; set; } = "Pending"; // Status powiadomienia (np. Pending, Sent)
        public DateTime? SentAt { get; set; } // Data wysłania
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data utworzenia

    }
}
