using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Common.Attributes
{
    public class NameAttribute: Attribute
    {
        public string Name { get; set; }
        public NameAttribute()
        { }
        public NameAttribute(string name)
        {
            Name = name;
        }
    }
}
