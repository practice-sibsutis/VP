using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWithDataTemplate
{
    internal class DataContextWithTeacher : INotifyPropertyChanged
    {
        public DataContextWithTeacher()
        {
            Teacher = new Teacher()
            {
                FirstName = "Anton",
                LastName = "Mileshko",
            };
        }
        public Teacher? Teacher
        {
            get => _teacher;
            set => _ = SetField(ref _teacher, value);
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private Teacher? _teacher;

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
