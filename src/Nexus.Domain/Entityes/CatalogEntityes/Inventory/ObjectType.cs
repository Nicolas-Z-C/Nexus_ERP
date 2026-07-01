using System;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.CatalogEntityes.Inventory
{
    public class ObjectType : CatalogEntity
    {

        private ObjectType(Name name) : base(name) {}

        internal ObjectType() {}

        public static Result<ObjectType> Create(string name)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new ObjectType(result.Value);
        }

    }
}