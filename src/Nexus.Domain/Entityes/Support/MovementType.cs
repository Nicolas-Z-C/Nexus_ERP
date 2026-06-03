// Domain/Entities/Catalog/Support/MovementTypeEntity.cs
namespace Nexus.Domain.Entities.Catalog.Support;

public class MovementType
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private MovementType() { }

    public static IEnumerable<MovementType> GetAll() => new[]
    {
        new MovementType { Id = 1, Name = "Buy" },
        new MovementType { Id = 2, Name = "Sale" },
        new MovementType { Id = 3, Name = "Return" },
        new MovementType { Id = 4, Name = "Adjustement" },
        new MovementType { Id = 5, Name = "Tranfer" },
        new MovementType { Id = 6, Name = "Proyect Consumed" }
    };
}