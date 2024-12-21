using CerbDesk.API.Data;
using CerbDesk.API.Models;
using CerbDesk.API.Models.Tagging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CerbDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TagsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/tags
        [HttpGet]
        public async Task<IActionResult> GetTags()
        {
            var tags = await _context.Tags.ToListAsync();
            return Ok(tags);
        }

        // POST: api/tags
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTags), new { id = tag.Id }, tag);
        }

        // DELETE: api/tags/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
                return NotFound();

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
