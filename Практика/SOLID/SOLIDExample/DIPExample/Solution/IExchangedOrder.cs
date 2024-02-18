using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPExample.Solution
{
    public interface IExchangedOrder : IOrder
    {
        IExchanger Exchanger { get; }

        void Exchange(IExchangedOrder order);
    }
}
