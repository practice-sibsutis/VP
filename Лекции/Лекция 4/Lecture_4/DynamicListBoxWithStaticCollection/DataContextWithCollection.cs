using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamicListBoxWithStaticCollection
{
    internal class DataContextWithCollection : INotifyPropertyChanged
    {
        public DataContextWithCollection()
        {
            Collection = new List<string>{"String 1", "String 2", "String 3", "String 4", "String 5"};
        }

        public List<string> Collection
        {
            get => _collection;
            set => _ = SetField(ref _collection, value);
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        public void RemoveData(string str)
        {
            Collection.Remove(str);
        }

        private List<string> _collection;

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
