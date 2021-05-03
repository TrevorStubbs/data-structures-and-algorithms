using System;
using System.Collections.Generic;
using System.Text;

namespace SwapNodesInPairs.Classes
{
    class MyLinkedList
    {
        public Node Head { get; set; }

        public int AddToBeginning(int value)
        {
            var newNode = new Node(value);

            newNode.Next = Head;
            Head = newNode;

            return newNode.Value;
        }

        public int AddToEnd(int value)
        {
            var newNode = new Node(value);

            if (Head == null)
                Head = newNode;
            else
            {
                var current = Head;

                while (current != null)
                {
                    if (current.Next == null)
                    {
                        current.Next = newNode;
                        break;
                    }

                    current = current.Next;
                }
            }

            return newNode.Value;
        }

        public Node SwapNodesInParis(Node head)
        {
            var current = head;
            Node old = null;
            Node previous = null;            
            bool bit = false;

            while (current != null)
            {
                if (bit)
                {
                    var next = current.Next;
                    var temp = current;
                    temp.Next = previous;

                    if (old != null)
                        old.Next = temp;

                    previous.Next = current.Next;
                    current = previous;
                    current.Next = next;
                    previous = temp;

                    if (current == head)
                    {
                        head = previous;
                    }
                }

                old = previous;
                previous = current;
                current = current.Next;
                bit = !bit;
            }

            Head = head;
            return head;
        }

        public string PrintLinkedList()
        {
            var current = Head;
            var stringBuilder = new StringBuilder();

            while (current != null)
            {
                stringBuilder.Append($"{current.Value} ");

                current = current.Next;
            }

            string outputString = stringBuilder.ToString();

            return outputString;
        }
    }
}
