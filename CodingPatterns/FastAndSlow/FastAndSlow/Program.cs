using System;
using LinkedListLibrary;


namespace FastAndSlow
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList cyclicList = new LinkedList();
            cyclicList.Insert(6);
            cyclicList.Insert(5);
            cyclicList.Insert(4);
            cyclicList.Insert(3);
            cyclicList.Insert(2);
            cyclicList.Insert(1);
            cyclicList.MakeCyclic();            

            var isCyclic = CyclicLinkedList.IsCyclic(cyclicList);

            Console.WriteLine($"Is the List Cyclic: {isCyclic}");
        }

        public static class CyclicLinkedList
        {
            public static bool IsCyclic(LinkedList inputLL)
            {
                var slow = inputLL.Head;
                var fast = inputLL.Head;

                while(fast != null && fast.Next != null)
                {

                    slow = slow.Next;
                    fast = fast.Next.Next;

                    if (slow == fast)
                        return true;
                }

                return false;
            }
        }
    }
}
