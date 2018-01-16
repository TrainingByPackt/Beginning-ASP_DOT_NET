using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Entities
{
    public abstract class BaseEntity
    {
        protected int id;
        public int Id => this.id;
    }
}