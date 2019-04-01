using System.Collections.Generic;
using MarcellToth.DDDBuildingBlocks.Domain.Abstractions;

namespace MarcellToth.DDDBuildingBlocks.Domain
{
    public class Entity<TId> : IEntity<TId>
    {
        public Entity(TId id)
        {
            Id = id;
        }

        /// <summary>
        ///     The unique identity of this Entity.
        /// </summary>
        /// <remarks>
        ///     There is a special "Transient" state, if <code>Id == default</code>. This might be the case when using
        ///     EF generated key sbefore saving the entity to the database.
        /// </remarks>
        /// <seealso cref="IsTransient"/>
        public TId Id { get; protected set; }

        /// <summary>
        ///     True if the entity does not have a stable identity yet.
        /// </summary>
        public virtual bool IsTransient => Equals(Id, default(TId));
        
        /// <summary>
        ///     Returns true if <paramref name="other"/> is the same entity based on its <see cref="Id"/>.
        ///     If at least one of the operands are Transient, they are considered different (except in case of reference equality).
        /// </summary>
        /// <param name="other">The entity to compare with.</param>
        public bool Equals(IEntity<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }

        /// <inheritdoc />
        /// <seealso cref="Equals(MarcellToth.DDDBuildingBlocks.Domain.Abstractions.IEntity{TId})"/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((IEntity<TId>) obj);
        }

        /// <inheritdoc />
        /// <remarks>
        ///     This implementation generates hash codes based on <see cref="Id"/>, and falls back to the base implementation
        ///     if the object is Transient. This means hash codes are not stable if the ID changes.
        ///     For this reason avoid operations that use <see cref="GetHashCode"/> while the object is still Transient.
        /// </remarks>
        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }
    }
}