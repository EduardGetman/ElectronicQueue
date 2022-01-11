using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ElectronicQueue.AdminClient.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ICommand RefreshDataCommand { get; }
        public ICommand SaveDataCommand { get; }
        public BaseViewModel()
        {
            RefreshDataCommand = new Command(RefreshData);
            SaveDataCommand = new Command(SaveData);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void RefreshData()
        {
            ClearData();
            LoadData();
        }

        protected abstract void ClearData();
        protected abstract void LoadData();
        protected abstract void SaveData();
    }
}