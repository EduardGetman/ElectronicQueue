using ElectronicQueue.Core.Application.Interfaces;

namespace ElectronicQueue.Core.Application.Helpers
{
    public class HashFunctionFactory
    {
        public static IHashFunction GetDefoultHashFunction() => new HashFunctionMD5();
    }
}
