using MarcellToth.DDDBuildingBlocks.Domain.Abstractions;

namespace MarcellToth.DDDBuildingBlocks.Persistence.Abstractions
{
    /// <summary>
    ///     A basic almost-marker interface for Repositories.
    ///     For basic CRUD repositories use <see cref="ICrudRepository{TEntity,TEntityId}"/> instead (which is a derivative).
    ///     If you need a more sophisticated approach, derive your repository interface from this.
    /// </summary>
    /// <typeparam name="TEntity">Marker type parameter. Used to signal the type of the <see cref="IAggregateRoot"/> this repository operates over.</typeparam>
    /// <seealso cref="ICrudRepository{TEntity,TEntityId}"/>.
    // ReSharper disable once UnusedTypeParameter
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        /// <summary>
        ///     The <see cref="IUnitOfWork"/> over which this repository works.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}