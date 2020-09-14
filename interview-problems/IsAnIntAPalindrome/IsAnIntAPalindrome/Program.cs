using System;
using System.Collections.Generic;

namespace IsAnIntAPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsAnIntAPalindrome(-121));
        }

        public static bool IsAnIntAPalindrome(int inputInt)
        {
            Stack<char> stack = new Stack<char>();

            string str = inputInt.ToString();

            foreach (var item in str)
            {
                stack.Push(item);
            }

            foreach (var item in str)
            {
                if (stack.TryPeek(out _))
                {
                    if(stack.Pop() != item)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
