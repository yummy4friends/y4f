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
    public class MenuitemsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public MenuitemsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Menuitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menuitem>>> GetMenuitems()
        {
          if (_context.Menuitems == null)
          {
              return NotFound();
          }
            return await _context.Menuitems.ToListAsync();
        }

        // GET: api/Menuitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menuitem>> GetMenuitem(int id)
        {
          if (_context.Menuitems == null)
          {
              return NotFound();
          }
            var menuitem = await _context.Menuitems.FindAsync(id);

            if (menuitem == null)
            {
                return NotFound();
            }

            return menuitem;
        }

        // PUT: api/Menuitems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuitem(int id, Menuitem menuitem)
        {
            if (id != menuitem.IdmenuItem)
            {
                return BadRequest();
            }

            _context.Entry(menuitem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuitemExists(id))
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

        // POST: api/Menuitems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menuitem>> PostMenuitem(Menuitem menuitem)
        {
          if (_context.Menuitems == null)
          {
              return Problem("Entity set 'WebApiContext.Menuitems'  is null.");
          }
            _context.Menuitems.Add(menuitem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuitemExists(menuitem.IdmenuItem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuitem", new { id = menuitem.IdmenuItem }, menuitem);
        }

        // DELETE: api/Menuitems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuitem(int id)
        {
            if (_context.Menuitems == null)
            {
                return NotFound();
            }
            var menuitem = await _context.Menuitems.FindAsync(id);
            if (menuitem == null)
            {
                return NotFound();
            }

            _context.Menuitems.Remove(menuitem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuitemExists(int id)
        {
            return (_context.Menuitems?.Any(e => e.IdmenuItem == id)).GetValueOrDefault();
        }
    }
}
