namespace Nexus.Application.DTOs.Entities.Proyect
{
    public record ProyectDetailDTO(string Name,
    Guid Id,
    decimal Budget,
    decimal ContractValue,
    decimal Profit,
    string Currency,
    string CurrencySymbol,
    int DurationInDays,
    DateOnly Start,
    DateOnly Release,
    bool DelayFlag,
    IReadOnlyCollection<AssignementCardDTO>? Assignements
    );
}