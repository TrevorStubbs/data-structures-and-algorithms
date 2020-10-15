using System;
using System.Collections.Generic;
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

            //ReverseLinkedList(linkedList);

            var list = ReverseLinkedListRecusrive(linkedList);


            Console.WriteLine(linkedList.ToString());
            //Console.WriteLine(list.ToString());
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
            Node prev = null;
            Node current = list.Head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            list.Head = prev;
        }

        public static LinkedList ReverseLinkedListRecusrive(LinkedList list)
        {
            
            list.Append(ReverseLinkedListRecusrive(list.Head));

            return list;
        }

        public static Node ReverseLinkedListRecusrive(LinkedList list, Node head)
        {
            if (head != null)
            {
                Node temp = list.Head;
                head = ReverseLinkedListRecusrive(list, head);
            }

            return list;
        }

        //public static Node ReverseLinkedListRecusrive(Node head)
        //{
        //    if (head == null)
        //    {
        //        return head;
        //    }

        //    if (head.Next == null)
        //    {
        //        return head;
        //    }

        //    Node newHead = ReverseLinkedListRecusrive(head.Next);

        //    head.Next.Next = head;
        //    head.Next = null;

        //    return newHead;
        //}

    }

}
