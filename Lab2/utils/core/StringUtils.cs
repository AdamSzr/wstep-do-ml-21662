namespace CSharp_Utils
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using System;

    using System.Reflection;
    public static class StringUtils
    {
        public static byte[] ConvertToByteArray(this string value)
        {
            return System.Text.ASCIIEncoding.ASCII.GetBytes(value);
        }

        public static string RandomString(int length)
        {
            CharUtils cu = new();
            StringBuilder sb = new();
            for (int i = 0; i < length; i++)
            {
                sb.Append(cu.RandomUpperChar());
            }

            return sb.ToString();
        }
    }
}