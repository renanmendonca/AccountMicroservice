namespace Account.Domain.Entities
{
    public abstract class Entity<TEntity, TId> : BaseEntity
        where TEntity : Entity<TEntity, TId>
    {
        public virtual TId Id { get; set; }
    }
}