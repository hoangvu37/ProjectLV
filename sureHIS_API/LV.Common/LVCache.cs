using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web;

namespace LV.Common
{
    public static class CacheHelper
    {
        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="o">Item to be cached</param>
        /// <param name="key">Name of item</param>
        public static void Add<T>(T o, string key)
        {
            // NOTE: Apply expiration parameters as you see fit.
            // I typically pull from configuration file.

            // In this example, I want an absolute
            // timeout so changes will always be reflected
            // at that time. Hence, the NoSlidingExpiration.
            HttpContext.Current.Cache.Insert(
                key,
                o,
                null,
                DateTime.Now.AddMinutes(1440),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// Check for item in cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return HttpContext.Current.Cache[key] != null;
        }

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <param name="value">Cached value. Default(T) if 
        /// item doesn't exist.</param>
        /// <returns>Cached item as type</returns>
        public static bool Get<T>(string key, out T value)
        {
            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }

                value = (T)HttpContext.Current.Cache[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }
    }

    [Serializable]
    public class LVCache<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, List<TValue>> dict = new Dictionary<TKey, List<TValue>>();

        public LVCache() { }

        public void Add(TKey key, TValue value)
        {
            List<TValue> list;

            if (Dict.TryGetValue(key, out list))
            {
                list.Add(value);

            }
            else
            {
                list = new List<TValue>();
                list.Add(value);
                Dict.Add(key, list);
            }
        }

        public void Update(TKey key, List<TValue> value)
        {
            if (Dict.ContainsKey(key))
                Dict[key] = value;
            else if (value != null)
            {
                foreach (TValue vl in value)
                {
                    Add(key, vl);
                }
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return Dict.Keys;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return Dict.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            return Dict.Remove(key);
        }

        /// <summary>
        /// Get cache value
        /// (IsList == false ? TValue : List[TValue])
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isList"></param>
        /// <returns></returns>
        public dynamic this[TKey key, [Optional]bool isList]
        {
            get
            {
                if (Dict.ContainsKey(key))
                {
                    List<TValue> value = Dict[key];
                    if (isList == false && value != null && value.Count > 0)
                        return value[0];
                    else
                        return value;
                }
                else
                    return null;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();

                Dictionary<TKey, List<TValue>>.Enumerator enumerator = Dict.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    values.AddRange(enumerator.Current.Value);
                }

                return values;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotSupportedException("TryGetValue is not supported.");
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                throw new NotSupportedException(
                      "accessing elements by key is not supported");
            }
            set
            {
                throw new NotSupportedException(
                      "accessing elements by key is not supported");
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Dict.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            List<TValue> list;
            if (!Dict.TryGetValue(item.Key, out list))
            {
                return false;
            }
            else
            {
                return list.Contains(item.Value);
            }
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {

            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException("array index out of range");
            if (array.Length - arrayIndex < this.Count)
                throw new ArgumentException("Array too small");

            Dictionary<TKey, List<TValue>>.Enumerator enumerator = Dict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<TKey, List<TValue>> mapPair = enumerator.Current;
                foreach (TValue val in mapPair.Value)
                {
                    array[arrayIndex++] = new KeyValuePair<TKey, TValue>(mapPair.Key, val);
                }
            }
        }

        public int Count
        {
            get
            {
                int count = 0;

                Dictionary<TKey, List<TValue>>.Enumerator enumerator = Dict.GetEnumerator();
                while (enumerator.MoveNext())
                {

                    KeyValuePair<TKey, List<TValue>> pair = enumerator.Current;
                    count += pair.Value.Count;
                }
                return count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public Dictionary<TKey, List<TValue>> Dict
        {
            get
            {
                return dict;
            }

            set
            {
                dict = value;
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            List<TValue> list;
            if (Dict.TryGetValue(item.Key, out list))
            {
                return list.Remove(item.Value);
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            Dictionary<TKey, List<TValue>>.Enumerator enumerateKeys = Dict.GetEnumerator();
            while (enumerateKeys.MoveNext())
            {
                foreach (TValue val in enumerateKeys.Current.Value)
                {
                    KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(
                       enumerateKeys.Current.Key, val);
                    yield return pair;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
