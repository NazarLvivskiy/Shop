using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Brand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
