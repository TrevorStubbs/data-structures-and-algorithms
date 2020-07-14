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
            Current = Head; //
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
            Current = Head;
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

        /// <summary>
        /// Appends a new node to the end of the linked list
        /// O(n)
        /// </summary>
        /// <param name="value"></param>
        public void Append(int value)
        {
            Current = Head;
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                while (Current.Next != null)
                {
                    Current = Current.Next;
                }
                Current.Next = newNode;
            }
        }

        public void InsertBefore(int value, int newValue)
        {
            Node methodCurrent = Head;
            if (Head == null)
            {
                Node newNode = new Node(newValue);
                Head = newNode;
                return;
            }

            if (Current.Value == value)
            {
                Insert(newValue);
                return;
            }

            while (methodCurrent.Next != null)
            {
                if (methodCurrent.Next.Value == value)
                {
                    Node newNode = new Node(newValue);
                    Node tempNode = methodCurrent.Next;
                    newNode.Next = tempNode;
                    methodCurrent.Next = newNode;
                    methodCurrent = tempNode;
                    return;
                }
                methodCurrent = methodCurrent.Next;
                if (methodCurrent.Next == null)
                {
                    throw new Exception("That value does not exist.");
                }
            }
        }

        public void InsertAfter(int value, int newValue)
        {
            Node methodCurrent = Head;
            if (Head == null)
            {
                Node newNode = new Node(newValue);
                Head = newNode;
                return;
            }

            while (methodCurrent != null)
            {
                if (methodCurrent.Value == value)
                {
                    if (methodCurrent.Next == null)
                    {
                        Node newNode = new Node(newValue);
                        methodCurrent.Next = newNode;
                        return;
                    }
                    else
                    {
                        Node newNode = new Node(newValue);
                        Node tempNode = methodCurrent.Next;///                        
                        methodCurrent.Next = newNode;
                        newNode.Next = tempNode;
                        return;
                    }
                }
                methodCurrent = methodCurrent.Next;
            }
            if (methodCurrent.Next == null)
            {
                throw new Exception("That value does not exist.");
            }
        }
    }
}
