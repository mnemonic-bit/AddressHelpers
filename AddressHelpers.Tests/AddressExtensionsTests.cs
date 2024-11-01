using FluentAssertions;

namespace AddressHelpers.Tests
{
    public class AddressExtensionsTests
    {

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenReferenceTypeIsUsed()
        {
            var someClass = new SomeClass();
            var longAddress2 = AddressExtensions.GetAddr(someClass);
            var longAddress3 = GetAddressOfParameter2(someClass);
            var longAddress4 = GetAddressOfRefParameter2(ref someClass);

            longAddress2.Should().Be(longAddress3);
            longAddress3.Should().Be(longAddress4);
        }

        [Fact]
        public void GetAddress_ShouldReturnSameAddress_WhenValueTypeIsUsed()
        {
            var someStruct = new SomeStruct();
            var longAddress1 = AddressExtensions.GetAddr(ref someStruct);
            var longAddress3 = GetAddressOfParameter3(ref someStruct);
            var longAddress4 = GetAddressOfRefParameter3(ref someStruct);

            longAddress1.Should().Be(longAddress3);
            longAddress3.Should().Be(longAddress4);
        }


        private long GetAddressOfParameter2<T>(T obj)
        {
            return AddressExtensions.GetAddr(obj);
        }

        private long GetAddressOfRefParameter2<T>(ref T obj)
        {
            return AddressExtensions.GetAddr(obj);
        }

        private long GetAddressOfParameter3<T>(ref T obj)
            where T : struct
        {
            return AddressExtensions.GetAddr(ref obj);
        }

        private long GetAddressOfRefParameter3<T>(ref T obj)
            where T : struct
        {
            return AddressExtensions.GetAddr(ref obj);
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

        }

    }
}