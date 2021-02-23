using Shop.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cash
    {
        public Guid Id { get; set; }

        public ApplicationUser User { get; set; }

        public Dictionary<Phone,int> Pairs { get; set; }
    }
}
