using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.UserActivity
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Powiązanie z użytkownikiem
        public User User { get; set; }

        public int? TicketId { get; set; } // Powiązanie ze zgłoszeniem
        public Ticket Ticket { get; set; }

        public DateTime StartTime { get; set; } // Czas rozpoczęcia aktywności
        public DateTime? EndTime { get; set; } // Czas zakończenia aktywności (opcjonalne)
        public string ActivityType { get; set; } // Typ aktywności np. "Rozpoczęcie pracy"

    }
}
