using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueuesLibrary
{
    public class Node
    {
        public string Value { get; set; }
        public Node Next { get; set; }

        /// <summary>
        /// Class constructor. Cannot build a Node without a value.
        /// </summary>
        /// <param name="value"></param>
        public Node(string value)
        {
            Value = value;
        }
    }
}
