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
    public class BestellungspositionHasMenuitemsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public BestellungspositionHasMenuitemsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/BestellungspositionHasMenuitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BestellungspositionHasMenuitem>>> GetBestellungspositionHasMenuitem()
        {
          if (_context.BestellungspositionHasMenuitem == null)
          {
              return NotFound();
          }
            return await _context.BestellungspositionHasMenuitem.ToListAsync();
        }

        // GET: api/BestellungspositionHasMenuitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BestellungspositionHasMenuitem>> GetBestellungspositionHasMenuitem(int? id)
        {
          if (_context.BestellungspositionHasMenuitem == null)
          {
              return NotFound();
          }
            var bestellungspositionHasMenuitem = await _context.BestellungspositionHasMenuitem.FindAsync(id);

            if (bestellungspositionHasMenuitem == null)
            {
                return NotFound();
            }

            return bestellungspositionHasMenuitem;
        }

        // PUT: api/BestellungspositionHasMenuitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBestellungspositionHasMenuitem(int? id, BestellungspositionHasMenuitem bestellungspositionHasMenuitem)
        {
            if (id != bestellungspositionHasMenuitem.Bestellungsposition_IDBestellung)
            {
                return BadRequest();
            }

            _context.Entry(bestellungspositionHasMenuitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BestellungspositionHasMenuitemExists(id))
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

        // POST: api/BestellungspositionHasMenuitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BestellungspositionHasMenuitem>> PostBestellungspositionHasMenuitem(BestellungspositionHasMenuitem bestellungspositionHasMenuitem)
        {
          if (_context.BestellungspositionHasMenuitem == null)
          {
              return Problem("Entity set 'WebApiContext.BestellungspositionHasMenuitem'  is null.");
          }
            _context.BestellungspositionHasMenuitem.Add(bestellungspositionHasMenuitem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BestellungspositionHasMenuitemExists(bestellungspositionHasMenuitem.Bestellungsposition_IDBestellung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBestellungspositionHasMenuitem", new { id = bestellungspositionHasMenuitem.Bestellungsposition_IDBestellung }, bestellungspositionHasMenuitem);
        }

        // DELETE: api/BestellungspositionHasMenuitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBestellungspositionHasMenuitem(int? id)
        {
            if (_context.BestellungspositionHasMenuitem == null)
            {
                return NotFound();
            }
            var bestellungspositionHasMenuitem = await _context.BestellungspositionHasMenuitem.FindAsync(id);
            if (bestellungspositionHasMenuitem == null)
            {
                return NotFound();
            }

            _context.BestellungspositionHasMenuitem.Remove(bestellungspositionHasMenuitem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BestellungspositionHasMenuitemExists(int? id)
        {
            return (_context.BestellungspositionHasMenuitem?.Any(e => e.Bestellungsposition_IDBestellung == id)).GetValueOrDefault();
        }
    }
}
