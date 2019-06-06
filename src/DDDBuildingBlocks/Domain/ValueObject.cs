using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MarcellToth.DDDBuildingBlocks.Domain.Abstractions;

namespace MarcellToth.DDDBuildingBlocks.Domain
{
    /// <summary>
    ///     Abstract base class for a Value Objects. Implements equality.
    /// </summary>
    public abstract class ValueObject : IValueObject
    {

        /// <summary>
        ///     Returns values of all distinct the properties that this <see cref="IValueObject"/> has.
        ///     This will be the basis of equality comparision. The number and order of properties needs to be stable.
        /// </summary>
        /// <remarks>
        ///     The default implementation enumerates all public properties defined by the inheriting type.
        ///     This implementation should suffice in 99% of the cases.
        ///     In case you have you utilize the equality comparision a lot, performance can be improved by overriding this method.
        /// </remarks>
        protected virtual IEnumerable<object> GetPropertyValues()
        {
            return GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(p => p.GetValue(this));
        }


        /// <inheritdoc />
        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return GetPropertyValues().SequenceEqual(((ValueObject) other).GetPropertyValues());
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 31;
            bool changeMultiplier = false;
            foreach (object value in GetPropertyValues())
            {
                if (value != null)
                {

                    hashCode = hashCode * (changeMultiplier ? 59 : 114) + value.GetHashCode();

                    changeMultiplier = !changeMultiplier;
                }
                else
                    hashCode = hashCode ^ 13;//only for support {"a",null,null,"a"} <> {null,"a","a",null}
            }

            return hashCode;
        }
    }
}