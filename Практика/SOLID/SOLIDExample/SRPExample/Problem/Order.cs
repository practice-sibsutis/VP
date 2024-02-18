using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPExample.Problem
{
    public class Order(int id, User user, decimal amount, decimal shippingCost)
    {
        public int Id { get; } = id;
        public User User { get; } = user;
        public decimal Amount { get; private set; } = amount;
        public decimal ShippingCost { get; private set; } = shippingCost;

        public void Refund()
        {
            decimal roundTripShippingCost = ShippingCost * 2;

            if (User.Membership == Memberships.Premium)
            {
                roundTripShippingCost = 0;
            }

            Amount = roundTripShippingCost;
        }

        public void Exchange()
        {
            decimal roundTripShippingCost = ShippingCost * 2;

            if (User.Membership == Memberships.Premium)
            {
                roundTripShippingCost = 0;
            }

            Amount += roundTripShippingCost;
        }
    }
}
