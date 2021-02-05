using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Phone
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public string Camera { get; set; }

        public float Display { get; set; }

        public string Capacity { get; set; }

        public string Chip { get; set; }

        public string RAM { get; set; }

        public Guid? BrandId { get; set; }

        public Brand Brand { get; set; }

        public int? CapacityBattery { get; set; }
    }
}
