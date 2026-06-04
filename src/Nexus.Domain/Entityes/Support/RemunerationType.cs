namespace Nexus.Domain.Entityes.Support;

public class RemunerationType
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private RemunerationType() { }

    public static IEnumerable<RemunerationType> GetAll() => new[]
    {
        new RemunerationType { Id = 1, Name = "Fixed income" },
        new RemunerationType { Id = 2, Name = "Variable income" },
        new RemunerationType { Id = 3, Name = "In Kind" },
        new RemunerationType { Id = 4, Name = "Emotional remuneration" }
    };
}