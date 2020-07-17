using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueuesLibrary
{
    public class Stack
    {
        private Node Top { get; set; }

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
        /// Call IsEmpty. If it's false return the value of Top else throw an error.
        /// </summary>
        /// <returns>Returns the value of top or throws and error</returns>
        public string Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("The stack is empty.");
            }
            else
                return Top.Value;
        }

        /// <summary>
        /// Look at the top node of the stack. Return true if it's empty else return false.
        /// </summary>
        /// <returns>True or false</returns>
        public bool IsEmpty()
        {
            if (Top == null)            
                return true;            
            else
                return false;
        }

        /// <summary>
        /// First peek at the top of stack. If the stack is not empty then remove the top item and return it to the caller.
        /// </summary>
        /// <returns>Returns a Node or throws and error</returns>
        public Node Pop()
        {

            if (!IsEmpty())
            {
                Node temp = Top;
                Top = Top.Next;
                temp.Next = null;
                return temp;
            }
            else
            {
                throw new Exception("The stack is empty.");
            }
        }
    }
}
