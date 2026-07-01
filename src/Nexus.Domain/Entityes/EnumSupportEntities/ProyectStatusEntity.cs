namespace Nexus.Domain.Entityes.EnumSupportEntities;

public class ProyectStatusEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private ProyectStatusEntity() { }

    public static IEnumerable<ProyectStatusEntity> GetAll() => new[]
    {
        new ProyectStatusEntity { Id = 1, Name = "Planning" },
        new ProyectStatusEntity { Id = 2, Name = "Developing" },
        new ProyectStatusEntity { Id = 3, Name = "StandBy" },
        new ProyectStatusEntity { Id = 4, Name = "Cancelled" },
        new ProyectStatusEntity { Id = 5, Name = "Finished" }
    };
}