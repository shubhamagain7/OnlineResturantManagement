using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_Api.Models;

namespace Resturant_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        private readonly ResturantContext _context;

        public MenusController(ResturantContext context)
        {
            _context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(MenusController));
        }

        // GET: api/Menus
        [HttpGet]
        public IEnumerable<Menu> GetMenu()
        {
            return  _context.Menu.ToList();
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public Menu GetMenu(int id)
        {
            var menu = _context.Menu.Find(id);

            return menu;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutMenu(int id, Menu menu)
        {


            // _context.Entry(menu).State = EntityState.Modified;
            Menu m = _context.Menu.Find(id);
            m.Name = menu.Name;
            m.Price = menu.Price;
            m.Type = menu.Type;
            _context.Menu.Update(m);

            try
            {
                 _context.SaveChanges();
                return Ok("Menu Updation Success");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

           
        }

        // POST: api/Menus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.Menu.Add(menu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Menu>> DeleteMenu(int id)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();

            return menu;
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.Id == id);
        }
    }
}
