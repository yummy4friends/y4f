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
    public class MenuitemueberkategoriesController : ControllerBase
    {
        private readonly WebApiContext _context;

        public MenuitemueberkategoriesController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Menuitemueberkategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menuitemueberkategorie>>> GetMenuitemueberkategories()
        {
          if (_context.Menuitemueberkategories == null)
          {
              return NotFound();
          }
            return await _context.Menuitemueberkategories.ToListAsync();
        }

        // GET: api/Menuitemueberkategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menuitemueberkategorie>> GetMenuitemueberkategorie(int id)
        {
          if (_context.Menuitemueberkategories == null)
          {
              return NotFound();
          }
            var menuitemueberkategorie = await _context.Menuitemueberkategories.FindAsync(id);

            if (menuitemueberkategorie == null)
            {
                return NotFound();
            }

            return menuitemueberkategorie;
        }

        // PUT: api/Menuitemueberkategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuitemueberkategorie(int id, Menuitemueberkategorie menuitemueberkategorie)
        {
            if (id != menuitemueberkategorie.IdmenuItemUeberkategorie)
            {
                return BadRequest();
            }

            _context.Entry(menuitemueberkategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuitemueberkategorieExists(id))
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

        // POST: api/Menuitemueberkategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menuitemueberkategorie>> PostMenuitemueberkategorie(Menuitemueberkategorie menuitemueberkategorie)
        {
          if (_context.Menuitemueberkategories == null)
          {
              return Problem("Entity set 'WebApiContext.Menuitemueberkategories'  is null.");
          }
            _context.Menuitemueberkategories.Add(menuitemueberkategorie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuitemueberkategorieExists(menuitemueberkategorie.IdmenuItemUeberkategorie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuitemueberkategorie", new { id = menuitemueberkategorie.IdmenuItemUeberkategorie }, menuitemueberkategorie);
        }

        // DELETE: api/Menuitemueberkategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuitemueberkategorie(int id)
        {
            if (_context.Menuitemueberkategories == null)
            {
                return NotFound();
            }
            var menuitemueberkategorie = await _context.Menuitemueberkategories.FindAsync(id);
            if (menuitemueberkategorie == null)
            {
                return NotFound();
            }

            _context.Menuitemueberkategories.Remove(menuitemueberkategorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuitemueberkategorieExists(int id)
        {
            return (_context.Menuitemueberkategories?.Any(e => e.IdmenuItemUeberkategorie == id)).GetValueOrDefault();
        }
    }
}
