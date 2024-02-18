using DIPExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPExample.Problem
{
    internal class OrderWithRefund(int id, User user, decimal amount, decimal shippingCost, Refunder refunder) : IRefundedOrder
    {
        public Refunder Refunder { get; } = refunder;

        public int Id { get; } = id;

        public User User { get; } = user;

        public decimal Amount { get; set; } = amount;

        public decimal ShippingCost { get; set; } = shippingCost;

        public void Refund(IRefundedOrder refundedOrder)
        {
            ShippingCost = Refunder.Refund(this);
        }
    }
}
