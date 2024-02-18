using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPExample.Solution
{
    public class Order(int id, User user, decimal amount, decimal shippingCost, Exchanger exchanger, Refunder refunder)
    {
        public int Id { get; } = id;
        public User User { get; } = user;
        public decimal Amount { get; private set; } = amount;
        public decimal ShippingCost { get; private set; } = shippingCost;

        public Exchanger Exchanger { get; } = exchanger;
        public Refunder Refunder { get; } = refunder;

        public void Refund()
        {
            ShippingCost = Refunder.Refund(this);
        }

        public void Exchange()
        {
            ShippingCost += Exchanger.Exchange(this);
        }
    }
}
