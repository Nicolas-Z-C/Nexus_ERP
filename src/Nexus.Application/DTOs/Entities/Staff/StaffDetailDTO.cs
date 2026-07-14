using Nexus.Application.DTOs.Common;
using Nexus.Domain.ValueObjects.IDs;

namespace Nexus.Application.DTOs.Entities.Staff
{
    public record StaffDetailDTO(string Name,
    Guid Id,
    PersonelID ID,
    AdressDTO Adress,
    string Email,
    string Number,
    DateOnly  DateOfJoining,
    int WeekWorkedHours,
    string Status,
    decimal Wage,
    string CurrencySymbol,
    string Currency,
    string Position);
}