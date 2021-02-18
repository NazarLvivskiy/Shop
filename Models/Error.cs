using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Error
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public string Details { get; set; }

        public override string ToString()
        {
            return Details;
        }
    }
}
