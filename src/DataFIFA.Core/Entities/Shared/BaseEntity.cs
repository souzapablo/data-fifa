namespace DataFIFA.Core.Entities.Shared
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime LastUpdate { get; private protected set; } = DateTime.Now;
        public bool IsActive { get; private set; } = true;

        public void ToggleActiveStatus() => IsActive = !IsActive;
        public void Update() => LastUpdate = DateTime.Now;
    }
}