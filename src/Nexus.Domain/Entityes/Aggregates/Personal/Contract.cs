using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Personal
{
    public class Contract : CatalogEntity
    {
        public int WageID {get; private set;}
        private Contract(Name name, int wageID) : base(name) => WageID = wageID;

        internal Contract() {}

        public static Result<Contract> Create(string name, int wageID)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new Contract(result.Value, wageID);
        }
    }
}