using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Application.Repos
{
    public interface IUoW
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

