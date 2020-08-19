namespace Rehborn.AspNetAutoFacExample.Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
    }
}
