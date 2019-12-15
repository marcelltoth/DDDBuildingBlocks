using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarcellToth.DDDBuildingBlocks.Persistence.Abstractions
{
    /// <summary>
    ///     Interface for a Unit of Work pattern. A unit of work tracks changes to entities it has loaded, and persists them all at once in a single transaction.
    /// </summary>
    /// <seealso cref="SaveChangesAsync"/>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Persists all changes tracked by this <see cref="IUnitOfWork"/> as a single transaction. Either all changes need to be persisted or none.
        /// </summary>
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}