using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerbDesk.API.Models.Tagging
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } // Nazwa tagu np. "Sieć", "Komputer"
        public ICollection<TicketTag> TicketTags { get; set; } // Relacja wiele-do-wielu
    }
}
