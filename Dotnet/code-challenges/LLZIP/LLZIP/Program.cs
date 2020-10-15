using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using LinkedListLibrary;

namespace LLZIP
{
    public class Program
    {
        /// <summary>
        /// Insertion into the main method
        /// </summary>
        /// <param name="args">takes in array of args.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// ZipLists method takes 2 linked lists from the DLL I created.
        /// It checks to see if the lists are not empty. Then starts stitching them together until
        /// 1 of them runs out of nodes to stitch and then returns the head of the list with all the nodes added to it. 
        /// </summary>
        /// <param name="list1">Takes a linkedlist object</param>
        /// <param name="list2">Takes another linkedlist object</param>
        /// <returns>returns the head of the completed list.</returns>
        public static Node ZipLists(LinkedList list1, LinkedList list2)
        {
            if (list1.Head == null || list2.Head == null)
            {
                throw new Exception("You cannot zip an empty list.");
            }

            Node current1 = list1.Head;
            Node current2 = list2.Head;

            Node temp1 = null;
            Node temp2 = null;

            while (current1 != null && current2 != null)
            {
                temp1 = current1.Next;
                current1.Next = current2;

                if (temp1 == null)
                {
                    break;
                }

                temp2 = current2.Next;
                current2.Next = temp1;

                current1 = temp1;
                current2 = temp2;
            }

            return list1.Head;
        }
    }
}
