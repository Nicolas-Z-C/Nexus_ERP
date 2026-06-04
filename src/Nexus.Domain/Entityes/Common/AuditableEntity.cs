namespace Nexus.Domain.Entityes.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt {get; init;} = DateTime.UtcNow;
        public DateTime UpdatedAt {get; private set;} = DateTime.UtcNow;

        internal AuditableEntity() {}
    
        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}