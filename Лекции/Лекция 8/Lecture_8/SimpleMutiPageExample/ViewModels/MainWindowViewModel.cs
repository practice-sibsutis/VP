using ReactiveUI;
using SimpleMultiPageExample.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SimpleMultiPageExample.ViewModels;
using DynamicData;
using SimpleMultiPageExample.ViewModels.Pages;

namespace SimpleMultiPageExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object content;
        private ObservableCollection<BasePageViewModel> vmbaseCollection;

        public MainWindowViewModel()
        {
            vmbaseCollection = new ObservableCollection<BasePageViewModel>();
            vmbaseCollection.Add(new WelcomeViewModel());
            vmbaseCollection.Add(new AuthorizationViewModel());

            Content = vmbaseCollection[0];

        }

        public object Content
        {
            get => content;
            set
            {
                this.RaiseAndSetIfChanged(ref content, value);
            }
        }

        public ObservableCollection<BasePageViewModel> VmbaseCollection
        {
            get => vmbaseCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref vmbaseCollection, value);
            }
        }

    }
}
