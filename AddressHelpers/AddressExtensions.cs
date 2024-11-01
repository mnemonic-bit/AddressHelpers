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
        public static unsafe long GetAddress(object obj)
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
        public static unsafe long GetAddress<T>(ref T value)
            where T : struct
        {
            fixed (T* ptr = &value)
            {
                return (long)ptr;
            }
        }

    }
}
