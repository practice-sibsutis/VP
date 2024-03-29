﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPExample.Solution
{
    public class PricePerKilogramStrategy : IPriceStrategy
    {
        public bool IsMatch(OrderItem item)
        {
            return item.Identifier.StartsWith("Weight");
        }
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 3m / 1000;
        }
    }
}
