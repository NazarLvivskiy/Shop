using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        IRepository<Phone> db;

        public PhonesController(IRepository<Phone> repository)
        {
            db = repository;
        }

        [HttpGet]
        [Route("paging")]
        public ActionResult<ICollection<Phone>> GetPhones([FromQuery] PaginationParameters pagination)
        {
            var phones = db.GetEntitiesForFilter(pagination);

            if (phones.Count == 0)
            {
                return NoContent();
            }

            return Ok(phones);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public ActionResult<ICollection<Phone>> GetAll()
        {
            var phones = db.GetAllEntities().ToList();

            if (phones.Count == 0)
            {
                return NoContent();
            }

            return Ok(phones);
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> GetForId(Guid id)
        {
            var phone = db.GetForId(id);

            if (phone == null)
            {
                return NotFound(
                    new Error { 
                        Code = 404, 
                        Message = " Phone not found", 
                        Details = "Cannot find phone with id: " + id 
                    });
            }

            return Ok(phone);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public ActionResult<Phone> Add(Phone phone)
        {
            if (phone == null)
            {
                return BadRequest(
                    new Error { 
                        Code = 400, 
                        Message = "Bad request", 
                        Details = "nullable value or incorrect type" 
                    });
            }

            db.Create(phone);

            return Created("Created", phone);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<ActionResult<Phone>> Update(Phone phone)
        {
            if (phone == null)
            {
                return BadRequest(
                     new Error
                     {
                         Code = 400,
                         Message = "Bad request",
                         Details = "nullable value or incorrect type"
                     });
            }

            if (!db.GetAllEntities().Any(x => x.Id == phone.Id))
            {
                return NotFound(
                    new Error { 
                        Code = 404, 
                        Message = "Phone not found", 
                        Details = "Cannot find phone with id: " + phone.Id
                    });
            }

            await db.Update(phone, phone.Id);

            return Ok(phone);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public ActionResult<Phone> Delete(Guid id)
        {
            if (!db.GetAllEntities().Any(x => x.Id == id))
            {
                return NotFound(
                    new Error { 
                        Code = 404,
                        Message = "Phone not found", 
                        Details = "Cannot find and delete this phone with id: " + id 
                    });
            }

            db.Delete(id);

            return NoContent();
        }
    }
}
