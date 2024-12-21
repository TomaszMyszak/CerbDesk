using CerbDesk.API.Data;
using CerbDesk.API.Models;
using CerbDesk.API.Models.Surveys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CerbDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SurveysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/surveys
        [HttpGet]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _context.Surveys.ToListAsync();
            return Ok(surveys);
        }

        // POST: api/surveys
        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] Survey survey)
        {
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSurveys), new { id = survey.Id }, survey);
        }
    }
}
