using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.CatalogEntityes.Geography
{
    public class Country : CatalogEntity
    {

        public int ContinentID {get; private set;}
        private Country(Name name, int continentID) : base(name)
        {
            ContinentID = continentID;
        }

        internal Country() {}
        public static Result<Country> Create(string name, int continentID)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new Country(result.Value, continentID);
        }
    }
}