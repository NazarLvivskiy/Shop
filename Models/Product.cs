using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product    
    {
        public Guid Id { get; set; }

        public Guid? PhoneId { get; set; }

        public uint Amount { get; set; }
    }
}
