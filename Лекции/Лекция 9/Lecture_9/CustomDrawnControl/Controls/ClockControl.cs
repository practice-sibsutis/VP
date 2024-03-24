using System;
using System.Diagnostics;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Microsoft.CodeAnalysis.Emit;

namespace CustomDrawnControl.Controls;

public class ClockControl : Control
{
    public IBrush? Background { get; set; }
    public IBrush HourHand { get; set; } = Brushes.Black;
    public IBrush MinuteHand { get; set; } = Brushes.Black;
    public IBrush Foreground { get; set; } = Brushes.Black;
    public int TextSize { get; set; } = 14;

    public DateTime Dt { get; set; } = DateTime.Now;

    public sealed override void Render(DrawingContext context)
    {
        base.Render(context);

        int margin = 10;

        var hour = DateTime.Now.Hour + DateTime.Now.Minute / 60.0;
        var minute = DateTime.Now.Minute + DateTime.Now.Second / 60.0;
        var second = DateTime.Now.Second + DateTime.Now.Millisecond / 1000.0;

        context.FillRectangle(
            Background,
            new Rect(0, 0, Bounds.Width, Bounds.Height));

        Point center = new Point(Bounds.Width / 2, Bounds.Height / 2);

        for (int i = 0; i < 12; i++)
        {
            Point tick = new Point(
                center.X + (Bounds.Width / 2 - margin) * Math.Sin(i * 2 * Math.PI / 12),
                center.Y - (Bounds.Height / 2 - margin) * Math.Cos(i * 2 * Math.PI / 12));

            var formattedText = new FormattedText(((i + 11) % 12 + 1).ToString(),
                CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                Typeface.Default, TextSize, Brushes.Black);
            
            context.DrawText(formattedText, new Point(tick.X - 2, tick.Y - 2));
        }

        Point hourHand = new Point(
            center.X + (Bounds.Width / 3 - margin) * Math.Sin(hour * 2 * Math.PI / 12),
            center.Y - (Bounds.Height / 3 - margin) * Math.Cos(hour * 2 * Math.PI / 12));
        Point minuteHand = new Point(
            center.X + (Bounds.Width / 2 - margin) * Math.Sin(minute * 2 * Math.PI / 60),
            center.Y - (Bounds.Height / 2 - margin) * Math.Cos(minute * 2 * Math.PI / 60));
        Point secondHand = new Point(
            center.X + (Bounds.Width / 2 - margin) * Math.Sin(second * 2 * Math.PI / 60),
            center.Y - (Bounds.Height / 2 - margin) * Math.Cos(second * 2 * Math.PI / 60));

        context.DrawLine(
            new Pen(HourHand, 5),
            center,
            hourHand);

        context.DrawLine(
            new Pen(MinuteHand, 3),
            center,
            minuteHand);

        context.DrawLine(
            new Pen(Brushes.Red, 1),
            center,
            secondHand);
    }
}