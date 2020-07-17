using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueuesLibrary
{
    public class Stack
    {
        public Node Top { get; set; }

        public void Push(string value)
        {
            Node newNode = new Node(value);
            newNode.Next = Top;
            Top = newNode;
        }

        public bool Peek()
        {
            if (Top == null)
            {
                throw new Exception("The stack is empty.");
            }
            else
                return true;
        }
    }
}
