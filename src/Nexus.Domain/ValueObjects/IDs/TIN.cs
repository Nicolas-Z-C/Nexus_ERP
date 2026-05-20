using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;
using Nexus.Domain.ValueObjects.Common;

namespace Nexus.Domain.ValueObjects.IDs
{
    public class TIN : Base
    {
        private const int maxLenght = 100;

        private TIN(string value) : base(value) {}

        public static Result<TIN> Create(string value)
        {
            var resultado = Validate(value,maxLenght,DomainValidators.AlphaNumericWhitSpaces());

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new TIN(resultado.Value);
        }
    }
}