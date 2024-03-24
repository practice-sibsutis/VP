using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CustomTemplatedControl.ViewModels;
using System;

namespace CustomTemplatedControl
{
    public class ViewLocator : IDataTemplate
    {
        public Avalonia.Controls.Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                var control = (Avalonia.Controls.Control)Activator.CreateInstance(type)!;
                control.DataContext = data;
                return control;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
