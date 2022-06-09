using System;

namespace ElectronicQueue.Core.Application.Dto
{
    public class AccountDto : DtoBase
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AccountDto);
        }

        public bool Equals(AccountDto other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Login == other.Login &&
                   PasswordHash == other.PasswordHash;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Login, PasswordHash);
        }
    }
}
