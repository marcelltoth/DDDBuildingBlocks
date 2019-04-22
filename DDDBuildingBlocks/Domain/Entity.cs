using System;
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

        public Entity()
        {
        }

        /// <summary>
        ///     The unique identity of this Entity.
        /// </summary>
        /// <remarks>
        ///     There is a special "Transient" state, if <code>Id == default</code>. This might be the case when using
        ///     EF generated key sbefore saving the entity to the database.
        /// </remarks>
        /// <seealso cref="IsTransient"/>
        public TId Id { get; private set; }

        /// <summary>
        ///     True if the entity does not have a stable identity yet.
        /// </summary>
        public virtual bool IsTransient => Equals(Id, default(TId));

        /// <summary>
        ///     Sets the unique identity of this Entity, if it was in the Transient state.
        /// </summary>
        /// <remarks>
        ///     Calling this method on an entity that is not transient causes an <see cref="System.InvalidOperationException"/> to be thrown.
        /// </remarks>
        /// <param name="newId">The ID to be set on this entity.</param>
        /// <exception cref="System.ArgumentException">Thrown if the value of <paramref name="newId"/> represents the transient state.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when attempting to change the identity of a non-transient entity.</exception>
        public void SetId(TId newId)
        {
            if(Equals(newId, default(TId)))
                throw new ArgumentException("Cannot set an entity's identity to the transient state.", nameof(newId));
            
            if(!IsTransient)
                throw new InvalidOperationException("Cannot change indentity of a non-transient entity");

            Id = newId;
        }
        
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
            var other = (Entity<TId>) obj;
            return !IsTransient && !other.IsTransient && Equals(other);
            
        }

        /// <inheritdoc />
        /// <remarks>
        ///     This implementation generates hash codes based on <see cref="Id"/>, and falls back to the base implementation
        ///     if the object is Transient. This means hash codes are not stable if the ID changes.
        ///     For this reason avoid operations that use <see cref="GetHashCode"/> while the object is still Transient.
        /// </remarks>
        public override int GetHashCode()
        {
            if (IsTransient) 
                return base.GetHashCode();
            
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