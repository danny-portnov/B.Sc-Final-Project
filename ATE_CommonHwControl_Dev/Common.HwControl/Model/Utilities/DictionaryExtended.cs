using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HwControl.Model.Utilities
{
    public static class DictionaryExtended //public so also UI would be able to use
    {
        /// <summary>
        /// Filters a sequence of values based on a predicate. 
        /// </summary>
        /// <typeparam name="TValue">The type of the elements of source.</typeparam>
        /// <param name="dictionaryToFilter">An <see cref="Dictionary{string, TValue}"/> to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An <see cref="Dictionary{string, TValue}"/> that contains elements from the input
        ///     sequence that satisfy the condition.</returns>
        public static Dictionary<string, TValue> Where<TValue>(this Dictionary<string, TValue> dictionaryToFilter,
                                                               Func<TValue, bool> predicate)
            => Filter(dictionaryToFilter, item => predicate(item.Value));
        public static Dictionary<string, TValue> Where<TValue>(this Dictionary<string, TValue> dictionaryToFilter,
                                                               Func<string, bool> predicate)
            => Filter(dictionaryToFilter, item => predicate(item.Key));
        /// <summary>
        /// Filters a sequence of keys based on a predicate. 
        /// </summary>
        /// <typeparam name="TValue">The type of the elements of source.</typeparam>
        /// <param name="dictionaryToFilter">An <see cref="Dictionary{string, TValue}"/> to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>An <see cref="Dictionary{string, TValue}"/> that contains elements from the input
        ///     sequence that satisfy the condition.</returns>
        public static void Filter<TValue>(this Dictionary<string, TValue> dictionaryToFilter, Func<string, bool> predicate)
        {
            foreach (KeyValuePair<string, TValue> item in dictionaryToFilter.Where(predicate).ToList())
            {
                dictionaryToFilter.Remove(item.Key);
            }
        }

        private static Dictionary<string, TValue> Filter<TValue>(Dictionary<string, TValue> dictionaryToFilter,
                                                                 Func<KeyValuePair<string, TValue>, bool> predicate)
            => dictionaryToFilter.Where(predicate).ToDictionary(signal => signal.Key, signal => signal.Value);
    }
}