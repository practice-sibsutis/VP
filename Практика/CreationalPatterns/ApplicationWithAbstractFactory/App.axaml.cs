using ApplicationWithAbstractFactory.Models;
using ApplicationWithAbstractFactory.ViewModels;
using ApplicationWithAbstractFactory.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace ApplicationWithAbstractFactory
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
                        SaverLoaderFactoryCollection = new ISaverLoaderFactory[]
                        {
                            new XMLSaverLoaderFactory(),
                            new JSONSaverLoaderFactory(),
                        },
                    },
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}