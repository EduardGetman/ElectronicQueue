namespace ElectronicQueue.Data.Models
{
    public class WorkerModel
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public long? PointId { get; set; }
        public ServicePointModel Point { get; set; }
    }
}