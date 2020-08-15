using System;
using System.Collections.Generic;
using System.Data;

namespace HashtableLibrary
{
    public class Hashtable<T> where T : struct
    {
        public LinkedList<LinkedListNode<Node<T?>>>[] Map { get; set; }

        /// <summary>
        /// Initializes the hash table with LinkedList of LinkListNodes.
        /// </summary>
        /// <param name="size">Define your hashtable size</param>
        public Hashtable(int size)
        {
            Map = new LinkedList<LinkedListNode<Node<T?>>>[size];
        }

        /// <summary>
        /// Calculates a hash from a string.
        /// </summary>
        /// <param name="key">A string to be hashed</param>
        /// <returns>A hash in the form of an integer</returns>
        private int GetHash(string key)
        {
            int total = 0;

            for (int i = 0; i < key.Length; i++)
            {
                total += key[i];
            }

            int primeValue = total * 1009;
            int index = primeValue % Map.Length;

            return index;
        }

        /// <summary>
        /// Builds a new Node then wraps it into a LinkedListNode and places it into the hashtable at the hashed index.
        /// </summary>
        /// <param name="key">The Key of the Node</param>
        /// <param name="value">The Value of the Node</param>
        public void Add(string key, T value)
        {
            int index = GetHash(key);
            Node<T?> htNode = new Node<T?>(key, value);
            LinkedListNode<Node<T?>> node = new LinkedListNode<Node<T?>>(htNode);

            if(Map[index] is null)
            {
                Map[index] = new LinkedList<LinkedListNode<Node<T?>>>();
            }

            Map[index].AddLast(node);
        }

        /// <summary>
        /// Retrieves the Value of the Node if it exsists.
        /// </summary>
        /// <param name="key">Needs a string for the Key</param>
        /// <returns>Returns the Value of the Node.</returns>
        public T? Get(string key)
        {
            int index = GetHash(key);

            if(!(Map[index] is null))
            {
                if (Map[index].Count == 1)
                {
                    var first = Map[index].First;
                    return first.Value.Value.Value;
                }
                else
                {
                    var current = Map[index].First;

                    while(current != null)
                    {
                        if (current.Value.Value.Key == key)
                        {
                            return current.Value.Value.Value;
                        }
                        current = current.Next;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Searches the Hashtable to see if the key is in the table.
        /// </summary>
        /// <param name="key">Needs a string for the Key</param>
        /// <returns>True if the key exisits.</returns>
        public bool Contains(string key)
        {
            int index = GetHash(key);

            var location = Map[index];

            if(!(location is null))
            {
                var current = Map[index].First;

                while(current != null)
                {
                    if (current.Value.Value.Key == key)
                    {
                        return true;
                    }

                    if(current.Next == null)
                    {
                        return false;
                    }

                    current = current.Next;
                }
            }
            return false;
        }
    }
}
