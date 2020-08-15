using System;
using System.Collections.Generic;
using System.Text;

namespace HashtableLibrary
{
    public class Node<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }

        /// <summary>
        /// Constructor needs a Key and a Value to be defined
        /// </summary>
        /// <param name="key">A key in the form of a string</param>
        /// <param name="value">A value of T type</param>
        public Node(string key, T value)
        {
            Value = value;
            Key = key;
        }
    }
}
