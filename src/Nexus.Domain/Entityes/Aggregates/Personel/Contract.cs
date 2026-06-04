using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Personel
{
    public class Contract : CatalogEntity
    {
        public int WageID {get; private set;}
        public int MaximWeeklytotalWorkHours{get; private set;}
        public int MaximWeeklynormalWorkHours{get; private set;}

        private Contract(Name name, int wageID, int weekly, int totalweekly) : base(name) 
        {
            WageID = wageID;
            MaximWeeklynormalWorkHours = weekly;
            MaximWeeklytotalWorkHours = totalweekly;
        }
        internal Contract() {}

        public static Result<Contract> Create(string name, int wageID, int weekly, int totalweekly)
        {
            var result = Name.Create(name);

            if(result.IsFailure)
                return result.Error;
            
            return new Contract(result.Value, wageID, weekly, totalweekly);
        }
    }
}