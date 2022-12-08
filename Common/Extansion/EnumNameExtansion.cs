﻿using ElectronicQueue.Data.Common.Attributes;
using System;
using System.Linq;

namespace ElectronicQueue.Data.Common.Extansion
{
    public static class EnumNameExtansion
    {
        public static string ToName(this Enum enumValues)
        {
            return enumValues.GetType().GetMember(enumValues.ToString())[0].GetCustomAttributes(false).Select(x => (x as NameAttribute).Name).FirstOrDefault();
        }
    }
}
