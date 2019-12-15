using System.Threading.Tasks;
using MarcellToth.DDDBuildingBlocks.Domain.Abstractions;

namespace MarcellToth.DDDBuildingBlocks.Persistence.Abstractions
{
    /// <summary>
    ///     A Repository that can perform CRUD operations over the Aggregate <typeparamref name="TEntity"/>.
    ///     Works on a <see cref="IUnitOfWork"/> that is usually provided via constructor injection.
    /// </summary>
    /// <typeparam name="TEntity">The Aggregate Root over this repository operates.</typeparam>
    /// <typeparam name="TEntityId">The type of the ID of <typeparamref name="TEntity"/>.</typeparam>
    /// <remarks>
    ///     If you need a more specialized repository, derive your own repository interface from <see cref="IRepository{TEntity}"/>.
    /// </remarks>
    public interface ICrudRepository<TEntity, TEntityId> : IRepository<TEntity> 
        where TEntity : IAggregateRoot, IEntity<TEntityId>
    {
        /// <summary>
        ///     Fetches a <typeparamref name="TEntity"/> aggregate by it's ID. The entity is not updated unless a call is made to <see cref="UpdateAsync"/>;
        /// </summary>
        /// <param name="entityId">The ID of the entity to load.</param>
        /// <returns>The root of the aggregate.</returns>
        Task<TEntity> GetByIdAsync(TEntityId entityId);

        /// <summary>
        ///     Adds a new <typeparamref name="TEntity"/> aggregate to the <see cref="IRepository{TEntity}.UnitOfWork"/> in its current form. Further changes are not tracked.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> instance to add.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        ///     Updates <see cref="IRepository{TEntity}.UnitOfWork"/> to store the current state of <paramref name="entity"/>.
        /// </summary>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        ///     Deletes a <typeparamref name="TEntity"/> aggregate and its dependents from the storage.
        /// </summary>
        /// <param name="entityId">The ID of the entity to remove.</param>
        Task DeleteAsync(TEntityId entityId);
    }
}