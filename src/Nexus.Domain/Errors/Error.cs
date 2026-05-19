using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Domain.Errors
{
    public sealed record class Error(string codigo,string Emessage)
    {
        public static readonly Error None = new(string.Empty,string.Empty);
    }
}