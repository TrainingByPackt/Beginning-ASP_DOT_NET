using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RestBuy.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Infrastructure.EF
{
    class RestBuyContextFactory :
    IDesignTimeDbContextFactory<RestBuyContext>
    {

        public RestBuyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestBuyContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestBuy;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RestBuyContext(optionsBuilder.Options);

        }
    }
}
