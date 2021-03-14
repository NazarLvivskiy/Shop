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
    public class UserController : ControllerBase
    {
        IdentityRepository<ApplicationUser> db;

        public UserController(IdentityRepository<ApplicationUser> identy)
        {
            db = identy;

        }
        
        [HttpGet]
        public ActionResult<ApplicationUser> GetAllInformation()
        {
            var userName = User.Identity.Name;

            var users = db.GetAllEntities().Where(user => user.UserName == userName);

            if (!users.Any())
            {
                return NoContent();
            }

            var user = users.First();

            return Ok(user);
        }

        [HttpPut]
        [Route("changePassword")]
        public async Task<ActionResult<ApplicationUser>> ChangePassword(string PasswordHash)
        {
            var userName = User.Identity.Name;

            var users = db.GetAllEntities().Where(user => user.UserName == userName);

            if (!users.Any())
            {
                return NoContent();
            }

            var user = users.First();

            user.PasswordHash = PasswordHash;

            await db.Update(user);

            return Ok(user);
        }

        [HttpPut]
        [Route("change")]
        public async Task<ActionResult<UserLite>> Update(UserLite userLite)
        {
            var userName = User.Identity.Name;

            var users = db.GetAllEntities().Where(user => user.UserName == userName);

            if (!users.Any())
            {
                return NoContent();
            }

            if (userLite == null||userLite.PhoneNumber == string.Empty|| userLite.Name == string.Empty || userLite.Email == string.Empty|| userLite.Image == string.Empty)
            {
                return BadRequest(
                     new Error
                     {
                         Code = 400,
                         Message = "Bad request",
                         Details = "nullable value or incorrect type"
                     });
            }

            var user = users.First();

            user.UserName = userLite.Name;

            user.NormalizedUserName = userLite.Name.ToUpper();

            user.Email = userLite.Email;

            user.Image = userLite.Image;

            user.NormalizedEmail = userLite.Email.ToUpper();

            user.PhoneNumber = userLite.PhoneNumber;

            await db.Update(user);

            return Ok(user);
        }
    }
}
