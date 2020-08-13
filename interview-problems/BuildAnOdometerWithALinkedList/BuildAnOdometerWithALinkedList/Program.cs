using System;
using System.Diagnostics.Tracing;
using LinkedListLibrary;

namespace BuildAnOdometerWithALinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LinkedList linkedList = new LinkedList();
            linkedList.Insert(0);

            for (int i = 0; i < 1000; i++)
            {
                Increment(linkedList.Head, linkedList);
            }

            ReverseLinkedList(linkedList);


            Console.WriteLine(linkedList.ToString());
        }

        static void Increment(Node head, LinkedList linkedList)
        {
            if (head.Value == 9)
            {
                if (head.Next != null)
                {
                    Increment(head.Next, linkedList);
                    head.Value = 0;
                }
                else
                {
                    linkedList.Append(1);
                    head.Value = 0;
                }
                return;
            }

            head.Value++;
        }

        public static void ReverseLinkedList(LinkedList list)
        {
            Node prev = null, current = list.Head, next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            list.Head = prev;
        }

    }

}
