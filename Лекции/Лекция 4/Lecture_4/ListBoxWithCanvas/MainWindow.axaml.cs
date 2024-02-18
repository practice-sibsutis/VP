using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ListBoxWithCanvas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void TapOnSquare(object sender, TappedEventArgs routedEventArgs)
        {
            if(routedEventArgs.Source is Rectangle rectangle)
            {
                rectangle.Fill = Brushes.Black;
            }
        }
    }
}