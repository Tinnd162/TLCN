﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class Item
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public string ImageFile { get; set; }
    }
}
