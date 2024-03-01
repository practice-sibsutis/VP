using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BridgeExample.Models;
using ReactiveUI;

namespace BridgeExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        private ObservableCollection<Person> people;
        private string currentPath;
        public IPersonLoader PersonLoader { get; set; }
        public IEnumerable<PersonSaverLoaderFactory> LoaderFactoryCollection { get; set; }

        public string CurrentPath
        {
            get
            {
                return currentPath;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref currentPath, value);
            }
        }
        public MainWindowViewModel()
        {
            people = new ObservableCollection<Person>();
        }

        public void LoadPeople(string path)
        {
            var loader = LoaderFactoryCollection
                .FirstOrDefault(factory => factory.IsMatch(path) == true)?
                .CreateLoader();

            if (loader != null)
            {
                PersonLoader = loader;
                People = new ObservableCollection<Person>(PersonLoader.Load(path));
            }
        }

        public void SavePeople(string path)
        {
            if (LoaderFactoryCollection is IEnumerable<ISaverFactory> saverLoaderFactoryCollection)
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

        public ObservableCollection<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref people, value);
            }
        }
#pragma warning restore CA1822 // Mark members as static
    }
}
