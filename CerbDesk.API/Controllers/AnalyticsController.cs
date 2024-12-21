using CerbDesk.API.Data;
using CerbDesk.API.Models.Core;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAnalytics()
        {
            var analytics = _context.Analytics.ToList(); // Poprawne użycie ToList
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
