using ElectronicQueue.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Data.Domains
{
    public class QueueLog:DomainBase
    {
        public DateTime EventDateTime { get; set; }
        public EventKind MyProperty { get; set; }
    }
}
