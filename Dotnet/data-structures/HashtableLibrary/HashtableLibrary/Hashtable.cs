using System;
using System.Collections.Generic;
using System.Data;

namespace HashtableLibrary
{
    public class Hashtable<T> where T : struct
    {
        public LinkedList<LinkedListNode<Node<T?>>>[] Map { get; set; }

        public Hashtable(int size)
        {
            Map = new LinkedList<LinkedListNode<Node<T?>>>[size];
        }

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
                }
            }
            return false;
        }
    }
}
