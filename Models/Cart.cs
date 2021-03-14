using Microsoft.EntityFrameworkCore;
using Shop.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public ApplicationUser User { get; set; }

        public List<Product> Products { get; set; }

        public double TotalSum { get; set; }    
    }
}
