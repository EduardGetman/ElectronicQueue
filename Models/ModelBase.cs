using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ElectronicQueue.Data.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        public long Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
