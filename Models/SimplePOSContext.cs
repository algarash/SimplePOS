﻿using Microsoft.EntityFrameworkCore;

namespace SimplePOS.Models
{
    public class SimplePOSContext : DbContext
    {
        public SimplePOSContext(DbContextOptions<SimplePOSContext>
            options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            var CategoryList = new Category[] {
                new Category{CategoryId=1, CategoryName= "Milk", CategoryDescription= "Milk from a cow lol"}
            };
            modelBuilder.Entity<Category>().HasData(CategoryList);

            var ProductList = new Product[] {
                new Product{ProductId=1, ProductName = "Milk", ProductDescription = "Milk from a cow lol", ProductImageUrl = "https://www.heritagefoods.in/blog/wp-content/uploads/2020/12/shutterstock_539045662.jpg", CategoryId = 1}
            };
            modelBuilder.Entity<Product>().HasData(ProductList);

        }

    }
}
