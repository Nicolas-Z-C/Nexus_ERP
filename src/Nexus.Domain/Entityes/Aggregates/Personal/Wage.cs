using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Enums;
using Nexus.Domain.Errors;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Personal
{
    public class Wage
    {
        public int ID {get; init;}
        public decimal Amount {get; private set;}
        public Currency Currency {get; private set;}

        //Enum

        public RemunerationType RemunerationType {get; private set;}

        //ef - constructor

        private Wage(decimal amount, Currency currency, RemunerationType remunerationType)
        {

            Amount = amount;
            Currency = currency;
            RemunerationType = remunerationType;
            ID = 0;
        }

        internal Wage() {}

        public static Result<Wage> Create(decimal amount, Currency currency, RemunerationType remunerationType)
        {
   
            if (amount <= 0)
                return Result<Wage>.Failure(new Error("Wage.TheEmployerIsAPieceOfShit","The wage of the eployee cannot be 0 or lower"));
            
            return Result<Wage>.Success(new(amount,currency,remunerationType));
            
        }

    }
}