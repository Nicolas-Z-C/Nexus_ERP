using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Domain.Enums
{
    public enum TaskStatus
    {
        OnGoing = 1,
        Overdue = 2,
        Cancelled = 3,
        Reprogramed = 4,
    }
}