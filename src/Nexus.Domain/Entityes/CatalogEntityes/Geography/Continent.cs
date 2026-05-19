using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.CatalogEntityes.Geography
{
    public class Continent : CatalogEntity
    {
        private Continent(Name name) : base(name) {}

        public static Result<Continent> Create(string name)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new Continent(result.Value);
        }
    }
}