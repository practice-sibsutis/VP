using Avalonia.Controls;
using Avalonia.Interactivity;
using ProxyExample.ViewModels;
using System.Linq;

namespace ProxyExample.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnOpenMenuClick(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadPeople(path[0]);
                }
            }
        }
    }
}