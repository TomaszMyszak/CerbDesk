using CerbDesk.API.Data;
using CerbDesk.API.Models.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CerbDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnalyticsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/analytics
        [HttpGet]
        public async Task<IActionResult> GetAnalyticsWithDetails()
        {
            var analytics = await _context.Analytics
                .Include(a => a.User) // Relacja z użytkownikiem (jeśli istnieje)
                .ToListAsync();

            return Ok(analytics);
        }

        // POST: api/analytics
        [HttpPost]
        public IActionResult CreateAnalytics([FromBody] Analytics analytics)
        {
            _context.Analytics.Add(analytics); // Poprawne użycie Add
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAnalytics), new { id = analytics.Id }, analytics);
        }
    }
}
