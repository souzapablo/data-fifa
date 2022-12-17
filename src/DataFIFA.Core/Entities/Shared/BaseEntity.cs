namespace DataFIFA.Core.Entities.Shared
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdate { get; private set; }
        public bool IsActive { get; private set; }

        public void ToggleActiveStatus() => IsActive = !IsActive; 
    }
}