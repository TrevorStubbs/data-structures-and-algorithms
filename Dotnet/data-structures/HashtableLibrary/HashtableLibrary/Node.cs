using System;
using System.Collections.Generic;
using System.Text;

namespace HashtableLibrary
{
    public class Node<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }

        public Node(string key, T value)
        {
            Value = value;
            Key = key;
        }
    }
}
