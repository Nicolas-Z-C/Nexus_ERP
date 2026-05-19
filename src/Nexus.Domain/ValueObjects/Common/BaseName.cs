using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Errors;


namespace Nexus.Domain.ValueObjects.Common
{
    public abstract class BaseName
    {
        public string Value {get; private set;}

        protected BaseName(string value)
        {
            Value = value;
        }

        protected static Result<string> Validate(string value, int lenght, Regex regex)
        {
            if(string.IsNullOrWhiteSpace(value))
                return new Error("Nombre.Vacio","El nombre no puede estar vacio"));
            
            if(value.Length > lenght)
                return new Error("Nombre.Longitud",$"El nombre excede la longitud {lenght}"));

            if(!regex.IsMatch(value))
                return new Error("Nombre.Formato","El nombre no cumple con el formato especificado"));
            
            return value;
        }
    }
}