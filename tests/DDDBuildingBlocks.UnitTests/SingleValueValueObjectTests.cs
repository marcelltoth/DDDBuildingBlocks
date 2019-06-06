using System;
using MarcellToth.DDDBuildingBlocks.Domain;
using Xunit;

namespace DDDBuildingBlocks.UnitTests
{
    public class SingleValueValueObjectTests
    {
        private class StringValuedValueObject : SingleValuedValueObject<string>
        {
            public StringValuedValueObject(string internalValue) : base(internalValue)
            {
            }
        }
        
        private class IntValuedValueObject : SingleValuedValueObject<int>
        {
            public IntValuedValueObject(int internalValue) : base(internalValue)
            {
            }
        }

        #region Equality Checks
        
        [Fact]
        public void String_ObjectEquals_EqualValues_Equal()
        {
            const string value = "Some string";
            StringValuedValueObject no1 = new StringValuedValueObject(value);
            StringValuedValueObject no2 = new StringValuedValueObject(value);
            Assert.Equal(no1, no2);
        }
        
        
        [Fact]
        public void String_ObjectEquals_DifferentValues_NonEqual()
        {
            const string value = "Some string";
            const string value2 = "Some string 2";
            StringValuedValueObject no1 = new StringValuedValueObject(value);
            StringValuedValueObject no2 = new StringValuedValueObject(value2);
            Assert.NotEqual(no1, no2);
        }
        
        
        [Fact]
        public void Int_ObjectEquals_EqualValues_Equal()
        {
            const int value = 1;
            IntValuedValueObject no1 = new IntValuedValueObject(value);
            IntValuedValueObject no2 = new IntValuedValueObject(value);
            Assert.Equal(no1, no2);
        }
        
        
        [Fact]
        public void Int_ObjectEquals_DifferentValues_NonEqual()
        {
            const int value = 1;
            const int value2 = 2;
            IntValuedValueObject no1 = new IntValuedValueObject(value);
            IntValuedValueObject no2 = new IntValuedValueObject(value2);
            Assert.NotEqual(no1, no2);
        }
        
        #endregion

        
        #region ToString Checks

        [Fact]
        public void Int_ToString_Valid()
        {
            IntValuedValueObject ivvo = new IntValuedValueObject(123);
            Assert.Equal("123", ivvo.ToString());
        }
        
        [Fact]
        public void String_ToString_Valid()
        {
            const string someString = "Some String";
            StringValuedValueObject svvo = new StringValuedValueObject(someString);
            Assert.Equal(someString, svvo.ToString());
        }

        #endregion

        
        #region Implicit Cast Checks

        
        [Fact]
        public void Int_ImplicitCast_Valid()
        {
            IntValuedValueObject ivvo = new IntValuedValueObject(123);
            Assert.True(123 == ivvo);
        }
        
        [Fact]
        public void String_ImplicitCast_Valid()
        {
            const string someString = "Some String";
            StringValuedValueObject svvo = new StringValuedValueObject(someString);
            Assert.True(someString == svvo);
        }

        #endregion

    }
}