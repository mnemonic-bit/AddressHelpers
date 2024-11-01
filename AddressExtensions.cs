using System.Runtime.CompilerServices;

namespace UnsafeCode
{
    public static class AddressExtensions
    {

        public static unsafe string GetAddress<T>(T obj)
        {
            if (typeof(T).IsValueType && obj != null)
            {
                return GetValueTypeAddress((dynamic)obj);
            }
            else
            {
                return GetReferenceTypeAddress((dynamic)obj);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe string GetValueTypeAddress<T>(T obj) where T : struct
        {
            TypedReference tr = __makeref(obj);
            IntPtr ptr = *(IntPtr*)(&tr);
            return $"0x{ptr.ToInt64():X16}";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetReferenceTypeAddress<T>(T obj) where T : class
        {
            return obj == null ? "null" : $"0x{GetObjectAddressInternal(obj):X16}";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe long GetObjectAddressInternal<T>(T obj)
            where T : class
        {
            return (long)Unsafe.AsPointer(ref obj);
        }

    }
}
