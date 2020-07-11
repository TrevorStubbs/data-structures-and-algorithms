using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLibrary
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        /// <summary>
        /// Node Class Constructor
        /// </summary>
        /// <param name="value">Takes an integer to assign the value to</param>
        public Node(int value)
        {
            Value = value;
        }
    }
}
