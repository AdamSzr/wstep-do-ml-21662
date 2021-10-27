namespace CSharp_Utils
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Dictionary
    {
        public static Dictionary<K, V> Empty<K, V>() => new Dictionary<K, V>();

        public static Dictionary<K, V> Of<K, V>(params KeyValuePair<K, V>[] items)
        {
            var x = new Dictionary<K, V>();
            foreach (KeyValuePair<K, V> element in items)
            {
                x.Add(element.Key, element.Value);
            }
            return x;
        }

        public static Dictionary<K, V> Of<K, V>(IEnumerable<K> keys, IEnumerable<V> values)
        {
            var k_count = keys.Count();
            var v_count = values.Count();
            if (k_count != v_count)
                throw new System.Exception("Directory can not be created from 2 diffrend source length");

            var x = new Dictionary<K, V>();
            var k = keys.ToArray();
            var v = values.ToArray();
            for (int i = 0; i < k_count; i++)
            {
                x.Add(k[i], v[i]);
            }
            return x;
        }
        public static void Display<K, V>(this Dictionary<K, V> items)
        {
            foreach (KeyValuePair<K, V> item in items)
            {
                System.Console.WriteLine($"<{item.Key.ToString()}, {item.Value.ToString()}>");
            }
        }
    }
}