using Microsoft.EntityFrameworkCore;

namespace SimplePOS.Models
{
    public class SimplePOSContext : DbContext
    {
        public SimplePOSContext(DbContextOptions<SimplePOSContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Inward> Inwards { get; set; }
        public DbSet<InwardProduct> InwardProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite key for OrderItem
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

            // Configure relationships for Inward and InwardProduct
            modelBuilder.Entity<InwardProduct>()
                .HasKey(ip => ip.InwardProductId);

            modelBuilder.Entity<InwardProduct>()
                .HasOne(ip => ip.Inward)
                .WithMany(i => i.InwardProducts)
                .HasForeignKey(ip => ip.InwardId);

            modelBuilder.Entity<InwardProduct>()
                .HasOne(ip => ip.Product)
                .WithMany()
                .HasForeignKey(ip => ip.ProductId);

            // Seed Categories
            var CategoryList = new Category[]
            {
                new Category { CategoryId = 1, CategoryName = "Milk", CategoryDescription = "Milk from a cow lol" }
            };
            modelBuilder.Entity<Category>().HasData(CategoryList);

            // Seed Products
            var ProductList = new Product[]
            {
                new Product { ProductId = 1, ProductName = "Milk", ProductDescription = "Milk from a cow lol", ProductImageUrl = "https://www.heritagefoods.in/blog/wp-content/uploads/2020/12/shutterstock_539045662.jpg", CategoryId = 1 }
            };
            modelBuilder.Entity<Product>().HasData(ProductList);

            // Seed Suppliers
            var SupplierList = new Supplier[]
            {
                new Supplier { SupplierId = 1, Name = "Supplier A", ContactInfo = "123-456-7890", Address = "123 Supplier St" }
            };
            modelBuilder.Entity<Supplier>().HasData(SupplierList);

            // Seed Inwards
            var InwardList = new Inward[]
            {
                new Inward
                {
                    InwardId = 1,
                    SupplierId = 1, // Ensure this ID exists in your database
                    Date = DateTime.Now
                }
            };
            modelBuilder.Entity<Inward>().HasData(InwardList);

            // Seed InwardProducts
            var InwardProductList = new InwardProduct[]
            {
                new InwardProduct
                {
                    InwardProductId = 1,
                    InwardId = 1, // Ensure this ID exists in your database
                    ProductId = 1,  // Ensure this ID exists in your database
                    Quantity = 100
                }
            };
            modelBuilder.Entity<InwardProduct>().HasData(InwardProductList);

            base.OnModelCreating(modelBuilder);
        }
    }
}
