using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ShopContext:DbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
