using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;
using Nexus.Domain.ValueObjects.Common;

namespace Nexus.Domain.ValueObjects.Adresses
{
    public class Street : Base
    {
        private const int maxLenght = 50;

        private Street(string value) : base(value) {}

        public static Result<Street> Create(string value)
        {
            var resultado = Validate(value,maxLenght,DomainValidators.AlphaNumericWhitSpaces());

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new Street(resultado.Value);
        }
    }
}