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
    public class OrdersController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        private readonly ResturantContext _context;

        public OrdersController(ResturantContext context)
        {
            _context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(OrdersController));
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return  _context.Orders.ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public Order GetOrder(int id)
        {
            var order =  _context.Orders.Find(id);


            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {


            //_context.Entry(order).State = EntityState.Modified;
            Order o = _context.Orders.Find(id);
            o.PhoneNo = order.PhoneNo;
            o.FoodId = order.FoodId;
           
            _context.Orders.Update(o);
            try
            {
                _context.SaveChanges();
                return Ok("Order Updated!!");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
