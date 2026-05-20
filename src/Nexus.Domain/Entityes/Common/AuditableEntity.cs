using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Domain.Entityes.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt {get; private set;} = DateTime.Now;
        public DateTime UpdatedAt {get; private set;} = DateTime.Now;

        internal AuditableEntity() {}
    
        public void Update()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}