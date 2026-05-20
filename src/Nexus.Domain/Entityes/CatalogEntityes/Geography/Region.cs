using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.CatalogEntityes.Geography
{
    public class Region : CatalogEntity
    {
        public int CountryID {get; private set;}
        private Region(Name name, int countryID) : base(name)
        {
            CountryID = countryID;
        }

        internal Region() {}

        public static Result<Region> Create(string name, int countryID)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new Region(result.Value, countryID);
        }
    }
}