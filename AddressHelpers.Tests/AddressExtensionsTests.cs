using FluentAssertions;

namespace AddressHelpers.Tests
{
    public class AddressExtensionsTests
    {

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenReferenceTypeIsUsed()
        {
            var someClass = new SomeClass();
            var longAddress1 = AddressExtensions.GetAddress(someClass);
            var longAddress2 = GetAddressOfParameter2(someClass);
            var longAddress3 = GetAddressOfRefParameter2(ref someClass);

            longAddress1.Should().Be(longAddress2);
            longAddress2.Should().Be(longAddress3);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenValueTypeIsUsed1()
        {
            var someStruct = new SomeStruct();
            var longAddress1 = AddressExtensions.GetAddress(ref someStruct);
            var longAddress2 = GetAddressOfParameter3(ref someStruct);
            var longAddress3 = GetAddressOfRefParameter3(ref someStruct);

            longAddress1.Should().Be(longAddress2);
            longAddress2.Should().Be(longAddress3);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenValueTypeIsUsed2()
        {
            var someValue = 42;
            var longAddress1 = AddressExtensions.GetAddress(ref someValue);
            var longAddress2 = GetAddressOfParameter3(ref someValue);
            var longAddress3 = GetAddressOfRefParameter3(ref someValue);

            longAddress1.Should().Be(longAddress2);
            longAddress2.Should().Be(longAddress3);
        }

        [Fact]
        public void Test()
        {
            SomeStruct someStruct = new SomeStruct();
            long address1 = AddressExtensions.GetAddress(ref someStruct);
            long address2 = someStruct.GetAddress();

            address1.Should().Be(address2);
        }


        private long GetAddressOfParameter2<T>(T obj)
        {
            return AddressExtensions.GetAddress(obj);
        }

        private long GetAddressOfRefParameter2<T>(ref T obj)
        {
            return AddressExtensions.GetAddress(obj);
        }

        private long GetAddressOfParameter3<T>(ref T obj)
            where T : struct
        {
            return AddressExtensions.GetAddress(ref obj);
        }

        private long GetAddressOfRefParameter3<T>(ref T obj)
            where T : struct
        {
            return AddressExtensions.GetAddress(ref obj);
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
                return AddressExtensions.GetAddress(ref this);
            }

        }

    }
}