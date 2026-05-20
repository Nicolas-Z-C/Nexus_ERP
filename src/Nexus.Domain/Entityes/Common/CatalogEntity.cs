using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.ValueObjects.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Common
{
    public abstract class CatalogEntity 
    {

        public int ID {get; private set;}
        public Name Name {get; private set;}

        protected CatalogEntity(Name name)
        {
            Name = name;
        }

        protected CatalogEntity() {}

        public Result ChangeName(string name)
        {
            
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            Name = result.Value;
            return Result.Success();

        }
    }
}