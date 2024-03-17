using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMultiPageExample.ViewModels;

namespace SimpleMultiPageExample.ViewModels.Pages
{
    public class WelcomeViewModel : BasePageViewModel
    {
        public override string GetName()
        {
            return "Welcome Page";
        }
    }
}
