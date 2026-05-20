using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.CatalogEntityes.ID
{
    public class IDType : CatalogEntity
    {
        private IDType(Name name) : base(name) {}

        public Result<IDType> Crear(string name)
        {
            var result = Name.Create(name);
            
            if(result.IsFailure)
                return result.Error;
            
            return new IDType(result.Value);
        }
    }
}