
using ApplicationWithFactoryMethod.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ApplicationWithFactoryMethod.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Person> people;
        private string currentPath;
        public IPersonLoader PersonLoader { get; set; }
        public IEnumerable<ILoaderFactory> LoaderFactoryCollection { get; set; }

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

            if(loader != null)
            {
                PersonLoader = loader;
                People = new ObservableCollection<Person>(PersonLoader.Load(path));
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