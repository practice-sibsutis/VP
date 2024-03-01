using Avalonia.Controls;
using Avalonia.Input;

namespace DialogWindowExample
{
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        private void CloseDialogButtonTapped(object? sender, TappedEventArgs e)
        {
            this.Close("Close");
        }
    }
}
