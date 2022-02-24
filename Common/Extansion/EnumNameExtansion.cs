﻿using ElectronicQueue.Data.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicQueue.Data.Common.Extansion
{
    public static class EnumNameExtansion
    {
        public static IEnumerable<string> ToName(this Enum @enum)
        {
            return @enum.GetType().GetCustomAttributes(false).Select(x => (x as NameAttribute).Name);
        }
    }
}