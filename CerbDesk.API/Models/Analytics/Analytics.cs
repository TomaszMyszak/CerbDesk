using System;

namespace CerbDesk.API.Models.Core
{
    public class Analytics
    {
        public int Id { get; set; }
        public required string MetricName { get; set; } // Nazwa metryki np. "Średni czas rozwiązania"
        public double MetricValue { get; set; } // Wartość metryki
        public required string DateRange { get; set; } // Zakres dat np. "2024-01-01 to 2024-01-31"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data wygenerowania statystyk

        // Relacja z użytkownikiem (jeśli wymagana)
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
