using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.CatalogEntityes.Geography
{
    public class City : CatalogEntity
    {
        public int RegionID {get; private set;}
        private City(Name name, int regionID) : base(name)
        {
            RegionID = regionID;
        }

        internal City() {}

        public static Result<City> Create(string name, int regionID)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new City(result.Value, regionID);
        }
    }
}