using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SubjectTracker;
public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null)
    {
        if (!Equals(field, newValue))
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        return false;
    }

    List<string>? dateComboBox;
    public List<string>? DateComboBox { get => dateComboBox; set => SetProperty(ref dateComboBox, value); }

}
