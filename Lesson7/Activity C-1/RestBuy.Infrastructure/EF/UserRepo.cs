using RestBuy.Application.Repos;
using RestBuy.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Infrastructure.EF
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(RestBuyContext restBuyContext) : base(restBuyContext)
        { }

        public Task AddAsync(User user, CancellationToken ct = default) =>
             this.restBuyContext.Users.AddAsync(user, ct);

    }
}
