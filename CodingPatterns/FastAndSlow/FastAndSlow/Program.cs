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

            Console.WriteLine();

            var cyclicLength = CyclicLinkedList.FindCyclicLLLength(cyclicList.Head);

            Console.WriteLine($"Cycle Length: {cyclicLength}");
        }

        public static class CyclicLinkedList
        {
            // Time: O(n)
            // Space: O(1)
            public static bool IsCyclic(LinkedList inputLL)
            {
                // Set the 2 pointers to the head.
                var slow = inputLL.Head;
                var fast = inputLL.Head;

                // Since Fast will be running before slow we only need check to see if fast is null (or fast.Next)
                while (fast != null && fast.Next != null)
                {
                    // Travers the LL
                    // Slow will be slow.Next
                    // Fast will always be fast.Next.Next
                    slow = slow.Next;
                    fast = fast.Next.Next;

                    // If fast and slow are pointing to the same node then the LL is cyclical.
                    if (slow == fast)
                        return true;
                }

                return false;
            }

            public static int FindCyclicLLLength(Node head)
            {
                int result = 1;
                Node fast = head;
                Node slow = head;
                Node cycleStart = null;

                while (fast != null && fast.Next != null)
                {
                    fast = fast.Next.Next;
                    slow = slow.Next;

                    if (fast == slow)
                    {
                        cycleStart = slow;
                        break;
                    }
                }

                slow = slow.Next;

                while(cycleStart != slow)
                {
                    result++;
                    slow = slow.Next;
                }

                //if(fast != null || fast.Next != null)
                //    throw new Exception("This Linked List is not Cyclical.");

                return result;
            }
        }
    }
}
