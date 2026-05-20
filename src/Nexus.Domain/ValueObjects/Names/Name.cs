using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;
using Nexus.Domain.ValueObjects.Common;

namespace Nexus.Domain.ValueObjects.Names
{
    public class Name : Base
    {

        private const int maxLenght = 100;

        private Name(string value) : base(value) {}

        public static Result<Name> Create(string value)
        {
            var resultado = Validate(value,maxLenght,DomainValidators.Upercase());

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new Name(resultado.Value);
        }
    }
}