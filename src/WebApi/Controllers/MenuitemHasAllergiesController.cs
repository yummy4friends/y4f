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
    public class MenuitemHasAllergiesController : ControllerBase
    {
        private readonly WebApiContext _context;

        public MenuitemHasAllergiesController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/MenuitemHasAllergies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuitemHasAllergie>>> GetMenuitemHasAllergie()
        {
          if (_context.MenuitemHasAllergie == null)
          {
              return NotFound();
          }
            return await _context.MenuitemHasAllergie.ToListAsync();
        }

        // GET: api/MenuitemHasAllergies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuitemHasAllergie>> GetMenuitemHasAllergie(int? id)
        {
          if (_context.MenuitemHasAllergie == null)
          {
              return NotFound();
          }
            var menuitemHasAllergie = await _context.MenuitemHasAllergie.FindAsync(id);

            if (menuitemHasAllergie == null)
            {
                return NotFound();
            }

            return menuitemHasAllergie;
        }

        // PUT: api/MenuitemHasAllergies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuitemHasAllergie(int? id, MenuitemHasAllergie menuitemHasAllergie)
        {
            if (id != menuitemHasAllergie.MenuItem_IDMenuItem)
            {
                return BadRequest();
            }

            _context.Entry(menuitemHasAllergie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuitemHasAllergieExists(id))
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

        // POST: api/MenuitemHasAllergies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuitemHasAllergie>> PostMenuitemHasAllergie(MenuitemHasAllergie menuitemHasAllergie)
        {
          if (_context.MenuitemHasAllergie == null)
          {
              return Problem("Entity set 'WebApiContext.MenuitemHasAllergie'  is null.");
          }
            _context.MenuitemHasAllergie.Add(menuitemHasAllergie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuitemHasAllergieExists(menuitemHasAllergie.MenuItem_IDMenuItem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuitemHasAllergie", new { id = menuitemHasAllergie.MenuItem_IDMenuItem }, menuitemHasAllergie);
        }

        // DELETE: api/MenuitemHasAllergies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuitemHasAllergie(int? id)
        {
            if (_context.MenuitemHasAllergie == null)
            {
                return NotFound();
            }
            var menuitemHasAllergie = await _context.MenuitemHasAllergie.FindAsync(id);
            if (menuitemHasAllergie == null)
            {
                return NotFound();
            }

            _context.MenuitemHasAllergie.Remove(menuitemHasAllergie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuitemHasAllergieExists(int? id)
        {
            return (_context.MenuitemHasAllergie?.Any(e => e.MenuItem_IDMenuItem == id)).GetValueOrDefault();
        }
    }
}
