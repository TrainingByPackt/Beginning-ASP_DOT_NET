using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }

        public decimal Discount => Total > 1000M ? Total * 0.1M : Total;
           
    }

}
