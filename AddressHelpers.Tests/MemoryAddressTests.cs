using FluentAssertions;

namespace MemoryAddressHelpers.Tests
{
    public class MemoryAddressTests
    {

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenReferenceTypeIsUsed1()
        {
            var someClass = new SomeClass();
            var longAddress1 = MemoryAddress.Get(someClass);
            var longAddress2 = GetAddressOfParameter2(someClass);

            longAddress1.Should().Be(longAddress2);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenReferenceTypeIsUsed2()
        {
            var someClass = new SomeClass();
            var longAddress1 = MemoryAddress.Get(someClass);
            var longAddress2 = GetAddressOfRefParameter2(ref someClass);

            longAddress1.Should().Be(longAddress2);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenReferenceTypeIsUsed3()
        {
            var someClass = new SomeClass();
            var longAddress1 = someClass.GetMemoryAddress();
            var longAddress2 = GetAddressOfRefParameter2(ref someClass);

            longAddress1.Should().Be(longAddress2);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenValueTypeIsUsed1()
        {
            var someStruct = new SomeStruct();
            var longAddress1 = MemoryAddress.Get(ref someStruct);
            var longAddress2 = GetAddressOfParameter3(ref someStruct);
            var longAddress3 = GetAddressOfRefParameter3(ref someStruct);

            longAddress1.Should().Be(longAddress2);
            longAddress2.Should().Be(longAddress3);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenValueTypeIsUsed2()
        {
            var someValue = 42;
            var longAddress1 = MemoryAddress.Get(ref someValue);
            var longAddress2 = GetAddressOfParameter3(ref someValue);
            var longAddress3 = GetAddressOfRefParameter3(ref someValue);

            longAddress1.Should().Be(longAddress2);
            longAddress2.Should().Be(longAddress3);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenValueTypeIsUsed3()
        {
            SomeStruct someStruct = new SomeStruct();
            long address1 = MemoryAddress.Get(ref someStruct);
            long address2 = someStruct.GetAddress();

            address1.Should().Be(address2);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenValueTypeIsUsed4()
        {
            SomeStruct someStruct = new SomeStruct();
            long address1 = someStruct.GetMemoryAddress();
            long address2 = someStruct.GetAddress();

            address1.Should().Be(address2);
        }


        private long GetAddressOfParameter2<T>(T obj)
        {
            return MemoryAddress.Get(obj);
        }

        private long GetAddressOfRefParameter2<T>(ref T obj)
        {
            return MemoryAddress.Get(obj);
        }

        private long GetAddressOfParameter3<T>(ref T obj)
            where T : struct
        {
            return MemoryAddress.Get(ref obj);
        }

        private long GetAddressOfRefParameter3<T>(ref T obj)
            where T : struct
        {
            return MemoryAddress.Get(ref obj);
        }


        private class SomeClass
        {

            public SomeClass() { }

            public bool SomeMethod() => true;

        }

        private struct SomeStruct
        {

            public SomeStruct() { }

            public bool SomeMethod() => true;

            public long GetAddress()
            {
                return MemoryAddress.Get(ref this);
            }

        }

    }
}