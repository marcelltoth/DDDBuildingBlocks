using System.Collections.Generic;

namespace MarcellToth.DDDBuildingBlocks.Domain
{
    /// <summary>
    ///     Helper type for implementing a single-valued value object.
    /// </summary>
    /// <typeparam name="TInternalValue">The type of the single value. Mostly a primitive.</typeparam>
    public abstract class SingleValuedValueObject<TInternalValue> : ValueObject
    {
        /// <summary>
        ///     The internal single value.
        /// </summary>
        protected virtual TInternalValue InternalValue { get; }

        /// <summary>
        ///     Creates a new instance of <see cref="SingleValuedValueObject{TInternalValue}"/> with the given internal value.
        /// </summary>
        protected SingleValuedValueObject(TInternalValue internalValue)
        {
            InternalValue = internalValue;
        }

        /// <summary>
        ///     Implicitly converts the <see cref="SingleValuedValueObject{TInternalValue}"/> to the type of the internal value.
        /// </summary>
        public static implicit operator TInternalValue(SingleValuedValueObject<TInternalValue> svvo)
        {
            return svvo.InternalValue;
        }

        /// <inheritdoc />
        /// <remarks>
        ///     Calls <code>ToString()</code> on <see cref="InternalValue"/>.
        /// </remarks>
        public override string ToString()
        {
            return InternalValue.ToString();
        }

        /// <inheritdoc />
        protected sealed override IEnumerable<object> GetPropertyValues()
        {
            yield return InternalValue;
        }
    }
}