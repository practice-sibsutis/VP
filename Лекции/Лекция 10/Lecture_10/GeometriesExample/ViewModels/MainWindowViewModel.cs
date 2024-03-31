using System.Collections.ObjectModel;
using ReactiveUI;

namespace GeometriesExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

#pragma warning disable CA1822 // Mark members as static
        public MainWindowViewModel()
        {
            ViewModels = new ObservableCollection<BaseViewModel>();
            ViewModels.Add(new GeometriesViewModel());
            ViewModels.Add(new CombinedGeometryViewModel());
            ViewModels.Add(new PathGeometryViewModel());

            ViewModel = ViewModels[0];
        }

        public ObservableCollection<BaseViewModel> ViewModels
        {
            get => _viewModels;
            set => this.RaiseAndSetIfChanged(ref _viewModels, value);
        }

        public BaseViewModel ViewModel
        {
            get => _viewModel;
            set => this.RaiseAndSetIfChanged(ref _viewModel, value);
        }

        private ObservableCollection<BaseViewModel> _viewModels;
        private BaseViewModel _viewModel;
#pragma warning restore CA1822 // Mark members as static
    }
}
