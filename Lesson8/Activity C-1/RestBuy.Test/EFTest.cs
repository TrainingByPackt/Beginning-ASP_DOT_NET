using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestBuy.Entities;
using RestBuy.Infrastructure.EF;
using System.IO;
using System.Threading.Tasks;

namespace RestBuy.Test
{
    [TestClass]
    public class EFTest
    {
        [TestMethod]
        public async Task SaveProduct()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestBuyContext>();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            //We add the product.
            using (var context = new RestBuyContext(optionsBuilder.Options))
            {
                await context.Database.EnsureCreatedAsync();
                var product = new Product()
                {
                    Category = "Electronics",
                    Description = "Smart Phone",
                    Name = "iPhone",
                    PictureUri = "apple.com",
                    Price = 1000,
                };
                await context.AddAsync(product);

                await context.SaveChangesAsync();
            }
            // Here we remove the product.
            using (var context = new RestBuyContext(optionsBuilder.Options))
            {
                var product = await context.Products.FirstOrDefaultAsync(c => c.Name == "iPhone");
                Assert.IsNotNull(product);
                await context.Database.EnsureDeletedAsync();
            }

        }
    }
}
