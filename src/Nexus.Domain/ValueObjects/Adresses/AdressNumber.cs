using System;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;
using Nexus.Domain.ValueObjects.Common;

namespace Nexus.Domain.ValueObjects.Adresses
{
    public class AdressNumber : Base
    {
        private const int maxLenght = 100;

        private AdressNumber(string value) : base(value) {}

        public static Result<AdressNumber> Create(string value)
        {
            var resultado = Validate(value,maxLenght,DomainValidators.AlphaNumeric());

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new AdressNumber(resultado.Value);
        }
    }
}