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
        public static string CreateCSVHeader(object o, char separator = ',')
        {
            StringBuilder sb = new StringBuilder();
            Type t = typeof(Car); // Where obj is object whose properties you need.
            PropertyInfo[] pi = t.GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                sb.Append(pi[i].Name);
                if (i != pi.Length - 1)
                    sb.Append(separator);
            }
            sb.AppendLine();
            return sb.ToString();
        }
        public static string CreateCSVRow(object o, char separator = ',')
        {
            StringBuilder sb = new StringBuilder();
            Type t = typeof(Car); // Where obj is object whose properties you need.
            PropertyInfo[] pi = t.GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                sb.Append(pi[i].GetValue(o));
                if (i != pi.Length - 1)
                    sb.Append(separator);
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}