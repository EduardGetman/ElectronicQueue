namespace ElectronicQueue.Core.Domain
{
    /// <summary>
    /// Аккаунт
    /// </summary>
    public class AccountDomain : DomainBase
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public WorkerDomain Worker { get; set; }
    }
}
