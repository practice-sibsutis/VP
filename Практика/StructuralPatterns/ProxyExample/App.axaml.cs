using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.JSON;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ProxyExample.Models;
using ProxyExample.ViewModels;
using ProxyExample.Views;

namespace ProxyExample
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
                        LoaderFactoryCollection = new ILoaderFactory[]
                        {
                            new ProxyLoaderFactory(),
                            new JSONLoaderFactory(),
                        }
                    },
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}