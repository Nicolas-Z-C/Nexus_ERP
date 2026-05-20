
using Nexus.Domain.Common.Result;
using Nexus.Domain.Errors;
using Nexus.Domain.Validators;

namespace Nexus.Domain.ValueObjects.Common
{
    public class Password : Base
    {
        private Password(string value) : base(value) {}

        public static Result<Password> Create(string value)
        {
            var resultado = Validate(value,DomainValidators.Password());

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new Password(resultado.Value);
        }
    } 
}