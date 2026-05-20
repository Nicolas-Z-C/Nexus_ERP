using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;

namespace Nexus.Domain.ValueObjects.Common
{
    public class TelephoneNumber : Base
    {
        private const int maxLenght = 18;

        private TelephoneNumber(string value) : base(value) {}

        public static Result<TelephoneNumber> Create(string value)
        {
            var resultado = Validate(value,maxLenght,DomainValidators.PhoneNumber());

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new TelephoneNumber(resultado.Value);
        }
    }
}