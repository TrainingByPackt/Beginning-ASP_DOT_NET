using RestBuy.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Application.Repos
{
    public interface IUserRepo : IEntityRepo<User>
    {
        Task AddAsync(User user, CancellationToken ct = default);
    }
}
