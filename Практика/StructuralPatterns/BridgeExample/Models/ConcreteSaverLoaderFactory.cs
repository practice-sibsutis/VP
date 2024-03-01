using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeExample.Models
{
    public class ConcreteSaverLoaderFactory(ILoaderFactory loaderFactory, ISaverFactory saverFactory) : 
        PersonSaverLoaderFactory(loaderFactory, saverFactory)
    {
    }
}
