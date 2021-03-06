using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Context
{
    public class ProductDbContext :DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData
            (
                new Product() { Id = 1, ProductName = "Cabinet", Description = "Classic style", BasePrice = 1000, ImageUrl = "image/Cabinet.jpg", RemainingDays = 3, IsSold = false, CreatedDate = DateTime.Now.AddDays(-2), ExpiryDate=DateTime.Now.AddDays(3), TodaysDate = DateTime.Now },
                new Product() { Id = 2, ProductName = "Cycle", Description = "Well maintained cycle", BasePrice = 2000, ImageUrl = "image/Cycle.jpg", RemainingDays = 5, IsSold = false, CreatedDate = DateTime.Now, ExpiryDate = DateTime.Now.AddDays(5), TodaysDate = DateTime.Now },
                new Product() { Id = 3, ProductName = "Toys", Description = "Brio train", BasePrice = 150, ImageUrl = "image/Toys.jpg", RemainingDays = 4, IsSold = false, CreatedDate = DateTime.Now.AddDays(-1), ExpiryDate = DateTime.Now.AddDays(4), TodaysDate = DateTime.Now },
                new Product() { Id = 4, ProductName = "GardenTools", Description = "Super powerful garden maintainer", BasePrice = 5000, ImageUrl = "image/GardenTools.jpg", RemainingDays = 1, IsSold = false, CreatedDate = DateTime.Now.AddDays(-4), ExpiryDate = DateTime.Now.AddDays(1), TodaysDate = DateTime.Now },
                new Product() { Id = 5, ProductName = "Vessel", Description = "Iron pan", BasePrice = 200, ImageUrl = "image/Vessel.jpg", RemainingDays = 2, IsSold = false, CreatedDate = DateTime.Now.AddDays(-3), ExpiryDate = DateTime.Now.AddDays(2), TodaysDate = DateTime.Now }
            );

        }
    }
}
