using AdapterExample.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq;

namespace AdapterExample.Views
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

        private async void OnSaveMenuClick(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SavePeople(path);
                }
            }
        }
    }
}