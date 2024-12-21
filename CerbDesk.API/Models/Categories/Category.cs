using CerbDesk.API.Models.Core;

namespace CerbDesk.API.Models.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } // Nazwa kategorii np. "Infrastruktura"
        public string? Description { get; set; } // Opcjonalny opis kategorii

        public ICollection<Ticket> Tickets { get; set; } // Zgłoszenia w tej kategorii
    }

}
