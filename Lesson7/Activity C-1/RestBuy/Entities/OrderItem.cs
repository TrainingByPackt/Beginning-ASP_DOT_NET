
using System;
using System.Collections.Generic;
using System.Text;

namespace RestBuy.Entities
{
    public class OrderItem : BaseEntity
    {
        int productId;
        int quantity;
        decimal price;

        private OrderItem() { }

        public OrderItem(int productId, int quantity,
        decimal price)
        {
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
        }

        public int ProductId => this.productId;
        public int Quantity => this.quantity;
        public decimal Price => this.price;
    }
}


