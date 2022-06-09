namespace ElectronicQueue.Core.Application.Models
{
    public class AccountModel : ModelBase
    {
        private string login;
        private string passwordHash;

        public string Login { get => login; set => Set(ref login, value); }
        public string PasswordHash { get => passwordHash; set => Set(ref passwordHash, value); }
    }
}