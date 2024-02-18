using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace ListBoxWithWrapPanel
{
    internal class DataContextWithSquares : INotifyPropertyChanged
    {
        public DataContextWithSquares()
        {
            Squares = new[]
            {
                new Square() { Width = 100, Fill = Brushes.Aquamarine },
                new Square() { Width = 100, Fill = Brushes.DarkSeaGreen },
                new Square() { Width = 100, Fill = Brushes.DarkBlue },
                new Square() { Width = 100, Fill = Brushes.DeepPink },
                new Square() { Width = 100, Fill = Brushes.DeepSkyBlue },
                new Square() { Width = 100, Fill = Brushes.BlanchedAlmond },
                new Square() { Width = 100, Fill = Brushes.LightGoldenrodYellow },
                new Square() { Width = 100, Fill = Brushes.Brown },
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
