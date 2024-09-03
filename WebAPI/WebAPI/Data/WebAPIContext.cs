using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Entities.Product> Product { get; set; } = default!;
        public DbSet<WebAPI.Entities.Document> Document { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(d => d.Price)
                .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Product>().HasOne(d => d.document).WithMany(p => p.products);
        }
    }
}
