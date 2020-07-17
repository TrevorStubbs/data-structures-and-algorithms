using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueuesLibrary
{
    public class Stack
    {
        public Node Top { get; set; }

        /// <summary>
        /// Puts a new node on top of the stack
        /// </summary>
        /// <param name="value">Takes a string to build the node</param>
        public void Push(string value)
        {
            Node newNode = new Node(value);
            newNode.Next = Top;
            Top = newNode;
        }

        /// <summary>
        /// Look at the top node of the stack. If it's not null return true. If null throw an error.
        /// </summary>
        /// <returns>Returns true or throws and error</returns>
        public bool Peek()
        {
            if (Top == null)
            {
                throw new Exception("The stack is empty.");
            }
            else
                return true;
        }

        /// <summary>
        /// First peek at the top of stack. If the stack is not empty then remove the top item and return it to the caller.
        /// </summary>
        /// <returns>Returns a Node or throws and error</returns>
        public Node Pop()
        {

            if (Peek())
            {
                Node temp = Top;
                Top = Top.Next;
                return temp;
            }
            else
            {
                throw new Exception("The stack is empty.");
            }
        }
    }
}
