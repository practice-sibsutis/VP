using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace ListBoxWithCanvas
{
    internal class DataContextWithSquares : INotifyPropertyChanged
    {
        public DataContextWithSquares()
        {
            Squares = new[]
            {
                new Square() { X = 0, Y = 0, Width = 100, Fill = Brushes.Aquamarine },
                new Square() { X = 50, Y = 50, Width = 100, Fill = Brushes.DarkSeaGreen },
                new Square() { X = 100, Y = 100, Width = 100, Fill = Brushes.DarkBlue},
                new Square() { X = 150, Y = 150, Width = 100, Fill = Brushes.DeepPink },
                new Square() { X = 200, Y = 250, Width = 100, Fill = Brushes.DeepSkyBlue },
                new Square() { X = 250, Y = 300, Width = 100, Fill = Brushes.BlanchedAlmond },
                new Square() { X = 300, Y = 350, Width = 100, Fill = Brushes.LightGoldenrodYellow },
                new Square() { X = 350, Y = 400, Width = 100, Fill = Brushes.Brown },
            };
        }
        public Square[] Squares
        {
            get => _squares;
            set => _ = SetField(ref _squares, value);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private Square[] _squares;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
