using Microsoft.EntityFrameworkCore;
using RestBuy.Application.Repos;
using RestBuy.Application.Services.Queries;
using RestBuy.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestBuy.Infrastructure.EF
{
    public abstract class BaseRepo<T> : IEntityRepo<T> where T : BaseEntity
    {
        readonly protected RestBuyContext restBuyContext;

        protected BaseRepo(RestBuyContext restBuyContext) =>
            this.restBuyContext = restBuyContext;

        public Task<T> GetById(int id, CancellationToken cancellationToken = default) =>
          this.restBuyContext.Set<T>().FindAsync(id, cancellationToken);

        public Task<List<T>> ListAsync(
            IQuery<T> query = null,
            CancellationToken cancellationToken = default)
        {
            var filterQuery = this.restBuyContext.Set<T>()
                 .AsQueryable().Where(query.Criteria);

            if (query.Skip > 0)
            {
                filterQuery = filterQuery.Skip(query.Skip);
            }
            if (query.Take > 0)
            {
                filterQuery = filterQuery.Take(query.Take);
            }
            if (query.OrderBy != null || query.OrderByDescending != null)
            {
                IOrderedQueryable<T> q;

                if (query.OrderBy != null)
                {
                    q = filterQuery.OrderBy(query.OrderBy);
                }
                else
                {
                    q = filterQuery.OrderByDescending(query.OrderByDescending);
                }

                if (query.ThenBy != null)
                {
                    q = q.ThenBy(query.ThenBy);
                }
                else if (query.ThenByDescending != null)
                {
                    q = q.ThenByDescending(query.ThenByDescending);
                }
                filterQuery = q;
            }
            return filterQuery.ToListAsync(cancellationToken);
        }
    }
}
