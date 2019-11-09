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
    public class HardBreakRecordsController : ControllerBase
    {
        private readonly DriverTrackingContext _context;

        public HardBreakRecordsController(DriverTrackingContext context)
        {
            _context = context;
        }

        // GET: api/HardBreakRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardBreakRecords>>> GetHardBreakRecords()
        {
            return await _context.HardBreakRecords.ToListAsync();
        }

        // GET: api/HardBreakRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HardBreakRecords>> GetHardBreakRecords(Guid id)
        {
            var hardBreakRecords = await _context.HardBreakRecords.FindAsync(id);

            if (hardBreakRecords == null)
            {
                return NotFound();
            }

            return hardBreakRecords;
        }

        // PUT: api/HardBreakRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHardBreakRecords(Guid id, HardBreakRecords hardBreakRecords)
        {
            if (id != hardBreakRecords.Id)
            {
                return BadRequest();
            }

            _context.Entry(hardBreakRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HardBreakRecordsExists(id))
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

        // POST: api/HardBreakRecords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HardBreakRecords>> PostHardBreakRecords(HardBreakRecords hardBreakRecords)
        {
            _context.HardBreakRecords.Add(hardBreakRecords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHardBreakRecords", new { id = hardBreakRecords.Id }, hardBreakRecords);
        }

        // DELETE: api/HardBreakRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HardBreakRecords>> DeleteHardBreakRecords(Guid id)
        {
            var hardBreakRecords = await _context.HardBreakRecords.FindAsync(id);
            if (hardBreakRecords == null)
            {
                return NotFound();
            }

            _context.HardBreakRecords.Remove(hardBreakRecords);
            await _context.SaveChangesAsync();

            return hardBreakRecords;
        }

        private bool HardBreakRecordsExists(Guid id)
        {
            return _context.HardBreakRecords.Any(e => e.Id == id);
        }
    }
}