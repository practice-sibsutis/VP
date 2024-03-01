using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using BridgeExample.Models;
using BridgeExample.ViewModels;
using BridgeExample.Views;

namespace BridgeExample
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
                    DataContext = new MainWindowViewModel()
                    {
                        LoaderFactoryCollection = new PersonSaverLoaderFactory[]
                        {
                            new ConcreteSaverLoaderFactory(new XMLLoaderFactory(), new XMLSaverFactory()),
                            new ConcreteSaverLoaderFactory(new JSONLoaderFactory(), new JSONSaverFactory())
                        },
                    },

                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}