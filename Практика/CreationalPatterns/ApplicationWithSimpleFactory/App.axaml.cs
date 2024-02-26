using ApplicationWithSimpleFactory.Models;
using ApplicationWithSimpleFactory.ViewModels;
using ApplicationWithSimpleFactory.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace ApplicationWithSimpleFactory
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel
                    {
                        LoaderFactory = new SimpleLoaderFactory(),
                    },
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}