using DIPExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPExample.Solution
{
    public interface IOrder
    {
        public int Id { get; }
        public User User { get; }
        public decimal Amount { get; }
        public decimal ShippingCost { get; }
    }
}
