using System;
using System.Collections.Generic;
using System.Text;


namespace RestBuy.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string Category { get; set; }
    }
}


