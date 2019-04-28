using MarcellToth.DDDBuildingBlocks.Domain;
using Xunit;

namespace DDDBuildingBlocks.UnitTests
{
    /// <summary>
    ///     Class to test the logic in the <see cref="ValueObject"/> base class, mostly equality.
    /// </summary>
    public class ValueObjectTests
    {
        /// <summary>
        ///     A test value object that has two properties, an int and a string.
        /// </summary>
        private class TestValueObject : ValueObject
        {
            public int Prop1 { get; }

            public string Prop2 { get; }

            public TestValueObject(int prop1, string prop2)
            {
                Prop1 = prop1;
                Prop2 = prop2;
            }
        }

        private class DerivedTestValueObject : TestValueObject
        {
            public DerivedTestValueObject(int prop1, string prop2) : base(prop1, prop2)
            {
            }
        }

        #region Object.Equals Tests

        /// <summary>
        ///     Test that the <see cref="object.Equals(object)"/> override returns false when the argument is null.
        /// </summary>
        [Fact]
        public void ObjectEquals_OtherIsNull_NotEqual()
        {
            TestValueObject obj1 = new TestValueObject(1, "hello");
            Assert.False(obj1.Equals(null));
        }

        /// <summary>
        ///     Test that the <see cref="object.Equals(object)"/> override returns true when the argument is the same object.
        /// </summary>
        [Fact]
        public void ObjectEquals_OtherIsSame_Equal()
        {
            TestValueObject obj1 = new TestValueObject(1, "hello");
            // ReSharper disable once EqualExpressionComparison
            Assert.True(obj1.Equals(obj1));
        }

        /// <summary>
        ///     Test that the <see cref="object.Equals(object)"/> override returns true when the argument is an equivalent (although not reference-equal) object.
        /// </summary>
        [Fact]
        public void ObjectEquals_OtherIsEqual_Equal()
        {
            TestValueObject obj1 = new TestValueObject(1, "hello");
            TestValueObject obj2 = new TestValueObject(1, "hello");
            Assert.True(obj1.Equals(obj2));
        }

        /// <summary>
        ///     Test that the <see cref="object.Equals(object)"/> override returns false when the argument is a different object.
        /// </summary>
        [Fact]
        public void ObjectEquals_OtherIsDifferent_NotEqual()
        {
            TestValueObject obj1 = new TestValueObject(1, "hello");
            TestValueObject obj2 = new TestValueObject(2, "hello");
            TestValueObject obj3 = new TestValueObject(1, "hello2");
            Assert.False(obj1.Equals(obj2));
            Assert.False(obj1.Equals(obj3));
        }

        /// <summary>
        ///     Test that the <see cref="object.Equals(object)"/> override returns false when compared with a derived type (even if their fields are the same).
        /// </summary>
        [Fact]
        public void ObjectEquals_OtherIsDerivedButEqual_NotEqual()
        {
            TestValueObject obj1 = new TestValueObject(1, "hello");
            TestValueObject obj2 = new DerivedTestValueObject(1, "hello");
            Assert.False(obj1.Equals(obj2));
            Assert.False(obj2.Equals(obj1));
        }

        #endregion

        #region GetHashCodeTests

        /// <summary>
        ///     Test that the <see cref="object.GetHashCode"/> override returns the same values for equal objects.
        /// </summary>
        [Fact]
        public void GetHashCode_SameObjects_Equal()
        {
            TestValueObject obj1 = new TestValueObject(1, "hello");
            TestValueObject obj2 = new TestValueObject(1, "hello");
            Assert.Equal(obj1.GetHashCode(), obj2.GetHashCode());
        }

        #endregion

    }
}