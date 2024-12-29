using CerbDesk.API.Data;
using CerbDesk.API.Models.Core;
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
        public async Task<IActionResult> GetSLAs()
        {
            var slas = await _context.SLAs.ToListAsync();
            return Ok(slas);
        }

        // POST: api/slas
        [HttpPost]
        public async Task<IActionResult> CreateSLA([FromBody] SLA sla)
        {
            _context.SLAs.Add(sla);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSLAs), new { id = sla.Id }, sla);
        }
    }
}
