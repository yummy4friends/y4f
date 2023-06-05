using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergienController : ControllerBase
    {
        private readonly WebApiContext _context;

        public AllergienController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Allergien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergie>>> GetAllergies()
        {
          if (_context.Allergies == null)
          {
              return NotFound();
          }
            return await _context.Allergies.ToListAsync();
        }

        // GET: api/Allergien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergie>> GetAllergie(int id)
        {
          if (_context.Allergies == null)
          {
              return NotFound();
          }
            var allergie = await _context.Allergies.FindAsync(id);

            if (allergie == null)
            {
                return NotFound();
            }

            return allergie;
        }

        // PUT: api/Allergien/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllergie(int id, Allergie allergie)
        {
            if (id != allergie.Idallergie)
            {
                return BadRequest();
            }

            _context.Entry(allergie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergieExists(id))
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

        // POST: api/Allergien
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Allergie>> PostAllergie(Allergie allergie)
        {
          if (_context.Allergies == null)
          {
              return Problem("Entity set 'WebApiContext.Allergies'  is null.");
          }
            _context.Allergies.Add(allergie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AllergieExists(allergie.Idallergie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAllergie", new { id = allergie.Idallergie }, allergie);
        }

        // DELETE: api/Allergien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergie(int id)
        {
            if (_context.Allergies == null)
            {
                return NotFound();
            }
            var allergie = await _context.Allergies.FindAsync(id);
            if (allergie == null)
            {
                return NotFound();
            }

            _context.Allergies.Remove(allergie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllergieExists(int id)
        {
            return (_context.Allergies?.Any(e => e.Idallergie == id)).GetValueOrDefault();
        }


    }
}
