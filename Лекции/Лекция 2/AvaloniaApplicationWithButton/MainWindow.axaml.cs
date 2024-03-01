using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplicationWithButton
{
    public partial class MainWindow : Window
    {
        private int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ButtonClickHandler(object? sender, RoutedEventArgs args)
        {
            ++counter;
            Label clickCounter = this.GetControl<Label>("ClickCounter");
            clickCounter.Content = counter.ToString();
        }
    }
}