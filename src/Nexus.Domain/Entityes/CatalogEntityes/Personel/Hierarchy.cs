using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.CatalogEntityes.Personel
{
    public class Hierarchy : CatalogEntity
    {
        private Hierarchy(Name name) : base(name) {}
        internal Hierarchy() {}

        public static Result<Hierarchy> Create(string name)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new Hierarchy(result.Value);
        }
    }
}