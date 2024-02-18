using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamicListBoxWithDynamicCollection
{
    internal class DataContextWithCollection : INotifyPropertyChanged
    {
        public DataContextWithCollection()
        {
            Collection = new ObservableCollection<string>(
                new string[]{"String 1", "String 2", "String 3", "String 4", "String 5"});
        }

        public ObservableCollection<string> Collection
        {
            get => _collection;
            set => _ = SetField(ref _collection, value);
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        public void RemoveData(string str)
        {
            Collection.Remove(str);
        }

        private ObservableCollection<string> _collection;

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
