using ElectronicQueue.Core.Application.MvvmInfrastructure;

namespace ElectronicQueue.Core.Application.Model
{
    public abstract class ModelBase : ObservableBase
    {
        public long Id { get; set; }
    }
}
