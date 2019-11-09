using DriverTracking.DbContexts;
using DriverTracking.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriverTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitationRecordsController : ControllerBase
    {
        private readonly DriverTrackingContext _context;

        public CitationRecordsController(DriverTrackingContext context)
        {
            _context = context;
        }

        // GET: api/CitationRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitationRecords>>> GetCitationRecords()
        {
            return await _context.CitationRecords.ToListAsync();
        }

        // GET: api/CitationRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CitationRecords>> GetCitationRecords(Guid id)
        {
            var citationRecords = await _context.CitationRecords.FindAsync(id);

            if (citationRecords == null)
            {
                return NotFound();
            }

            return citationRecords;
        }

        // PUT: api/CitationRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitationRecords(Guid id, CitationRecords citationRecords)
        {
            if (id != citationRecords.Id)
            {
                return BadRequest();
            }

            _context.Entry(citationRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitationRecordsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CitationRecords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CitationRecords>> PostCitationRecords(CitationRecords citationRecords)
        {
            _context.CitationRecords.Add(citationRecords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitationRecords", new { id = citationRecords.Id }, citationRecords);
        }

        // DELETE: api/CitationRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CitationRecords>> DeleteCitationRecords(Guid id)
        {
            var citationRecords = await _context.CitationRecords.FindAsync(id);
            if (citationRecords == null)
            {
                return NotFound();
            }

            _context.CitationRecords.Remove(citationRecords);
            await _context.SaveChangesAsync();

            return citationRecords;
        }

        private bool CitationRecordsExists(Guid id)
        {
            return _context.CitationRecords.Any(e => e.Id == id);
        }
    }
}