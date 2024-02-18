using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPExample.Problem
{
    public class Exchanger
    {
        public decimal Exchange(Order order)
        {
            decimal returnShippingCost = order.ShippingCost * 2;

            if (order.User.Membership == Memberships.Premium)
            {
                returnShippingCost = 0;
            }

            return returnShippingCost;
        }
    }
}
