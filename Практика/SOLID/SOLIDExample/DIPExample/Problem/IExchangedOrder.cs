using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPExample.Problem
{
    public interface IExchangedOrder : IOrder
    {
        Exchanger Exchanger { get; }

        void Exchange(IExchangedOrder order);
    }
}
