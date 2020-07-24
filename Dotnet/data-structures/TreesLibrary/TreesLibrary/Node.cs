using System;
using System.Collections.Generic;
using System.Text;

namespace TreesLibrary
{
    public class Node<T>
    {
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
