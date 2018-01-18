using RestBuy.Entities;
using System;
using System.Linq.Expressions;

namespace RestBuy.Application.Services.Queries
{
    class UserExistsQuery : BaseQuery<User>
    {
        public UserExistsQuery(string userName) =>
            this.UserName = userName;

        public string UserName { get; }

        public override Expression<Func<User, bool>> Criteria =>
            u => u.UserName == this.UserName;

        public override int Take => 1;
    }
}
