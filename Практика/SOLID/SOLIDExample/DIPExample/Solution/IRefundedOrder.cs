using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPExample.Solution
{
    public interface IRefundedOrder : IOrder
    {
        IRefunder Refunder { get; }

        void Refund(IRefundedOrder refundedOrder);
    }
}
