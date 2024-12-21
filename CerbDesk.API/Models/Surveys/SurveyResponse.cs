using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.Surveys
{
    public class SurveyResponse
    {
        public int Id { get; set; }
        public int SurveyId { get; set; } // Powiązanie z ankietą
        public Survey Survey { get; set; }

        public int TicketId { get; set; } // Powiązanie ze zgłoszeniem
        public Ticket Ticket { get; set; }

        public int UserId { get; set; } // Powiązanie z użytkownikiem
        public User User { get; set; }

        public int Rating { get; set; } // Ocena np. w skali 1-5
        public string? Comment { get; set; } // Opcjonalny komentarz użytkownika
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data odpowiedzi

    }
}
