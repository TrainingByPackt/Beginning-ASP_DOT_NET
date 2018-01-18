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
        DbContextOptionsBuilder<RestBuyContext> optionsBuilder;
        //Common code for both tests
        [TestInitialize]
        public void Init()
        {
            this.optionsBuilder = new DbContextOptionsBuilder<RestBuyContext>();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        [TestMethod]
        public async Task SaveProduct()
        {
            using (var context = new RestBuyContext(this.optionsBuilder.Options))
            {
                await context.Database.EnsureCreatedAsync();
                var product = new Product()
                {
                    Category = "Electronics",
                    Description = "Smart Phone",
                    Name = "iPhone",
                    PictureUri = "apple.com",
                    Price = 1000
                };
                await context.AddAsync(product);

                await context.SaveChangesAsync();
            }

            using (var context = new RestBuyContext(optionsBuilder.Options))
            {
                var product = await context.Products.FirstOrDefaultAsync(c => c.Name == "iPhone");
                Assert.IsNotNull(product);
                await context.Database.EnsureDeletedAsync();
            }
        }


        [TestMethod]
        public async Task DeleteAProduct()
        {
            var product = new Product()
            {
                Category = "Electronics",
                Description = "Smart Phone",
                Name = "iPhone",
                PictureUri = "apple.com",
                Price = 1000

            };
            //Save the product as usual
            using (var context = new RestBuyContext(this.optionsBuilder.Options))
            {
                await context.Database.EnsureCreatedAsync();
                await context.AddAsync(product);

                await context.SaveChangesAsync();
            }

            using (var context = new RestBuyContext(this.optionsBuilder.Options))
            {
                //Get the product from db and check its existence
                var productFromDB = await context.Products.FindAsync(product.Id);
                Assert.IsNotNull(productFromDB);
                //delete the product
                context.Remove(productFromDB);

                await context.SaveChangesAsync();

                //recheck the product
                productFromDB = await context.Products.FindAsync(product.Id);
                //now the answer should be no

                Assert.IsNull(productFromDB);
                await context.Database.EnsureDeletedAsync();
            }
        }
    }
}
