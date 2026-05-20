using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Domain.Interfaces.Common
{
    public interface Itenant
    {
       public Guid TenantId {get; set;}
    }
}