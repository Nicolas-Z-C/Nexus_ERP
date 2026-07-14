using Nexus.Application.DTOs.Entities.Staff;

namespace Nexus.Application.DTOs.Entities.Proyect
{
    public record AssignementDetailDTO(
        Guid Id,
        string Name,
        bool DelayFlag,
        string Status,
        StaffCardDTO StaffAsigned);
}