using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.JSON;
using ApplicationWithFactoryMethod.Models.XML;
using ApplicationWithFactoryMethod.ViewModels;
using ApplicationWithFactoryMethod.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace ApplicationWithFactoryMethod
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
                        LoaderFactoryCollection = new ILoaderFactory[]
                        {
                            new XMLLoaderFactory(),
                            new JSONLoaderFactory()
                        },
                    },
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}