using RestBuy.Application.Repos;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Infrastructure.EF
{
    public class RestBuyUoW : IUoW
    {
        readonly RestBuyContext context;
        public RestBuyUoW(RestBuyContext dbContext)
        {
            this.context = dbContext;
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.context.SaveChangesAsync(cancellationToken);


    }
}
