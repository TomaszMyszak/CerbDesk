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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, [FromBody] Survey survey)
        {
            if (id != survey.Id)
                return BadRequest();

            _context.Entry(survey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Surveys.Any(s => s.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey == null)
                return NotFound();

            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
