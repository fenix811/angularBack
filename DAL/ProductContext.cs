using back.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            //var cnt = new DbContextOptions();
            //string conString = Microsoft.Extensions.Configuration
            //   .ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration.ConnectionStrings["BloggingDatabase"].ConnectionString);
        //}

    }
}
