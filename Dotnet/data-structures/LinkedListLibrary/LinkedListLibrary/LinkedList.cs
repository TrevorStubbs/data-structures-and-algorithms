using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLibrary
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public Node Current { get; set; }

        /// <summary>
        /// LinkedList Constructor
        /// Assigns head to null
        /// Assigns current to head
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Current = Head;
        }

        /// <summary>
        /// Insert a new node at the beginning of the list. O(1).
        /// </summary>
        /// <param name="value">Takes in a value to build the new node with.</param>
        public void Insert(int value)
        {
            Current = Head;
            Node node = new Node(value);
            node.Next = Head;
            Head = node;
        }

        /// <summary>
        /// Finds a specific value in the linked list
        /// O(n) time efficiency
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Includes(int value)
        {
            Current = Head;
            while (Current != null)
            {
                if (Current.Value == value)
                    return true;
                Current = Current.Next;
            }
            return false;
        }

        /// <summary>
        /// Overriding current behavior of ToString method to output all values in the linked list a string
        /// </summary>
        /// <returns>a string containing all the values of the linked list</returns>
        public override string ToString()
        {
            Current = Head;
            // StringBuilder class

            StringBuilder sb = new StringBuilder();

            //start sb construction
            while (Current != null)
            {
                sb.Append($"{Current.Value} -> ");
                Current = Current.Next;
            }

            sb.Append("Null");

            return sb.ToString();
        }
    }
}
