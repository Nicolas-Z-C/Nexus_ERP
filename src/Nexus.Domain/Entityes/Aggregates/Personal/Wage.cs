using Nexus.Domain.Common.Result;
using Nexus.Domain.Enums;
using Nexus.Domain.Errors;

namespace Nexus.Domain.Entityes.Aggregates.Personal
{
    public class Wage
    {
        public int ID {get; init;}
        public decimal Amount {get; private set;}
        public Currency Currency {get; private set;}

        //Enum

        public int RemunerationTypeID {get; private set;}

        //ef - constructor

        private Wage(decimal amount, Currency currency, int remunerationType)
        {

            Amount = amount;
            Currency = currency;
            RemunerationTypeID = remunerationType;
            ID = 0;
        }

        internal Wage() {}

        public static Result<Wage> Create(decimal amount, Currency currency, int remunerationType)
        {
   
            if (amount <= 0)
                return Result<Wage>.Failure(new Error("Wage.TheEmployerIsAPieceOfShit","The wage of the eployee cannot be 0 or lower"));
            
            return Result<Wage>.Success(new(amount,currency,remunerationType));
            
        }

    }
}