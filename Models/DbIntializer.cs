using SimplePOS.Models;

namespace YuusufPieShop.Models
{
    public static class DbIntializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            SimplePOSContext context = 
                applicationBuilder.ApplicationServices.CreateScope
                ().ServiceProvider.GetRequiredService<SimplePOSContext>();

            var productList = new Product { CategoryId = 1, ProductName = "sh",  Price=22 };
            context.Products.Add(productList);
            context.SaveChanges();
    


        }



    }
}
