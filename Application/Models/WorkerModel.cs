namespace ElectronicQueue.Core.Application.Model
{
    public class WorkerModel
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public long? PointId { get; set; }
        public ServicePointModel Point { get; set; }
    }
}