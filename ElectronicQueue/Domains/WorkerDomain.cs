namespace ElectronicQueue.Data.Domains
{
    /// <summary>
    /// Работник
    /// </summary>
    public class WorkerDomain: DomainBase
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public ulong? PointId { get; set; }
        public ServicePointDomain Point { get; set; }
    }
}
