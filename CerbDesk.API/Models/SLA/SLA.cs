using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.Core
{
    public class SLA
    {
        public int Id { get; set; }
        public string Name { get; set; } // Nazwa SLA np. "Wysoki priorytet"
        public int ResponseTime { get; set; } // Czas odpowiedzi w minutach
        public int ResolutionTime { get; set; } // Czas rozwiązania w minutach

        public ICollection<Ticket> Tickets { get; set; } // Zgłoszenia związane z tym SLA
    }

}
