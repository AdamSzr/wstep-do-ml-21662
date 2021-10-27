namespace CSharp_Utils
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    public static class ByteArray
    {
        public static string ConvertToString(this byte[] value)
        {
            return System.Text.ASCIIEncoding.ASCII.GetString(value);
        }
    }
}