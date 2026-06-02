using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nexus.Domain.Validators
{
    public static partial class DomainValidators
    {
            // --- Patrones de Identificación ---
    [GeneratedRegex(@"^\d+$")]
    public static partial Regex OnlyNumbers();
    
    [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#_\-.])[A-Za-z\d@$!%*?&#_\-.]{10,}$")]
    public static partial Regex Password();

    [GeneratedRegex(@"^[A-Z]+$")]
    public static partial Regex Upercase();

    [GeneratedRegex(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ]+$")]
    public static partial Regex AlphaNumeric();

    [GeneratedRegex(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ ]+$")]
    public static partial Regex AlphaNumericWhitSpaces();

    // --- Patrones de Contacto ---
    [GeneratedRegex(@"^\+?\d{1,15}$")]
    public static partial Regex PhoneNumber();

    [GeneratedRegex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
    public static partial Regex Email();

    // --- Patrones de Texto ---
    [GeneratedRegex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")]
    public static partial Regex TextWithSpaces();


    }
}
