using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPExample.Problem;

namespace ISPExample.Solution
{
    public interface IExchangedOrder : IOrder
    {
        Exchanger Exchanger { get; }

        void Exchange(IExchangedOrder order);
    }
}
