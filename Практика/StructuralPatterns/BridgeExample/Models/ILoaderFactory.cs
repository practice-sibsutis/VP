﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeExample.Models
{
    public interface ILoaderFactory
    {
        IPersonLoader CreateLoader();

        bool IsMatch(string path);
    }
}
