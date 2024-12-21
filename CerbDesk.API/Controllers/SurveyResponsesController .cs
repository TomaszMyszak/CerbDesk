using CerbDesk.API.Data;
using CerbDesk.API.Models;
using CerbDesk.API.Models.Surveys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CerbDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyResponsesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SurveyResponsesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/surveyresponses
        [HttpGet]
        public async Task<IActionResult> GetSurveyResponses()
        {
            var responses = await _context.SurveyResponses
                .Include(sr => sr.Survey)
                .Include(sr => sr.User)
                .Include(sr => sr.Ticket)
                .ToListAsync();
            return Ok(responses);
        }

        // POST: api/surveyresponses
        [HttpPost]
        public async Task<IActionResult> CreateSurveyResponse([FromBody] SurveyResponse response)
        {
            _context.SurveyResponses.Add(response);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSurveyResponses), new { id = response.Id }, response);
        }
    }
}
