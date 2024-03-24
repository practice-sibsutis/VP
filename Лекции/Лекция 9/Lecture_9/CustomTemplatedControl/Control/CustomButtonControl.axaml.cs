using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace CustomTemplatedControl.Control
{
    public class CustomButtonControl : TemplatedControl
    {
        public static readonly StyledProperty<ICommand> LeftButtonCommandProperty =
            AvaloniaProperty.Register<CustomButtonControl, ICommand>("LeftButtonCommand");

        public ICommand LeftButtonCommand
        {
            get => GetValue(LeftButtonCommandProperty);
            set => SetValue(LeftButtonCommandProperty, value);
        }

        public static readonly StyledProperty<object> LeftButtonCommandParameterProperty =
            AvaloniaProperty.Register<CustomButtonControl, object>("LeftButtonCommandParameter");

        public object LeftButtonCommandParameter
        {
            get => GetValue(LeftButtonCommandParameterProperty);
            set => SetValue(LeftButtonCommandParameterProperty, value);
        }


        public static readonly StyledProperty<ICommand> RightButtonCommandProperty =
            AvaloniaProperty.Register<CustomButtonControl, ICommand>("RightButtonCommand");

        public ICommand RightButtonCommand
        {
            get => GetValue(RightButtonCommandProperty);
            set => SetValue(RightButtonCommandProperty, value);
        }

        public static readonly StyledProperty<object> RightButtonCommandParameterProperty =
            AvaloniaProperty.Register<CustomButtonControl, object>("RightButtonCommandParameter");

        public object RightButtonCommandParameter
        {
            get => GetValue(RightButtonCommandParameterProperty);
            set => SetValue(RightButtonCommandParameterProperty, value);
        }
    }
}
