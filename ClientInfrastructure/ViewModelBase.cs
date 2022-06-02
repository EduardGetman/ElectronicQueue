using ElectronicQueue.Core.Application.Models;
using System.ComponentModel;
using System.Windows;

namespace ElectronicQueue.ClientInfrastructure
{
    public abstract class ViewModelBase : ObservableBase
    {
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public bool IsInDesignMode()
        {
            return Application.Current.MainWindow == null
                   || DesignerProperties.GetIsInDesignMode(Application.Current.MainWindow);
        }
    }
}