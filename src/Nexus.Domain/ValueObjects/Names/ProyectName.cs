using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;
using Nexus.Domain.ValueObjects.Common;

namespace Nexus.Domain.ValueObjects.Names
{
    public class ProyectName : Base
    {
        private const int maxLenght = 50;

        private ProyectName(string value) : base(value) {}

        public static Result<ProyectName> Create(string value)
        {
            var resultado = Validate(value,DomainValidators.AlphaNumericWhitSpaces(),maxLenght);

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new ProyectName(resultado.Value);
        }
    }
}