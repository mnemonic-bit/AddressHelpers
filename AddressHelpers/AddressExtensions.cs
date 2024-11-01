using System.Runtime.InteropServices;

namespace AddressHelpers
{
    public static class AddressExtensions
    {

        /// <summary>
        /// Returns the address of the given instance as a long integer.
        /// </summary>
        /// <param name="obj">The instance we want an address for.</param>
        /// <returns>Returns a long integer value representing the memory address of the instance.</returns>
        public static unsafe long GetAddr(object obj)
        {
            GCHandle handle = GCHandle.Alloc(obj, GCHandleType.Pinned);

            try
            {
                IntPtr address = handle.AddrOfPinnedObject();
                return address.ToInt64();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        /// Returns the memory address of the given value type.
        /// </summary>
        /// <typeparam name="T">The type of the value type.</typeparam>
        /// <param name="value">The value, passed by-ref.</param>
        /// <returns>Returns a long integer value representing the memory address of the value.</returns>
        public static unsafe long GetAddr<T>(ref T value)
            where T : struct
        {
            fixed (T* ptr = &value)
            {
                return (long)ptr;
            }
        }


        ////////////////////////////////////////////////////////


        //public unsafe static long GetAddr3(object obj)
        //{
        //    // GetRawData() is not known, but we found it used in the
        //    // source code of GCHandle.AddrOfPinnedObject()
        //    return (IntPtr)Unsafe.AsPointer(ref obj.GetRawData());
        //}


        ////////////////////////////////////////////////////////


        //public static unsafe string GetAddress<T>(T obj)
        //{
        //    if (typeof(T).IsValueType && obj != null)
        //    {
        //        return GetValueTypeAddress((dynamic)obj);
        //    }
        //    else
        //    {
        //        return GetReferenceTypeAddress((dynamic)obj);
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static unsafe string GetValueTypeAddress<T>(T obj) where T : struct
        //{
        //    TypedReference tr = __makeref(obj);
        //    IntPtr ptr = *(IntPtr*)(&tr);
        //    return $"0x{ptr.ToInt64():X16}";
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static string GetReferenceTypeAddress<T>(T obj) where T : class
        //{
        //    return obj == null ? "null" : $"0x{GetObjectAddressInternal(obj):X16}";
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static unsafe long GetObjectAddressInternal<T>(T obj)
        //    where T : class
        //{
        //    return (long)Unsafe.AsPointer(ref obj);
        //}

    }
}
