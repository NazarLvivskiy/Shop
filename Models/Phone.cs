using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Phone
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Phone Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Price is required")]
        public decimal Price { get; set; }

        public IList<Image> Images { get; set; } = new List<Image>();

        public string Camera { get; set; }

        [Required(ErrorMessage = "Phone Display is required")]
        public float Display { get; set; }

        public string Capacity { get; set; }

        public string Chip { get; set; }

        public string RAM { get; set; }

        public virtual Guid? BrandId { get; set; }

        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        public int? CapacityBattery { get; set; }
    }
}
