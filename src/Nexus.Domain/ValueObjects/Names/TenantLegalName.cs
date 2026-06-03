using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;
using Nexus.Domain.ValueObjects.Common;

namespace Nexus.Domain.ValueObjects.Names
{
    public class TenantLegalName : Base
    {
        private const int maxLenght = 100;

        private TenantLegalName(string value) : base(value) {}

        public static Result<TenantLegalName> Create(string value)
        {
            var resultado = Validate(value,DomainValidators.AlphaNumericWhitSpaces(),maxLenght);

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new TenantLegalName(resultado.Value);
        }
    }
}