using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxWithCanvas
{
    internal class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public IBrush? Fill { get; set; }
    }
}
