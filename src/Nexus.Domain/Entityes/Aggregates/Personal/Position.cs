using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.Interfaces.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Personal
{
    public class Position : CatalogEntity, Itenant
    {
        
        public Guid TenantId {get; set;}
        public int HierarchyId {get; private set;}
        private Position(Name name, int hierarchyId, Guid tenant) : base(name)
        {
            HierarchyId = hierarchyId;
            TenantId = tenant;
        }

        internal Position() {}
        public static Result<Position> Create(string name, int hierarchyId, Guid tenant)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return Result<Position>.Success(new Position(result.Value,hierarchyId,tenant));
        }
        
    }
}