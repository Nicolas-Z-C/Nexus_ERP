// Domain/Entities/Catalog/Support/PriorityEntity.cs
namespace Nexus.Domain.Entities.Catalog.Support;

public class Priority
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private Priority() { }

    public static IEnumerable<Priority> GetAll() => new[]
    {
        new Priority { Id = 1, Name = "High" },
        new Priority { Id = 2, Name = "Medium" },
        new Priority { Id = 3, Name = "Low" }
    };
}

