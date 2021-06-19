using System;
using System.Collections.Generic;
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
            cyclicList.MakeCyclic(3);

            var isCyclic = CyclicLinkedList.IsCyclic(cyclicList);

            Console.WriteLine($"Is the List Cyclic: {isCyclic}");

            Console.WriteLine();

            var cyclicLength = CyclicLinkedList.FindCyclicLLLength(cyclicList.Head);

            Console.WriteLine($"Cycle Length: {cyclicLength}");

            var educativeCycleLength = CyclicLinkedList.FindCycleLength(cyclicList.Head);

            Console.WriteLine($"Educative Cycle Length: {educativeCycleLength}");

            Console.WriteLine();

            var start = CyclicLinkedList.FindCycleStart(cyclicList.Head);

            Console.WriteLine($"Start of the list: {start.Value}");

            Console.WriteLine();

            var educativeStart = LinkedListStart.FindCycleStart(cyclicList.Head);

            Console.WriteLine($"Starting Node (Educative): {educativeStart.Value}");

            Console.WriteLine();

            var happyNumber = HappyNumber.IsHappyNumber(23);

            Console.WriteLine($"Is number happy? {happyNumber}");

            Console.WriteLine();

            var fastSlowHappyNumber = HappyNumber.IsHappyNumberFastSlow(23);

            Console.WriteLine($"Is number happy (Fast/Slow)? {fastSlowHappyNumber}");

            Console.WriteLine();
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

                while (cycleStart != slow)
                {
                    result++;
                    slow = slow.Next;
                }

                return result;
            }

            public static int FindCycleLength(Node head)
            {
                Node slow = head;
                Node fast = head;

                while (fast != null && fast.Next != null)
                {
                    fast = fast.Next.Next;
                    slow = slow.Next;

                    if (slow == fast)
                        return CalcCycleLength(slow);
                }

                return 0;
            }

            private static int CalcCycleLength(Node slow)
            {
                Node current = slow;
                int cycleLength = 0;

                do
                {
                    current = current.Next;
                    cycleLength++;
                }
                while (current != slow);

                return cycleLength;
            }

            public static Node FindCycleStart(Node head)
            {
                Node fast = head;
                Node slow = head;

                while (fast != null && fast.Next != null)
                {
                    fast = fast.Next.Next;
                    slow = slow.Next;

                    if (fast == slow)
                    {
                        return FindStart(slow);
                    }
                }

                return head;
            }

            private static Node FindStart(Node slow)
            {
                Node current = slow;
                int start = int.MaxValue;
                Node startNode = null;

                do
                {
                    current = current.Next;

                    if (current.Value < start)
                    {
                        start = current.Value;
                        startNode = current;
                    }
                }
                while (current != slow);

                return startNode;
            }
        }

        public static class LinkedListStart
        {
            public static Node FindCycleStart(Node head)
            {
                int cycleLength = 0;
                Node slow = head;
                Node fast = head;
                while (fast != null && fast.Next != null)
                {
                    fast = fast.Next.Next;
                    slow = slow.Next;

                    if (slow == fast)
                    {
                        cycleLength = CalcCycleLength(slow);
                        break;
                    }
                }

                return FindStart(head, cycleLength);
            }

            private static int CalcCycleLength(Node slow)
            {
                Node current = slow;
                int cycleLength = 0;
                do
                {
                    current = current.Next;
                    cycleLength++;
                }
                while (current != slow);

                return cycleLength;
            }

            private static Node FindStart(Node head, int cycleLength)
            {
                Node pointer1 = head, pointer2 = head;
                while (cycleLength > 0)
                {
                    pointer2 = pointer2.Next;
                    cycleLength--;
                }

                while (pointer1 != pointer2)
                {
                    pointer1 = pointer1.Next;
                    pointer2 = pointer2.Next;
                }

                return pointer1;
            }
        }

        public static class HappyNumber
        {
            // This does not use Fast/Slow. I use a HastSet to keep track if there are any repeats. 
            // Time O(n)
            // Space O(1)
            public static bool IsHappyNumber(int inputNumber)
            {
                int result = inputNumber;
                HashSet<int> set = new HashSet<int>();

                // If result ever becomes 1 then we know that we have found a happy number
                while (result != 1)
                {
                    int sum = 0;
                    // This algo makes the number into a string and then loop through each digit in the string and then parse them back to a digit so we can square them.
                    string strNumber = result.ToString();

                    foreach (var ch in strNumber)
                    {
                        string chStr = ch.ToString();
                        int chInt = Int32.Parse(chStr);
                        sum += (chInt * chInt);
                    }

                    // If the HashSet has a the number then we have entered a loop
                    if (set.Contains(sum))
                        return false;
                    else
                    {
                        set.Add(sum);
                        result = sum;
                    }
                }

                // If we have broken out of the loop then we know that we have found a happy number
                return true;
            }

            // This one uses the fast/slow pattern
            // Time: O(logN)
            // Space: O(1)
            public static bool IsHappyNumberFastSlow(int inputNumber)
            {
                // Define the fast/slow pointers
                int fast = inputNumber;
                int slow = inputNumber;

                // If fast or slow becomes 1 then break out of the loop (we have found a happy number)
                while (fast != 1 && slow != 1)
                {
                    // Iterate the pointers
                    slow = GetSumNoParse(slow);
                    fast = GetSumNoParse(GetSumNoParse(fast));

                    // If fast == slow then we have found a loop
                    if (fast == slow)
                        return false;
                }

                return true;
            }

            // Even if we keep squaring a 1 it will always result in a 1
            // Therefore if fast becomes 1 it will stay there every iteration.
            public static bool IsHappyNumberEducative(int inputNumber)
            {
                int slow = inputNumber, fast = inputNumber;

                do
                {
                    slow = GetSumNoParse(slow);
                    fast = GetSumNoParse(GetSumNoParse(fast));
                }
                while (slow != fast);

                return slow == 1;
            }

            // Helper method with the parse pattern
            private static int GetSum(int inputNumber)
            {
                int sum = 0;
                string inputString = inputNumber.ToString();

                foreach (var ch in inputString)
                {
                    string chStr = ch.ToString();
                    int chInt = Int32.Parse(chStr);
                    sum += (chInt * chInt);
                }

                return sum;
            }

            // This pattern squares each digit without having to convert the number to a string and back.
            private static int GetSumNoParse(int inputNumer)
            {
                int sum = 0, digit;
                while (inputNumer > 0)
                {
                    digit = inputNumer % 10;
                    sum += digit * digit;
                    inputNumer /= 10;
                }

                return sum;
            }
        }
    }
}
