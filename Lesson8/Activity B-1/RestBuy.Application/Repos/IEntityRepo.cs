using RestBuy.Application.Services.Queries;
using RestBuy.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Application.Repos
{
    public interface IEntityRepo<T> where T : BaseEntity
    {
        Task<T> GetById(int id, CancellationToken cancellationToken = default);

        Task<List<T>> ListAsync(IQuery<T> query = null, CancellationToken cancellationToken = default);
    }
}
