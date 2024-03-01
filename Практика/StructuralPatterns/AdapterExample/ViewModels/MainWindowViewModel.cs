
using AdapterExample.Models;
using ApplicationWithFactoryMethod.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdapterExample.ViewModels
{
    public class MainWindowViewModel : ApplicationWithFactoryMethod.ViewModels.MainWindowViewModel
    {
        public void SavePeople(string path)
        {
            if(LoaderFactoryCollection is IEnumerable<ISaverFactory> saverLoaderFactoryCollection)
            {
                IPersonSaver personSaver = saverLoaderFactoryCollection
                    .FirstOrDefault(factory => (factory).IsMatch(path) == true)
                    .CreateSaver();
                if (personSaver != null)
                {
                    personSaver.Save(People, path);
                }
            }

            
        }
    }
}