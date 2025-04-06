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
        public async Task<IActionResult> GetAnalytics()
        {
            var analytics = await _context.Analytics.ToListAsync();
            return Ok(analytics);
        }

        // GET: api/analytics/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnalyticsWithDetails(int id)
        {
            var analytics = await _context.Analytics
                .Include(a => a.User) // Relacja z użytkownikiem (jeśli istnieje)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (analytics == null)
                return NotFound();

            return Ok(analytics);
        }

        // POST: api/analytics
        [HttpPost]
        public async Task<IActionResult> CreateAnalytics([FromBody] Analytics analytics)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Analytics.Add(analytics); // Dodanie Analytics do bazy danych
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnalyticsWithDetails), new { id = analytics.Id }, analytics);
        }

        // PUT: api/analytics/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnalytics(int id, [FromBody] Analytics analytics)
        {
            if (id != analytics.Id)
                return BadRequest();

            _context.Entry(analytics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Analytics.Any(a => a.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/analytics/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalytics(int id)
        {
            var analytics = await _context.Analytics.FindAsync(id);
            if (analytics == null)
                return NotFound();

            _context.Analytics.Remove(analytics);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
