// Domain/Entities/Catalog/Support/PersonalStatusEntity.cs
namespace Nexus.Domain.Entities.Catalog.Support;

public class PersonalStatusEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private PersonalStatusEntity() { }

    public static IEnumerable<PersonalStatusEntity> GetAll() => new[]
    {
        new PersonalStatusEntity { Id = 1, Name = "Fired" },
        new PersonalStatusEntity { Id = 2, Name = "Active" },
        new PersonalStatusEntity { Id = 3, Name = "Inactive" }
    };
}