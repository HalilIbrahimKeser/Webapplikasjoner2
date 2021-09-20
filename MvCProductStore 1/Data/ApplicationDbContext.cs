using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvCProductStore_1.Models;
using MvCProductStore_1.Models.Entities;

namespace MvCProductStore_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<Product>().ToTable("Product");

            // Seeding

            modelBuilder.Entity<Category>()
                .HasData(new Category { CategoryId = 1, Name = "Verktøy" });
            modelBuilder.Entity<Category>()
                .HasData(new Category { CategoryId = 2, Name = "Kjøretøy" });
            modelBuilder.Entity<Category>()
                .HasData(new Category { CategoryId = 3, Name = "Dagligvarer" });


            modelBuilder.Entity<Manufacturer>()
                .HasData(new Manufacturer { ManufacturerId = 1, Name = "Volvo" });
            modelBuilder.Entity<Manufacturer>()
                .HasData(new Manufacturer { ManufacturerId = 2, Name = "Bosch" });
            modelBuilder.Entity<Manufacturer>()
                .HasData(new Manufacturer { ManufacturerId = 3, Name = "Menu" });


            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Hammer", Price = 121.50m, CategoryId = 1, ManufacturerId = 2 });
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 2, Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 1, ManufacturerId = 2 });
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 3, Name = "Volvo XC90", Price = 990000m, CategoryId = 2, ManufacturerId = 1 });
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 4, Name = "Volvo XC60", Price = 620000m, CategoryId = 2, ManufacturerId = 1 });
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 5, Name = "Brød", Price = 25.50m, CategoryId = 3, ManufacturerId = 3 });
        }

        /*
        modelBuilder.Entity<Product>().HasData(
        new Product
        {
            ProductId = 1, Name = "Hammer", Price = 121.50m, CategoryId = 1, ManufacturerId = 2, 
            Owner = new IdentityUser()
            {
                UserName = "Testuser",
                Id = "8844554-a24d-4"
                PasswordHash = hash
            }
        });
        */
    }
}
