using Microsoft.EntityFrameworkCore;
using CerbDesk.API.Models.Core; // Dla Ticket w folderze Core
using CerbDesk.API.Models.Categories;
using CerbDesk.API.Models.Logging;
using CerbDesk.API.Models.Notifications;
using CerbDesk.API.Models.Surveys;
using CerbDesk.API.Models.Tagging;
using CerbDesk.API.Models.UserActivity;
using CerbDesk.API.Models.SLA;

namespace CerbDesk.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet dla każdej tabeli w bazie danych
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Attachment> Attachments { get; set; } = null!;
        public DbSet<Analytics> Analytics { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<SLA> SLAs { get; set; } = null!;
        public DbSet<Survey> Surveys { get; set; } = null!;
        public DbSet<SurveyResponse> SurveyResponses { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TicketTag> TicketTags { get; set; } = null!;
        public DbSet<UserActivity> UserActivities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacje i konfiguracje tabel - dodaj szczegóły relacji zgodnie z modelem

            // Relacja: User -> Tickets
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            // Relacja: Ticket -> Comments
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Ticket)
                .HasForeignKey(c => c.TicketId);

            // Relacja: Ticket -> Attachments
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Attachments)
                .WithOne(a => a.Ticket)
                .HasForeignKey(a => a.TicketId);

            // Relacja: Comment -> User
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            // Relacja: Attachment -> User
            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Attachments)
                .HasForeignKey(a => a.UserId);

            // Relacja: SLA -> Tickets
            modelBuilder.Entity<SLA>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.SLA)
                .HasForeignKey(t => t.SLAId);

            // Relacja: Category -> Tickets
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId);

            // Relacja: Survey -> SurveyResponses
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.SurveyResponses)
                .WithOne(r => r.Survey)
                .HasForeignKey(r => r.SurveyId);

            // Relacja: Ticket -> Tags (przez TicketTag)
            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId }); // Klucz główny w tabeli pośredniej
            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Ticket)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TicketId);
            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TagId);

            // Inne konfiguracje...
        }
    }
}
