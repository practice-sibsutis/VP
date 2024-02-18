using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPExample.Solution
{
    public class Exchanger
    {
        public decimal Exchange(IExchangedOrder order)
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
