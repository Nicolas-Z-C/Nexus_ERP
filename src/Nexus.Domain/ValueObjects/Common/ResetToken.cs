using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Errors;
using Nexus.Domain.Validators;

namespace Nexus.Domain.ValueObjects.Common
{
    public class ResetToken : Base
    {   
        private const int MaxLenght = 4;
        private DateTime ExpirationDate {get;} = DateTime.UtcNow.AddMinutes(40);
        private ResetToken(string value) : base(value) {}

        public static Result<ResetToken> Create(string value)
        {
            var resultado = Validate(value,DomainValidators.OnlyNumbers(),MaxLenght);

            if(resultado.IsFailure)
                return resultado.Error;
            
            return new ResetToken(resultado.Value);
        }

        public Result ValidateCode(string code, DateTime currenTime)
        {
            
            if(ExpirationDate < currenTime)
                return Result.Failure(new Error("Codigo.Expirado","El codigo ha expirado vuelva a intenarlo"));
            
            if(string.IsNullOrWhiteSpace(code))
                return Result.Failure(new Error("Codigo.Vacio","El codigo esta vacio vuelva a intenarlo"));
            
            if(code != Value)
                return Result.Failure(new Error("Codigo.Invalido", "El codigo introducido es invalido"));
            
            return Result.Success();
        }
    }
}