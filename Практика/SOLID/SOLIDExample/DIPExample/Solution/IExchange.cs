﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPExample.Solution
{
    public interface IExchanger
    {
        decimal Exchange(IExchangedOrder order);
    }
}
