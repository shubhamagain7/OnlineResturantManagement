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
    public class OrdersController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IOrdersRep db;

        public OrdersController(IOrdersRep _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(OrdersController));
        }

        // GET: api/Orders
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

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            Order data = new Order();
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


        
        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult Post([FromBody] Order user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(user);
                    if (res != 0)
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


        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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
