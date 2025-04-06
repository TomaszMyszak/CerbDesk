using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.SLA
{
    public class SLA
    {
        public int Id { get; set; }
        public required string Name { get; set; } // Nazwa SLA np. "Wysoki priorytet"
        public int ResponseTime { get; set; } // Czas odpowiedzi w minutach
        public int ResolutionTime { get; set; } // Czas rozwiązania w minutach

        // Powiązane zgłoszenia
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
