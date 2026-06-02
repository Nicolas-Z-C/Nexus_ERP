
using Nexus.Domain.Common.Result;
using Nexus.Domain.Validators;
using Nexus.Domain.ValueObjects.Common;

namespace Nexus.Domain.ValueObjects.IDs
{
    public class PersonelID : Base
    {
        private const int maxLenght = 20;

        private PersonelID(string value) : base(value) {}

        public static Result<PersonelID> Create(string value)
        {
            var resultado = Validate(value,DomainValidators.Upercase(),maxLenght);

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new PersonelID(resultado.Value);
        }
    }
}