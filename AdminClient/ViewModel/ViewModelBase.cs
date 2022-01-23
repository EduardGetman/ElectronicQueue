using ElectronicQueue.AdminClient.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ElectronicQueue.AdminClient.ViewModel
{
    public abstract class ViewModelBase : ObservableBase
    {
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool IsInDesignMode()
        {
            return Application.Current.MainWindow != null
                   || DesignerProperties.GetIsInDesignMode(Application.Current.MainWindow);
        }
    }
}