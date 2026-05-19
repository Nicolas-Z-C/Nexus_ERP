using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus.Domain.Errors.common
{
    
    public static class DomainErrors
    {
        public static class Personal
        {
            public static readonly Error DuplicatedDocument =
                new("Personal.DocumentoDuplicado",
                    "Ya existe un empleado con ese número de documento.");

            public static readonly Error FiredEmployee =
                new("Personal.EmpleadoDespedido",
                    "No se pueden realizar operaciones sobre un empleado Despedido.");
        }
    }
}