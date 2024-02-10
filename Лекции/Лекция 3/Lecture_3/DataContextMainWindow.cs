using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lecture_3;

public class DataContextMainWindow : INotifyPropertyChanged
{
    private string _text = "Hello World";

    public string Text
    {
        get
        {
            return _text;
        }

        set
        {
            _ = SetField(ref _text, value);
        }
    }

    public void ExecuteCommand()
    {
        Text = "Hello Avalonia";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

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