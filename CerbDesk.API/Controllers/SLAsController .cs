using CerbDesk.API.Data;
using CerbDesk.API.Models.SLA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CerbDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SLAsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SLAsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/slas
        [HttpGet]
        public async Task<IActionResult> GetSLAsWithTickets()
        {
            var slas = await _context.SLAs
                .Include(s => s.Tickets) // Ładowanie powiązanych Tickets
                .ToListAsync();

            return Ok(slas);
        }

        // GET: api/slas/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSLAById(int id)
        {
            var sla = await _context.SLAs
                .Include(s => s.Tickets) // Ładowanie powiązanych Tickets
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sla == null)
                return NotFound();

            return Ok(sla);
        }

        // POST: api/slas
        [HttpPost]
        public async Task<IActionResult> CreateSLA([FromBody] SLA sla)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.SLAs.Add(sla);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSLAById), new { id = sla.Id }, sla);
        }

        // PUT: api/slas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSLA(int id, [FromBody] SLA sla)
        {
            if (id != sla.Id)
                return BadRequest();

            _context.Entry(sla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.SLAs.Any(s => s.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/slas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSLA(int id)
        {
            var sla = await _context.SLAs.FindAsync(id);
            if (sla == null)
                return NotFound();

            _context.SLAs.Remove(sla);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
