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
    public class AccidentReportRecordsController : ControllerBase
    {
        private readonly DriverTrackingContext _context;

        public AccidentReportRecordsController(DriverTrackingContext context)
        {
            _context = context;
        }

        // GET: api/AccidentReportRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccidentReportRecords>>> GetAccidentReportRecords()
        {
            return await _context.AccidentReportRecords.ToListAsync();
        }

        // GET: api/AccidentReportRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccidentReportRecords>> GetAccidentReportRecords(Guid id)
        {
            var accidentReportRecords = await _context.AccidentReportRecords.FindAsync(id);

            if (accidentReportRecords == null)
            {
                return NotFound();
            }

            return accidentReportRecords;
        }

        // PUT: api/AccidentReportRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccidentReportRecords(Guid id, AccidentReportRecords accidentReportRecords)
        {
            if (id != accidentReportRecords.Id)
            {
                return BadRequest();
            }

            _context.Entry(accidentReportRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccidentReportRecordsExists(id))
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

        // POST: api/AccidentReportRecords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AccidentReportRecords>> PostAccidentReportRecords(AccidentReportRecords accidentReportRecords)
        {
            _context.AccidentReportRecords.Add(accidentReportRecords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccidentReportRecords", new { id = accidentReportRecords.Id }, accidentReportRecords);
        }

        // DELETE: api/AccidentReportRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccidentReportRecords>> DeleteAccidentReportRecords(Guid id)
        {
            var accidentReportRecords = await _context.AccidentReportRecords.FindAsync(id);
            if (accidentReportRecords == null)
            {
                return NotFound();
            }

            _context.AccidentReportRecords.Remove(accidentReportRecords);
            await _context.SaveChangesAsync();

            return accidentReportRecords;
        }

        private bool AccidentReportRecordsExists(Guid id)
        {
            return _context.AccidentReportRecords.Any(e => e.Id == id);
        }
    }
}