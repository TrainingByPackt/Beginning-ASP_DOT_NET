using RestBuy.Application.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Application.Services
{
    public interface IRegistrationService
    {
        Task RegisterUser(NewUserViewModel newUserViewModel, CancellationToken token = default);
    }
}
