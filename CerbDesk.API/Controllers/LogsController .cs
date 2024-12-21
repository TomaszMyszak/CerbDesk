using CerbDesk.API.Data;
using CerbDesk.API.Models;
using CerbDesk.API.Models.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CerbDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/logs
        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            var logs = await _context.Logs.Include(l => l.User).ToListAsync();
            return Ok(logs);
        }

        // POST: api/logs
        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] Log log)
        {
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLogs), new { id = log.Id }, log);
        }
    }
}
