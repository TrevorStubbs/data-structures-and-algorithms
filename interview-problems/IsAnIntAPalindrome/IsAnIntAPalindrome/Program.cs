using System;
using System.Collections.Generic;

namespace IsAnIntAPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsAnIntAPalindrome(121));

            Console.WriteLine();

            Console.WriteLine(IsAnIntAPalindromeV2(1221));
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

        public static bool IsAnIntAPalindromeV2(int inputInt)
        {
            var intStr = inputInt.ToString();
            char[] strChar = intStr.ToCharArray();
            Array.Reverse(strChar);
            var newString = new string(strChar);

            if (intStr == newString)
                return true;

            return false;
        }
    }
}
