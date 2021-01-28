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
        public ActionResult<ICollection<Phone>> GetAll()
        {
            return db.GetAllEntities().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Phone> GetForId(Guid id)
        {
            return db.GetForId(id);
        }

        [HttpPost]
        public ActionResult<Phone> Post(Phone phone)
        {
            if (phone == null)
            {
                return BadRequest();
            }

            db.Create(phone);

            return Ok();
        }

        [HttpPut]
        public ActionResult<Phone> Put(Phone phone)
        {
            if (phone == null)
            {
                return BadRequest();
            }
            if (!db.GetAllEntities().Any(x => x.Id == phone.Id))
            {
                return NotFound();
            }

            db.Update(phone);

            return Ok(phone);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Phone> Delete(Guid id)
        {
            var phone = db.GetAllEntities().FirstOrDefault(x => x.Id == id);
           
            if (phone == null)
            {
                return NotFound();
            }

            db.Delete(id);
            
            return Ok(phone);
        }
    }
}
