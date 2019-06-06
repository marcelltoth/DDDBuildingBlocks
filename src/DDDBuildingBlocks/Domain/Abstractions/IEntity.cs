using System;

namespace MarcellToth.DDDBuildingBlocks.Domain.Abstractions
{
    /// <summary>
    ///     An entity as defined by Domain Driven Design.
    /// </summary>
    /// <typeparam name="TId">The type used for the <see cref="Id"/>of the Entity</typeparam>
    public interface IEntity<TId> : IEquatable<IEntity<TId>>
    {
        /// <summary>
        /// The identifier of the entity. Used for equality.
        /// Two entities of the same type with the same value
        /// for Id should be considered equal.
        /// </summary>
        TId Id { get; }
    }
}