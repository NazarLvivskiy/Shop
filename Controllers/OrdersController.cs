using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Authentication;
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
        IdentityRepository<Order> db;

        public OrdersController(IdentityRepository<Order> identy)
        {
            db = identy;
        }

        [Authorize(Roles = UserRoles.Admin)]
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
                        Message = "Order not found",
                        Details = "Cannot find order with id: " + id
                    });
            }

            return Ok(order);
        }

        [HttpGet("user/{id}")]
        public ActionResult<Order> GetAllForUserId(string id)
        {
            var order = db.GetAllEntities().Where(user => user.UserId == id).ToList();

            if (order == null)
            {
                return NotFound(
                    new Error
                    {
                        Code = 404,
                        Message = "Order not found",
                        Details = "Cannot find order with id: " + id
                    });
            }

            return Ok(order);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public ActionResult<Order> GetAll(Guid id)
        {
            var brands = db.GetAllEntities().ToList();

            if (brands.Count == 0)
            {
                return NoContent();
            }

            return Ok(brands);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [Route("paging")]
        [HttpGet]
        public ActionResult<Order> GetAllForPagination([FromQuery] PaginationParameters pagination)
        {
            var orders = db.GetEntitiesForFilter(pagination);

            if (orders.Count == 0)
            {
                return NoContent();
            }

            return Ok(orders);
        }

        [HttpGet("user-paging/{id}")]
        public ActionResult<Order> GetAllForPaginationForUser([FromQuery] PaginationParameters pagination, string id)
        {
            var orders = db.GetEntitiesForFilter(pagination).Where(user=>user.UserId == id).ToList();

            if (orders.Count == 0)
            {
                return NoContent();
            }

            return Ok(orders);
        }

        [HttpPost]
        public ActionResult<Order> Add(Order order)
        {
            if (order == null)
            {
                return BadRequest(
                    new Error
                    {
                        Code = 400,
                        Message = "Bad request",
                        Details = "nullable value or incorrect type"
                    });
            }
            else if (typeof(Order) != order.GetType())
            {
                return UnprocessableEntity(
                    new Error
                    {
                        Code = 422,
                        Message = "Invalid data",
                        Details = "invalid location field in incoming object"
                    });
            }

            db.Create(order);

            return Created("Created", order);
        }

    }
}
