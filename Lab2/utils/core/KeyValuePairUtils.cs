
namespace CSharp_Utils
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    public static class KeyValuePair
    {
        public static KeyValuePair<K, V> Create<K, V>(K key, V value)
        {
            return new KeyValuePair<K, V>(key, value);
        }
    }
}
