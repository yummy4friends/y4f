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
    public class MenuitemkategoriesController : ControllerBase
    {
        private readonly WebApiContext _context;

        public MenuitemkategoriesController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Menuitemkategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menuitemkategorie>>> GetMenuitemkategories()
        {
          if (_context.Menuitemkategories == null)
          {
              return NotFound();
          }
            return await _context.Menuitemkategories.ToListAsync();
        }

        // GET: api/Menuitemkategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menuitemkategorie>> GetMenuitemkategorie(int id)
        {
          if (_context.Menuitemkategories == null)
          {
              return NotFound();
          }
            var menuitemkategorie = await _context.Menuitemkategories.FindAsync(id);

            if (menuitemkategorie == null)
            {
                return NotFound();
            }

            return menuitemkategorie;
        }

        // PUT: api/Menuitemkategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuitemkategorie(int id, Menuitemkategorie menuitemkategorie)
        {
            if (id != menuitemkategorie.IdmenuItemKategorie)
            {
                return BadRequest();
            }

            _context.Entry(menuitemkategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuitemkategorieExists(id))
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

        // POST: api/Menuitemkategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menuitemkategorie>> PostMenuitemkategorie(Menuitemkategorie menuitemkategorie)
        {
          if (_context.Menuitemkategories == null)
          {
              return Problem("Entity set 'WebApiContext.Menuitemkategories'  is null.");
          }
            _context.Menuitemkategories.Add(menuitemkategorie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuitemkategorieExists(menuitemkategorie.IdmenuItemKategorie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuitemkategorie", new { id = menuitemkategorie.IdmenuItemKategorie }, menuitemkategorie);
        }

        // DELETE: api/Menuitemkategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuitemkategorie(int id)
        {
            if (_context.Menuitemkategories == null)
            {
                return NotFound();
            }
            var menuitemkategorie = await _context.Menuitemkategories.FindAsync(id);
            if (menuitemkategorie == null)
            {
                return NotFound();
            }

            _context.Menuitemkategories.Remove(menuitemkategorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuitemkategorieExists(int id)
        {
            return (_context.Menuitemkategories?.Any(e => e.IdmenuItemKategorie == id)).GetValueOrDefault();
        }
    }
}
