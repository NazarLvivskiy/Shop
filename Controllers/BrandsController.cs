using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Authentication;
using Shop.Models;
using Shop.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public ActionResult<ICollection<Brand>> GetAll()
        {
            var brands = db.GetAllEntities().ToList();

            if (brands.Count == 0)
            {
                return NoContent();
            }

            return Ok(brands);
        }

        [HttpGet]
        [Route("paging")]
        public ActionResult<ICollection<Brand>> GetBrands([FromQuery] PaginationParameters pagination)
        {
            var brands = db.GetEntitiesForFilter(pagination);

            if (brands.Count == 0)
            {
                return NoContent();
            }

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public ActionResult<Brand> GetForId(Guid id)
        {
            var brand = db.GetForId(id);

            if (brand == null)
            {
                return NotFound(
                    new Error { 
                        Code = 404, 
                        Message = " Brand not found", 
                        Details = "Cannot find brand with id: " + id 
                    });
            }

            return Ok(brand);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public ActionResult<Brand> Post(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest(
                    new Error { 
                        Code = 400, 
                        Message = "Bad request", 
                        Details = "nullable value or incorrect type" 
                    });
            }
            else if (typeof(Brand) != brand.GetType())
            {
                return UnprocessableEntity(
                    new Error { 
                        Code = 1050, 
                        Message = "Invalid data", 
                        Details = "invalid location field in incoming object" 
                    });
            }

            db.Create(brand);

            return Created("Created", brand);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public ActionResult<Brand> Delete(Guid id)
        {
            if (!db.GetAllEntities().Any(x => x.Id == id))
            {
                return NotFound(
                    new Error { 
                        Code = 404, 
                        Message = "Brand not found", 
                        Details = "Cannot find and delete this brand with id: " + id 
                    });
            }

            db.Delete(id);

            return NoContent();
        }
    }
}
