using Avalonia.Data.Converters;
using Avalonia.Media;

namespace FuncValueConverterExample;

public static class TextToColorConverter
{
    public static FuncValueConverter<string?, IBrush> ToColorConverter { get; } =
        new FuncValueConverter<string?, IBrush>(text =>
        {
            if (Color.TryParse(text, out Color color))
            {
                return new SolidColorBrush(color);
            }

            return null;
        });
}