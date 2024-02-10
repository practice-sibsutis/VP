using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace ConverterExample;

public class TextToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string text && targetType.IsAssignableFrom(typeof(IBrush)))
        {
            Color.TryParse(text, out var color);
            return new SolidColorBrush(color);
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}