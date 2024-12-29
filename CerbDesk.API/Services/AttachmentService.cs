using CerbDesk.API.Data;
using CerbDesk.API.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using CerbDesk.API.Models.Core; // Namespace dla głównych modeli w folderze Core
using CerbDesk.API.Models.Categories;
using CerbDesk.API.Models.Logging;
using CerbDesk.API.Models.Notifications;
using CerbDesk.API.Models.Surveys;
using CerbDesk.API.Models.Tagging;
using CerbDesk.API.Models.UserActivity;
using CerbDesk.API.Models.SLA;


namespace CerbDesk.API.Services
{
    public class AttachmentService
    {
        private readonly AppDbContext _context;
        private readonly string _uploadFolder = "uploads/attachments"; // Folder na pliki

        public AttachmentService(AppDbContext context)
        {
            _context = context;
            Directory.CreateDirectory(_uploadFolder); // Tworzy katalog, jeśli nie istnieje
        }

        // Zapis pliku na serwerze i zapisanie metadanych w bazie
        public async Task<Attachment> UploadFileAsync(IFormFile file, int ticketId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Plik jest pusty.");

            // Tworzenie unikalnej nazwy pliku
            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(_uploadFolder, fileName);

            // Zapis pliku na dysku
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Tworzenie obiektu Attachment
            var attachment = new Attachment
            {
                TicketId = ticketId,
                FileName = file.FileName,
                FilePath = filePath,
                MimeType = file.ContentType,
                FileSize = file.Length,
                CreatedAt = DateTime.UtcNow
            };

            // Zapis do bazy danych
            _context.Attachments.Add(attachment);
            await _context.SaveChangesAsync();

            return attachment;
        }

        // Pobranie pliku po ID
        public async Task<(byte[] FileData, string MimeType, string FileName)> DownloadFileAsync(int attachmentId)
        {
            var attachment = await _context.Attachments.FindAsync(attachmentId);
            if (attachment == null)
                throw new FileNotFoundException("Załącznik nie istnieje.");

            var fileData = await File.ReadAllBytesAsync(attachment.FilePath);
            return (fileData, attachment.MimeType, attachment.FileName);
        }
    }
}
