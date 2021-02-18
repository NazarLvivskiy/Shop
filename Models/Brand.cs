using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Brand Name is required")]
        public string Name { get; set; }

        public Image Image { get; set; }

        public virtual IList<Phone> Phones { get; set; } = new List<Phone>();
    }
}
