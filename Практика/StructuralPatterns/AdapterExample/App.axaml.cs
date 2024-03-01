using AdapterExample.Models;
using AdapterExample.ViewModels;
using AdapterExample.Views;
using ApplicationWithFactoryMethod.Models.XML;
using ApplicationWithFactoryMethod.Models.JSON;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AdapterExample
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
                        LoaderFactoryCollection = new IPersonSaverLoaderFactory[]
                        {
                            new JSONSaverLoaderFactory(
                                new JSONLoaderFactory(),
                                new JSONSaverFactory()),

                            new XMLSaverLoaderFacctory(
                                new XMLLoaderFactory(),
                                new XMLSaverFactory()),
                        }
                    },
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}