using Nexus.Application.DTOs.Common;

namespace Nexus.Application.DTOs.Entities.Tenant
{
    public record TenantDetailDTO(string Name,
    string TaxID,
    string ComercialName,
    AdressDTO Adress,
    string Email,
    string Number,
    );
}