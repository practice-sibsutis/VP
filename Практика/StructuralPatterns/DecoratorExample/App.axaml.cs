using ApplicationWithFactoryMethod.Models.XML;
using ApplicationWithFactoryMethod.Models.JSON;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DecoratorExample.Models;
using DecoratorExample.ViewModels;
using DecoratorExample.Views;

namespace DecoratorExample
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
                        LoaderFactoryCollection = new BaseSaverLoaderFactory[]
                        {
                            new JSONSaverLoaderFactory(new JSONLoaderFactory()),
                            new XMLSaverLoaderFactory(new XMLLoaderFactory()),
                        }
                    },
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}