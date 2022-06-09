using ElectronicQueue.Core.Application.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ElectronicQueue.Core.Application.Helpers
{
    public class HashFunctionMD5 : IHashFunction
    {
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}
