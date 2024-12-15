using System;

namespace CerbDesk.API.Models
{
    public class Attachment
    {
        public int Id { get; set; } // Identyfikator załącznika
        public int TicketId { get; set; } // Powiązanie ze zgłoszeniem
        public string FileName { get; set; } // Nazwa pliku
        public string FilePath { get; set; } // Ścieżka do pliku na serwerze
        public string MimeType { get; set; } // Typ MIME pliku (np. image/png, application/pdf)
        public long FileSize { get; set; } // Rozmiar pliku w bajtach
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data utworzenia pliku

        // Relacja do zgłoszenia (Ticket)
        public Ticket Ticket { get; set; }
    }
}