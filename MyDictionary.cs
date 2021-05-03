using System;
using System.Collections.Generic;

namespace Multi_Value_Dictionary
{
    /// <summary>
    /// Represents a collection of keys and values.
    /// Multiple values can have the same key.
    /// </summary>
    /// <typeparam name="TKey">Type of the keys.</typeparam>
    /// <typeparam name="TValue">Type of the values.</typeparam>
    public class MyDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {

        public MyDictionary()
            : base()
        {
        }

        /// <summary>
        /// Adds an element with the specified key and value into the MyDictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        public void Add(TKey key, TValue value)
        {
            if (TryGetValue(key, out List<TValue> valueList))
            {
                if (valueList.Contains(value))
                {
                    Console.WriteLine(") ERROR, value already exists");
                }
                else
                {
                    valueList.Add(value);
                    Console.WriteLine(") Added");
                }
            }
            else
            {
                valueList = new List<TValue>();
                valueList.Add(value);
                Add(key, valueList);
                Console.WriteLine(") Added");
            }
        }

        /// <summary>
        /// Removes first occurence of an element with a specified key and value.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <param name="value">The value of the element to remove.</param>      
        public void Remove(TKey key, TValue value)
        {
            if (TryGetValue(key, out List<TValue> valueList))
            {
                if (valueList.Remove(value))
                {
                    if (valueList.Count == 0)
                    {
                        Remove(key);
                    }
                    Console.WriteLine(") Removed");
                }
                else
                {
                    Console.WriteLine(") ERROR, value does not exist");
                }
            }
            else
            {
                Console.WriteLine(") ERROR, key does not exist");
            }
        }

        /// <summary>
        /// Removes all occurences of elements with a specified key and value.
        /// </summary>
        /// <param name="key">The key of the elements to remove.</param>
        /// <param name="value">The value of the elements to remove.</param>      
        public void RemoveAll(TKey key)
        {
            if (TryGetValue(key, out List<TValue> valueList))
            {
                while (valueList.Count != 0)
                {
                    valueList.Remove(valueList[0]);
                }
                if (valueList.Count == 0)
                {
                    Remove(key);
                    Console.WriteLine(") Removed");
                }
            }
            else
            {
                Console.WriteLine(") ERROR, key does not exist");
            }
        }

        /// <summary>
        /// Determines whether the MyDictionary contains an element with a specific
        /// key / value pair.
        /// </summary>
        /// <param name="key">Key of the element to search for.</param>
        /// <param name="value">Value of the element to search for.</param>
        /// <returns>true if the element was found; otherwise false.</returns>
        public bool Contains(TKey key, TValue value)
        {
            if (TryGetValue(key, out List<TValue> valueList))
            {
                return valueList.Contains(value);
            }
            return false;
        }
    }
}