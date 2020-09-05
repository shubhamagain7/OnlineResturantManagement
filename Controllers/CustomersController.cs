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
    public class CustomersController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        private readonly ResturantContext _context;

        public CustomersController(ResturantContext context)
        {

            _context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(CustomersController));
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public Customer GetCustomer(string id)
        {
            var customer = _context.Customers.Find(id);

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCustomer(string id, Customer customer)
        {


            // _context.Entry(customer).State = EntityState.Modified;
            Customer c = _context.Customers.Find(id);
            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
            c.Password = customer.Password;
            _context.Customers.Update(c);
            try
            {
                _context.SaveChanges();
                return Ok("Customer Updation Success");
                    
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            
        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.PhoneNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer", new { id = customer.PhoneNo }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.PhoneNo == id);
        }
    }
}
