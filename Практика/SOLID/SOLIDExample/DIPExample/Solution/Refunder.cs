using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPExample.Solution
{
    public class Refunder : IRefunder
    {
        public decimal Refund(IRefundedOrder order)
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
