using Microsoft.EntityFrameworkCore;
using CerbDesk.API.Models;

namespace CerbDesk.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Comment> Comments { get; set; }
     public DbSet<Attachment> Attachments { get; set; } // Dodanie DbSet dla załączników
    }
}
