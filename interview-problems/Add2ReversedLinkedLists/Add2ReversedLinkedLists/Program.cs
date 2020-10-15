using System;
using System.Collections.Generic;
using System.Linq;

namespace Add2ReversedLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode()
            {
                Next = null,
                Val = 9
            };

            ListNode l2 = new ListNode()
            {
                Next = null,
                Val = 9
            };

            Add(9, l2);
            Add(9, l2);
            Add(9, l2);
            Add(9, l2);
            Add(9, l2);
            Add(9, l2);
            Add(9, l2);
            Add(9, l2);
            Add(9, l2);
            Add(1, l2);

            ListNode final = AddTwoNumbers(l1, l2);

            Console.WriteLine(final);
        }

        public static void Add(int value, ListNode head)
        {
            ListNode newNode = new ListNode();
            newNode.Val = value;
            newNode.Next = head;
            head = newNode;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int resultInt = AddTwoNumbersHelper(l1) + AddTwoNumbersHelper(l2);
           
            char[] resultChar = resultInt.ToString().ToCharArray();

            ListNode outputHead = new ListNode();

            for (int i = 0; i < resultChar.Length; i++)
            {
                ListNode newNode = new ListNode();
                newNode.Val = Int32.Parse(resultChar[i].ToString());
                newNode.Next = outputHead;
                outputHead = newNode;
            }

            return outputHead;
        }

        public static int AddTwoNumbersHelper(ListNode head)
        {

            Stack<int> stack = new Stack<int>();
            ListNode current = head;

            while (current != null)
            {
                stack.Push(current.Val);
                current = current.Next;
            }

            string str = "";

            while (stack.TryPop(out int result))
            {
                str += result.ToString();
            }

            Int32.TryParse(str, out int resultInt);
            return resultInt;
        }
    }
}
