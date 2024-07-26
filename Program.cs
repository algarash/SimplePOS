using Microsoft.EntityFrameworkCore;
using SimplePOS.Models;
using SimplePOS.Models.Repositories.Implementations;
using SimplePOS.Models.Repositories.Interfaces;
using YuusufPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IInwardRepository, InwardRepository>();
builder.Services.AddScoped<IInwardProductRepository, InwardProductRepository>();
builder.Services.AddScoped<IOutwardRepository, OutwardRepository>();

// Add the new repositories
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();




builder.Services.AddScoped<ICartRepository, CartRepository>(sp => CartRepository.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<SimplePOSContext>(options =>
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:SimplePOSDbContextConnection"])
    .EnableSensitiveDataLogging());

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.MapRazorPages();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=ProductList}/{id?}");

app.Run();
