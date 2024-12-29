using System;
using CerbDesk.API.Models.Core;
using CerbDesk.API.Models.Tagging;


namespace CerbDesk.API.Models.Core
{
    public class Attachment
    {

        public int Id { get; set; } // Identyfikator załącznika
        public int TicketId { get; set; } // Powiązanie ze zgłoszeniem
        public required string FileName { get; set; } // Nazwa pliku
        public required string FilePath { get; set; } // Ścieżka do pliku na serwerze
        public required string MimeType { get; set; } // Typ MIME pliku (np. image/png, application/pdf)
        public long FileSize { get; set; } // Rozmiar pliku w bajtach
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Data utworzenia pliku

        // Relacja do zgłoszenia (Ticket)
        public Ticket Tickets { get; set; }
    }
}
