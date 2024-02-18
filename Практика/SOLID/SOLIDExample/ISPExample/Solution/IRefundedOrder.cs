using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPExample.Problem;

namespace ISPExample.Solution
{
    public interface IRefundedOrder : IOrder
    {
        Refunder Refunder { get; }

        void Refund(IRefundedOrder refundedOrder);
    }
}
