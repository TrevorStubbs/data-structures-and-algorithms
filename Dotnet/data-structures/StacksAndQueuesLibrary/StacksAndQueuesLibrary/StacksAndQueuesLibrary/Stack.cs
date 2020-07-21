using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueuesLibrary
{
    public class Stack<T>
    {
        public Node<T> Top { get; set; }

        /// <summary>
        /// Puts a new node on top of the stack
        /// </summary>
        /// <param name="value">Takes a Value to build the node</param>
        public void Push(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = Top;
            Top = newNode;
        }

        /// <summary>
        /// Call IsEmpty. If it's false return the value of Top else throw an error.
        /// </summary>
        /// <returns>Returns the value of top or throws and error</returns>
        public T Peek()
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
        public Node<T> Pop()
        {

            if (!IsEmpty())
            {
                Node<T> temp = Top;
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
