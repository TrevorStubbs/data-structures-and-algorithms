using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueuesLibrary
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        /// <summary>
        /// Class constructor. Cannot build a Node without a value.
        /// </summary>
        /// <param name="value">Takes in the value for the node</param>
        public Node(T value)
        {
            Value = value;
        }
    }
}
