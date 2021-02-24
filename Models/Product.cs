using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public uint Amount { get; set; }
    }
}
