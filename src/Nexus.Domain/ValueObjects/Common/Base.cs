using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Errors;
using Nexus.Domain.Validators;


namespace Nexus.Domain.ValueObjects.Common
{
    public abstract class Base
    {
        public string Value {get; private set;}

        protected Base(string value)
        {
            Value = value;
        }

        protected static Result<string> Validate(string value, Regex regex, int lenght = 10)
        {
            if(regex == DomainValidators.Password())
            {
                if(string.IsNullOrWhiteSpace(value))
                return new Error("Contraseña.Vacia","La Contraseña no puede estar vacia");
            
                if(value.Length < lenght)
                    return new Error("Contraseña.Longitud",$"La Contraseña debe tener al menos 10 caracteres");

                if(!regex.IsMatch(value))
                    return new Error("Contraseña.Formato","La Contraseña no cumple con el formato especificado");
                
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            }

            if(string.IsNullOrWhiteSpace(value))
                return new Error("Propiedad.Vacio","La Propiedad no puede estar vacia");
            
            if(value.Length > lenght)
                return new Error("Propiedad.Longitud",$"La Propiedad excede la longitud {lenght}");

            if(!regex.IsMatch(value))
                return new Error("Propiedad.Formato","La Propiedad no cumple con el formato especificado");
            
            return value;
        }
    }
}