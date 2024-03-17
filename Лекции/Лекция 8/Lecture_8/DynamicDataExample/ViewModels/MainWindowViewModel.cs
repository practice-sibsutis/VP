using System;
using DynamicData.Binding;
using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace DynamicDataExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static

        private readonly ReadOnlyObservableCollection<SimpleItemViewModel> _checkedItems;
        private readonly ReadOnlyObservableCollection<SimpleItemViewModel> _uncheckedItems;
        private readonly SourceList<SimpleItemViewModel> _sourceList = new SourceList<SimpleItemViewModel>();
        private ObservableCollection<SimpleItemViewModel> _checkedSources;
        private string txt;

        public ReadOnlyObservableCollection<SimpleItemViewModel> CheckedItems => _checkedItems;
        public ReadOnlyObservableCollection<SimpleItemViewModel> UncheckedItems => _uncheckedItems;

        public ObservableCollection<SimpleItemViewModel> CheckedSources
        {
            get => _checkedSources;
            set { _checkedSources = value; }
        }

        public string Txt
        {
            get => txt;
            set { this.RaiseAndSetIfChanged(ref txt, value); }
        }

        public MainWindowViewModel()
        {
            _checkedSources = new ObservableCollection<SimpleItemViewModel>();
            _checkedSources.Add(new SimpleItemViewModel { IsSelected = true });
            _checkedSources.Add(new SimpleItemViewModel { IsSelected = true });
            _checkedSources.Add(new SimpleItemViewModel { IsSelected = true });

            _sourceList.Connect()
                .AutoRefresh().Filter(x => x.IsSelected)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _checkedItems)
                .Subscribe(x => { Txt += x.First().Item.Current.IsSelected.ToString(); });

            _sourceList.Connect()
                .AutoRefresh().Filter(x => !x.IsSelected)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _uncheckedItems).Subscribe();

            _sourceList.Add(new SimpleItemViewModel { IsSelected = true });
            _sourceList.Add(new SimpleItemViewModel { IsSelected = false });
            _sourceList.Add(new SimpleItemViewModel { IsSelected = true });
            _sourceList.Add(new SimpleItemViewModel { IsSelected = false });
            _sourceList.Add(new SimpleItemViewModel { IsSelected = true });
            _sourceList.Add(new SimpleItemViewModel { IsSelected = false });
            _sourceList.Add(new SimpleItemViewModel { IsSelected = true });
        }
    }

    public class SimpleItemViewModel : AbstractNotifyPropertyChanged
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetAndRaise(ref _isSelected, value); }
        }
    }
#pragma warning restore CA1822 // Mark members as static

}
