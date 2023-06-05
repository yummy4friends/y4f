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
    public class KundenController : ControllerBase
    {
        private readonly WebApiContext _context;

        public KundenController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Kunden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kunde>>> GetKundes()
        {
          if (_context.Kundes == null)
          {
              return NotFound();
          }
            return await _context.Kundes.ToListAsync();
        }

        // GET: api/Kunden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kunde>> GetKunde(int id)
        {
          if (_context.Kundes == null)
          {
              return NotFound();
          }
            var kunde = await _context.Kundes.FindAsync(id);

            if (kunde == null)
            {
                return NotFound();
            }

            return kunde;
        }

        // PUT: api/Kunden/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKunde(int id, Kunde kunde)
        {
            if (id != kunde.Idkunde)
            {
                return BadRequest();
            }

            _context.Entry(kunde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KundeExists(id))
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

        // POST: api/Kunden
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kunde>> PostKunde(Kunde kunde)
        {
          if (_context.Kundes == null)
          {
              return Problem("Entity set 'WebApiContext.Kundes'  is null.");
          }
            _context.Kundes.Add(kunde);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KundeExists(kunde.Idkunde))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKunde", new { id = kunde.Idkunde }, kunde);
        }

        // DELETE: api/Kunden/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKunde(int id)
        {
            if (_context.Kundes == null)
            {
                return NotFound();
            }
            var kunde = await _context.Kundes.FindAsync(id);
            if (kunde == null)
            {
                return NotFound();
            }

            _context.Kundes.Remove(kunde);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KundeExists(int id)
        {
            return (_context.Kundes?.Any(e => e.Idkunde == id)).GetValueOrDefault();
        }
    }
}
