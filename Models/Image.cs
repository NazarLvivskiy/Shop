using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    [Owned]
    public class Image
    {
        public string Url { get; set; }

        public string Alt { get; set; }
    }
}
