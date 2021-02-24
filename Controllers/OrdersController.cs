using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IdentyRepository<Order> db;

        public OrdersController(IdentyRepository<Order> identy)
        {
            db = identy;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetForId(Guid id)
        {
            var order = db.GetForId(id);

            if (order == null)
            {
                return NotFound(
                    new Error
                    {
                        Code = 404,
                        Message = " Phone not found",
                        Details = "Cannot find order with id: " + id
                    });
            }

            return Ok(order);
        }
    }
}
