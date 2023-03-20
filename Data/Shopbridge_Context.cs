using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shopbridge_base.Domain.Models;

namespace Shopbridge_base.Data
{
    public class Shopbridge_Context : DbContext
    {
        public Shopbridge_Context (DbContextOptions<Shopbridge_Context> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductCategories>().HasKey(x => x.ProductCategoriesId);
            modelBuilder.Entity<ProductCategories>().HasOne(x => x.Category).WithMany(x => x.ProductCategories);
            modelBuilder.Entity<ProductCategories>().HasOne(x => x.Category).WithMany(x => x.ProductCategories);
        }
    }
}
