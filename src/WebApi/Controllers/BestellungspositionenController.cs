using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellungspositionenController : ControllerBase
    {
        private readonly WebApiContext _context;

        public BestellungspositionenController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Bestellungspositionen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bestellungsposition>>> GetBestellungspositions()
        {
          if (_context.Bestellungspositions == null)
          {
              return NotFound();
          }
            return await _context.Bestellungspositions.ToListAsync();
        }

        // GET: api/Bestellungspositionen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bestellungsposition>> GetBestellungsposition(int id)
        {
          if (_context.Bestellungspositions == null)
          {
              return NotFound();
          }
            var bestellungsposition = await _context.Bestellungspositions.FindAsync(id);

            if (bestellungsposition == null)
            {
                return NotFound();
            }

            return bestellungsposition;
        }

        // PUT: api/Bestellungspositionen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBestellungsposition(int id, Bestellungsposition bestellungsposition)
        {
            if (id != bestellungsposition.Idbestellung)
            {
                return BadRequest();
            }

            _context.Entry(bestellungsposition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestellungspositionExists(id))
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

        // POST: api/Bestellungspositionen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bestellungsposition>> PostBestellungsposition(Bestellungsposition bestellungsposition)
        {
          if (_context.Bestellungspositions == null)
          {
              return Problem("Entity set 'WebApiContext.Bestellungspositions'  is null.");
          }
            _context.Bestellungspositions.Add(bestellungsposition);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BestellungspositionExists(bestellungsposition.Idbestellung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBestellungsposition", new { id = bestellungsposition.Idbestellung }, bestellungsposition);
        }

        // DELETE: api/Bestellungspositionen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestellungsposition(int id)
        {
            if (_context.Bestellungspositions == null)
            {
                return NotFound();
            }
            var bestellungsposition = await _context.Bestellungspositions.FindAsync(id);
            if (bestellungsposition == null)
            {
                return NotFound();
            }

            _context.Bestellungspositions.Remove(bestellungsposition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BestellungspositionExists(int id)
        {
            return (_context.Bestellungspositions?.Any(e => e.Idbestellung == id)).GetValueOrDefault();
        }
    }
}
