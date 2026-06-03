namespace Nexus.Domain.Entityes.EnumSupportEntities;

public class ContractTypeEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private ContractTypeEntity() { }

    public static IEnumerable<ContractTypeEntity> GetAll() => new[]
    {
        new ContractTypeEntity { Id = 1, Name = "Término Indefinido" },
        new ContractTypeEntity { Id = 2, Name = "Fijo" },
        new ContractTypeEntity { Id = 3, Name = "Obra Labor" },
        new ContractTypeEntity { Id = 4, Name = "Aprendizaje" },
        new ContractTypeEntity { Id = 5, Name = "Prestación de Servicios" }
    };
}