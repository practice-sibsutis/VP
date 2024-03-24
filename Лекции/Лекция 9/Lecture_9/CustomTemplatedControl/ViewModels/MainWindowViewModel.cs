using ReactiveUI;
using System.Reactive;

namespace CustomTemplatedControl.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        private string textArea;

        public MainWindowViewModel()
        {
            TextArea = "Empty";
            ButtonCommand = ReactiveCommand.Create<string>(str => TextArea = str);
        }
        public string TextArea
        {
            get => textArea;
            set => this.RaiseAndSetIfChanged(ref textArea, value);
        }
        public ReactiveCommand<string, Unit> ButtonCommand { get; }
#pragma warning restore CA1822 // Mark members as static
    }
}
