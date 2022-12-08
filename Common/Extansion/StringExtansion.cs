using System;

namespace ElectronicQueue.Data.Common.Extansion
{
    public static class StringExtansion
    {
        public static string Reverse(this string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}