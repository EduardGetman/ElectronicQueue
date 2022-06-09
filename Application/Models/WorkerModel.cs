namespace ElectronicQueue.Core.Application.Models
{
    public class WorkerModel : ModelBase
    {
        private string name;
        private long? pointId;
        private ServicePointModel point;
        private AccountModel _account;

        public string Name { get => name; set => Set(ref name, value); }
        public long? PointId { get => pointId; set => Set(ref pointId, value); }
        public ServicePointModel Point { get => point; set => Set(ref point, value); }
        public AccountModel Account { get => _account; set => Set(ref _account, value); }
        public string PointName => Point?.Location ?? "Не определён";
        public string StateName => Point?.ServicePointStateName ?? "Не находиться на точке обслуживания";
    }
}