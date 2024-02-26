
using ApplicationWithoutFactory.Models;
using DynamicData;
using ReactiveUI;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Xml.Linq;

namespace ApplicationWithoutFactory.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Person> people;
        private XMLLoader loader;
        public MainWindowViewModel()
        {
            people = new ObservableCollection<Person>();
            loader = new XMLLoader();
        }

        public void LoadPeople(string path)
        {

            var personEnumerable = loader.Load(path);
            if (personEnumerable != null)
            {
                People = new ObservableCollection<Person>(personEnumerable);
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