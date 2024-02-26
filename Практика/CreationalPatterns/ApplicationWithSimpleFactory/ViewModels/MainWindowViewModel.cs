
using ApplicationWithSimpleFactory.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Xml.Linq;
using System.Xml;

namespace ApplicationWithSimpleFactory.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Person> people;
        private string currentPath;
        public IPersonLoader PersonLoader { get; set; }
        public ILoaderFactory LoaderFactory { get; set; }

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
            if (LoaderFactory != null)
            {
                PersonLoader = LoaderFactory.CreateLoader(path);
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