using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Domain.Enums
{
    public enum Task_status
    {
        OnGoing = 1,
        Overdue = 2,
        Cancelled = 3,
        Reprogramed = 4,
        Finished = 5,
    }
}