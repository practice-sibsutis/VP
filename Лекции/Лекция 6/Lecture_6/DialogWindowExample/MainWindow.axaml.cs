using Avalonia.Controls;
using Avalonia.Input;

namespace DialogWindowExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CreateOpenFileDialogTapped(object? sender, TappedEventArgs e)
        {
            var files = await this.StorageProvider.OpenFilePickerAsync(
                new Avalonia.Platform.Storage.FilePickerOpenOptions
                {
                    Title = "Open Files",
                    AllowMultiple = false,
                });

            if (files.Count > 0)
            {
                Msg.Text = files[0].Name;
            }
        }

        private async void CreateSaveFileDialogTapped(object? sender, TappedEventArgs e)
        {
            var file = await this.StorageProvider.SaveFilePickerAsync(
                new Avalonia.Platform.Storage.FilePickerSaveOptions()
                {
                    Title = "Open Files",
                });

            if (file != null)
            {
                Msg.Text = file.Name;
            }
        }

        private async void CreateCustomDialogTapped(object? sender, TappedEventArgs e)
        {
            DialogWindow dialogWindow = new DialogWindow();

            string result = await dialogWindow.ShowDialog<string>(this);

            Msg.Text = result;
        }
    }
}