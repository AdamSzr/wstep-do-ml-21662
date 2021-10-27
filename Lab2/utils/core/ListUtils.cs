namespace CSharp_Utils
{
    using System.Collections.Generic;
    public static class List
    {
        public static List<T> Empty<T>() => new List<T>();

        public static List<T> Of<T>(params T[] items)
        {
            var x = new List<T>();
            foreach (T element in items)
            {
                x.Add(element);
            }
            return x;
        }

        public static void Display<T>(this T[] items)
        {
            foreach (T element in items)
            {
               System.Console.Write( element.ToString() + " ");
            }
            System.Console.WriteLine();
        }
    }
}