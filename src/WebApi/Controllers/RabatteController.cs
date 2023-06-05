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
    public class RabatteController : ControllerBase
    {
        private readonly WebApiContext _context;

        public RabatteController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Rabatte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rabatt>>> GetRabatts()
        {
          if (_context.Rabatts == null)
          {
              return NotFound();
          }
            return await _context.Rabatts.ToListAsync();
        }

        // GET: api/Rabatte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rabatt>> GetRabatt(int id)
        {
          if (_context.Rabatts == null)
          {
              return NotFound();
          }
            var rabatt = await _context.Rabatts.FindAsync(id);

            if (rabatt == null)
            {
                return NotFound();
            }

            return rabatt;
        }

        // PUT: api/Rabatte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRabatt(int id, Rabatt rabatt)
        {
            if (id != rabatt.Idrabatt)
            {
                return BadRequest();
            }

            _context.Entry(rabatt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RabattExists(id))
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

        // POST: api/Rabatte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rabatt>> PostRabatt(Rabatt rabatt)
        {
          if (_context.Rabatts == null)
          {
              return Problem("Entity set 'WebApiContext.Rabatts'  is null.");
          }
            _context.Rabatts.Add(rabatt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RabattExists(rabatt.Idrabatt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRabatt", new { id = rabatt.Idrabatt }, rabatt);
        }

        // DELETE: api/Rabatte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRabatt(int id)
        {
            if (_context.Rabatts == null)
            {
                return NotFound();
            }
            var rabatt = await _context.Rabatts.FindAsync(id);
            if (rabatt == null)
            {
                return NotFound();
            }

            _context.Rabatts.Remove(rabatt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RabattExists(int id)
        {
            return (_context.Rabatts?.Any(e => e.Idrabatt == id)).GetValueOrDefault();
        }
    }
}
