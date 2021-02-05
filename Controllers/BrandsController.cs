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
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IRepository<Brand> db;

        public BrandsController(IRepository<Brand> repository)
        {
            db = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<Brand>> GetAll()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Unauthorized(new Error { Code = 401, Message = "Unauthorized", Details = "User is unauthorized" });
            }
            var brands = db.GetAllEntities().ToList();

            if (brands.Count == 0)
            {
                return NoContent();
            }

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public ActionResult<Brand> GetForId(Guid id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Unauthorized(new Error { Code = 401, Message = "Unauthorized", Details = "User is unauthorized" });
            }
            var brand = db.GetForId(id);

            if (brand == null)
            {
                return NotFound(new Error { Code = 404, Message = " Brand not found", Details = "Cannot find brand with id: " + id });
            }

            return Ok(brand);
        }

        [HttpPost]
        public ActionResult<Brand> Post(Brand brand)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Unauthorized(new Error { Code = 401, Message = "Unauthorized", Details = "User is unauthorized" });
            }
            else if (brand == null)
            {
                return BadRequest(new Error { Code = 400, Message = "Bad request", Details = "nullable value or incorrect type" });
            }
            else if (typeof(Brand) != brand.GetType())
            {
                return UnprocessableEntity(new Error { Code = 1050, Message = "Invalid data", Details = "invalid location field in incoming object" });
            }

            db.Create(brand);

            return Created("Created", brand);
        }

        [HttpPut]
        public async Task<ActionResult<Brand>> Put(Brand brand)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Unauthorized(new Error { Code = 401, Message = "Unauthorized", Details = "User is unauthorized" });
            }
            else if (brand == null)
            {
                return BadRequest();
            }
            if (!db.GetAllEntities().Any(x => x.Id == brand.Id))
            {
                return NotFound(new Error { Code = 404, Message = " Brand not found", Details = "Cannot find brand with id: " + brand.Id });
            }

            await db.Update(brand);

            return Ok(brand);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Brand> Delete(Guid id)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return Unauthorized(new Error { Code = 401, Message = "Unauthorized", Details = "User is unauthorized" });
            }

            if (!db.GetAllEntities().Any(x => x.Id == id))
            {
                return NotFound(new Error { Code = 404, Message = "Brand not found", Details = "Cannot find and delete this brand with id: " + id });
            }

            var phones = db.GetForId(id).Phones;

            for (int i = 0; i < phones.Count; i++)
            {

            }



            db.Delete(id);

            return NoContent();
        }
    }
}
