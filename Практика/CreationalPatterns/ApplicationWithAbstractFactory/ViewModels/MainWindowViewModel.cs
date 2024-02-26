
using ApplicationWithAbstractFactory.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ApplicationWithAbstractFactory.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Person> people;
        public IEnumerable<ISaverLoaderFactory> SaverLoaderFactoryCollection { get; set; }

        public MainWindowViewModel()
        {
            people = new ObservableCollection<Person>();
        }

        public void LoadPeople(string path)
        {
            var personLoader = SaverLoaderFactoryCollection
                .FirstOrDefault(factory => factory.IsMatch(path) == true)?
                .CreateLoader();

            if (personLoader != null)
            {
                People = new ObservableCollection<Person>(personLoader.Load(path));
            }
        }

        public void SavePeople(string path)
        {
            var personSaver = SaverLoaderFactoryCollection
                .FirstOrDefault(factory => factory.IsMatch(path) == true)?
                .CreateSaver();

            if (personSaver != null)
            {
                personSaver.Save(People, path);
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
    }
}