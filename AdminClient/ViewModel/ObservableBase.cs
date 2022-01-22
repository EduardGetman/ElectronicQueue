using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ElectronicQueue.AdminClient.ViewModel
{
    public class ObservableBase : INotifyPropertyChanged
    {
        public void Set<TValue>(ref TValue field,
                                TValue newValue,
                                [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<TValue>.Default.Equals(field, default(TValue)) || !field.Equals(newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
