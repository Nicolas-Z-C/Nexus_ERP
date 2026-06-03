namespace Nexus.Domain.Entityes.EnumSupportEntities;

public class EconomicSectorEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private EconomicSectorEntity() { }

    public static IEnumerable<EconomicSectorEntity> GetAll() => new[]
    {
        new EconomicSectorEntity { Id = 1, Name = "Primary" },
        new EconomicSectorEntity { Id = 2, Name = "Secondary" },
        new EconomicSectorEntity { Id = 3, Name = "Tertiary" },
        new EconomicSectorEntity { Id = 4, Name = "Cuaternary" }
    };
}