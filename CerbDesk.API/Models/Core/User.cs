using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CerbDesk.API.Models.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public object Tickets { get; internal set; }
        public object Comments { get; internal set; }
        public object Attachments { get; internal set; }
    }
}