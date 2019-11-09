using DriverTracking.DbContexts;
using DriverTracking.Entities;
using JT_Coin;
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
    public class TripRecordsController : ControllerBase
    {
        private readonly DriverTrackingContext _context;
        const string Master = "Master";
        public string Recipient;

        public TripRecordsController(DriverTrackingContext context)
        {
            _context = context;
        }

        // GET: api/TripRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripRecords>>> GetTripRecords()
        {
            return await _context.TripRecords.ToListAsync();
        }

        // GET: api/TripRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripRecords>> GetTripRecords(Guid id)
        {
            var tripRecords = await _context.TripRecords.FindAsync(id);

            if (tripRecords == null)
            {
                return NotFound();
            }

            return tripRecords;
        }

        // PUT: api/TripRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripRecords(Guid id, TripRecords tripRecords)
        {
            if (id != tripRecords.Id)
            {
                return BadRequest();
            }

            _context.Entry(tripRecords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripRecordsExists(id))
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

        // POST: api/TripRecords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TripRecords>> PostTripRecords(TripRecords tripRecords)
        {
            _context.TripRecords.Add(tripRecords);
            await _context.SaveChangesAsync();

            // Begin coin transaction
            var blockChain = new BlockChain(proofOfWorkDifficulty:2, miningReward: tripRecords.CoinsEarned);
            Console.WriteLine("BALANCE of the miner: {0}", blockChain.GetBalance(Recipient));
            PrintChain(blockChain);

            return CreatedAtAction("GetTripRecords", new { id = tripRecords.Id }, tripRecords);
        }

        // DELETE: api/TripRecords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TripRecords>> DeleteTripRecords(Guid id)
        {
            var tripRecords = await _context.TripRecords.FindAsync(id);
            if (tripRecords == null)
            {
                return NotFound();
            }

            _context.TripRecords.Remove(tripRecords);
            await _context.SaveChangesAsync();

            return tripRecords;
        }

        private bool TripRecordsExists(Guid id)
        {
            return _context.TripRecords.Any(e => e.Id == id);
        }

        public void PrintChain(BlockChain blockChain)
        {
            Console.WriteLine("----------------- Start Blockchain -----------------");
            foreach (Block block in blockChain.Chain)
            {
                Console.WriteLine();
                Console.WriteLine("------ Start Block ------");
                Console.WriteLine("Hash: {0}", block.Hash);
                Console.WriteLine("Previous Hash: {0}", block.PreviousHash);
                Console.WriteLine("--- Start Transactions ---");
                foreach (Transaction transaction in block.Transactions)
                {
                    Console.WriteLine("From: {0} To {1} Amount {2}", transaction.From, transaction.To, transaction.Amount);
                }
                Console.WriteLine("--- End Transactions ---");
                Console.WriteLine("------ End Block ------");
            }
            Console.WriteLine("----------------- End Blockchain -----------------");
        }
    }
}