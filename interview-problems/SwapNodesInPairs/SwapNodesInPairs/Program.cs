using SwapNodesInPairs.Classes;
using System;

namespace SwapNodesInPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var linkedList = new MyLinkedList();

            for (int i = 6; i > 0; i--)
            {
                linkedList.AddToEnd(i);
            }

            linkedList.SwapNodesInParis(linkedList.Head);

            Console.WriteLine(linkedList.PrintLinkedList());
        }
    }
}
