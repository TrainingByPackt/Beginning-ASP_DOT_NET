using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Entities
{
    public class StockAmount : BaseEntity
    {
        int productId;
        private StockAmount() { }
        public StockAmount(int productId, int initialStock)
        {
            if (initialStock < 0)
                throw new ArgumentException($"{nameof(initialStock)} must be greater than zero");

            this.productId = productId;
            this.Quantity = initialStock;
        }

        public int Quantity { get; set; }
        public int ProductId => this.productId;
    }
}
