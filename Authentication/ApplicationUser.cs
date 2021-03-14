using Microsoft.AspNetCore.Identity;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Authentication
{
    public class ApplicationUser: IdentityUser
    {
        public string Image { get; set; }

        public Guid? CartId { get; set; }

        [JsonIgnore]
        public Cart Cart { get; set; } = new Cart();
    }
}
