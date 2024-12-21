using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.Logging
{
    public class Log
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Powiązanie z użytkownikiem
        public string Action { get; set; } // Opis akcji np. "Dodano zgłoszenie"
        public string Entity { get; set; } // Typ encji np. "Ticket", "Comment"
        public int? EntityId { get; set; } // Identyfikator encji
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Czas akcji

        public User User { get; set; } // Nawigacja do użytkownika
    }

}
