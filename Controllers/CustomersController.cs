using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant_Api.Models;
using Resturant_Api.Repository;

namespace Resturant_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        ICustomersRep db;

        public CustomersController(ICustomersRep _db)
        {

            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(CustomersController));
        }

        // GET: api/Customers
        [HttpGet]
        public IActionResult GetUsers()
        {
            
            try
            {
                var det = db.GetDetails();
                if (det == null)
                    return NotFound();
                return Ok(det);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            Customer data = new Customer();
            try
            {
                data = db.GetDetail(id);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(data);
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Customer user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(id, user);
                    if (result != 1)
                        return BadRequest(result);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromBody] Customer user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(user);
                    if (res != null)
                        return Ok(res);

                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = db.Delete(id);
                if (result == 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(id);
            }
        }

       
    }
}
