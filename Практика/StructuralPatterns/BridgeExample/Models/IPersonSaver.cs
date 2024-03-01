﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeExample.Models
{
    public interface IPersonSaver
    {
        void Save(IEnumerable<Person> people, string path);
    }
}
