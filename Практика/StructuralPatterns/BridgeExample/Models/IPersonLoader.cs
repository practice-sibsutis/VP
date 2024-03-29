﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeExample.Models
{
    public interface IPersonLoader
    {
        IEnumerable<Person> ReLoad();
        IEnumerable<Person> Load(string path);
    }
}
