using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Domain.Entityes.Common
{
    public abstract class BaseEntity
    {
        public Guid Id {get; init;}
        
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

    }
}