using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMultiPageExample.ViewModels.Pages
{
    public abstract class BasePageViewModel : ViewModelBase
    {
        public string Header => GetName();
        public abstract string GetName();

        
    }
}
