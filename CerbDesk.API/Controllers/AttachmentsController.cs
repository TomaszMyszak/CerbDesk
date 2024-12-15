using CerbDesk.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CerbDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly AttachmentService _attachmentService;

        public AttachmentsController(AttachmentService attachmentService)
        {
            _attachmentService = attachmentService;
        }

        // Endpoint do uploadu plików
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromQuery] int ticketId)
        {
            try
            {
                var attachment = await _attachmentService.UploadFileAsync(file, ticketId);
                return Ok(new
                {
                    attachment.Id,
                    attachment.FileName,
                    attachment.FileSize,
                    attachment.CreatedAt
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Endpoint do pobierania plików
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            try
            {
                var (fileData, mimeType, fileName) = await _attachmentService.DownloadFileAsync(id);
                return File(fileData, mimeType, fileName);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
