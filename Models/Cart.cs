using Shop.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }    

        public ApplicationUser User { get; set; }

        public List<Product> Products { get; set; }

        public double TotalSum { get; set; }    
    }
}
