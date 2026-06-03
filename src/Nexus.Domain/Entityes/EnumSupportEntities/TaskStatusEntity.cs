namespace Nexus.Domain.Entityes.EnumSupportEntities;

public class TaskStatusEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private TaskStatusEntity() { }

    public static IEnumerable<TaskStatusEntity> GetAll() => new[]
    {
        new TaskStatusEntity { Id = 1, Name = "OnGoing" },
        new TaskStatusEntity { Id = 2, Name = "Delayed" },
        new TaskStatusEntity { Id = 3, Name = "Cancelled" },
        new TaskStatusEntity { Id = 4, Name = "Reprogramed" },
        new TaskStatusEntity { Id = 5, Name = "Finished" }
    };
}