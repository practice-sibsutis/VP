using ApplicationWithoutFactory.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Linq;

namespace ApplicationWithoutFactory.Views
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

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if(this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadPeople(path[0]);
                }
            }
        }
    }
}