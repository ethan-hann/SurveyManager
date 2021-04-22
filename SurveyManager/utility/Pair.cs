using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    /// <summary>
    /// Generic class to represent a single Key, Value pair.
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public class Pair<K, V>
    {
        /// <summary>
        /// The key of the pair.
        /// </summary>
        public K Key { get; set; }
        /// <summary>
        /// The value of the pair.
        /// </summary>
        public V Value { get; set; }

        /// <summary>
        /// Construct a new pair with the specified key and value.
        /// </summary>
        /// <param name="key">The key for this pair.</param>
        /// <param name="value">The value for this pair.</param>
        public Pair(K key, V value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Construct an empty pair with no key or value.
        /// </summary>
        public Pair() { }
    }
}
