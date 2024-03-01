
using ApplicationWithFactoryMethod.Models;
using DecoratorExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace DecoratorExample.ViewModels
{
    public class MainWindowViewModel : ApplicationWithFactoryMethod.ViewModels.MainWindowViewModel
    {
        public void SavePeople(string path)
        {
            IEnumerable<BaseSaverLoaderFactory> baseSaverLoaderFactory =
                LoaderFactoryCollection as IEnumerable<BaseSaverLoaderFactory>;

            if (baseSaverLoaderFactory != null)
            {
                IPersonSaver personSaver = baseSaverLoaderFactory
                    .FirstOrDefault(factory => factory.IsMatch(path) == true)
                    .CreateSaver();

                if (personSaver != null)
                {
                    personSaver.Save(People, path);
                }
            }
        }
    }
}