using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;

namespace Nexus.Domain.ValueObjects.Common
{
    public class Email : Base
    {
        private const int maxLenght = 100;

        private Email(string value) : base(value) {}

        public static Result<Email> Create(string value)
        {
            var resultado = Validate(value,maxLenght,DomainValidators.Email());

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new Email(resultado.Value);
        }
    }
}