using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Fessad_TL
{
    public static class SecureStringHelper
    {
        public static string Unsecure(this SecureString secureString)
        {
            // If there are no value return empty string
            if (secureString == null)
                return String.Empty;

            // Start with free pointer
            var unmanagedString = IntPtr.Zero;

            try
            {
                // Unencrypt the pointer and return it as string
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // To avoid any problem free the pointer in the end
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }


        }
    }
}
