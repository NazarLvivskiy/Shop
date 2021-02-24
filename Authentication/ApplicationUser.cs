using Microsoft.AspNetCore.Identity;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Authentication
{
    public class ApplicationUser: IdentityUser
    {
        public string Image { get; set; }

        public Guid CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
