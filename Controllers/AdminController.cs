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
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IdentityRepository<ApplicationUser> db;

        public AdminController(IdentityRepository<ApplicationUser> identity)
        {
            db = identity;
        }

        [HttpGet]
        [Route("users")]
        public ActionResult<ICollection<ApplicationUser>> GetAllUsers()
        {
            var users = db.GetAllEntities().ToList();

            if (users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }

        [HttpGet]
        [Route("users/{id}")]
        public ActionResult<ICollection<ApplicationUser>> GetUserForId(string id)
        {
            var user = db.GetForId(id);

            if (user == null)
            {
                return NotFound(
                    new Error
                    {
                        Code = 404,
                        Message = "User not found",
                        Details = "Cannot find user with id: " + id
                    });
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult<Phone> Delete(string id)
        {
            if (!db.GetAllEntities().Any(x => x.Id == id))
            {
                return NotFound(
                    new Error
                    {
                        Code = 404,
                        Message = "User not found",
                        Details = "Cannot find and delete this user with id: " + id
                    });
            }

            db.Delete(id);

            return NoContent();
        }
    }
}
