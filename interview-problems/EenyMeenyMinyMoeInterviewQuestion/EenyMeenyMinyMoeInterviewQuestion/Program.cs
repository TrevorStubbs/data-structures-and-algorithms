using System;
using System.Collections.Generic;

namespace EenyMeenyMinyMoeInterviewQuestion
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> inputStrings = new List<string>() { "A", "B", "C", "D", "E" };
            Console.WriteLine(Meany(inputStrings, 3));

        }

        public static string Meany(List<string> strings, int k)
        {
            Stack<string> stack = new Stack<string>();
            int counter = 1;
            while (strings.Count != 0)
            {
                for (int i = 0; i < strings.Count; i++)
                {
                    if (counter % k == 0)
                    {
                        stack.Push(strings[i]);
                        strings.RemoveAt(i);
                        i--;
                    }
                    counter++;
                }
            }
            return stack.Pop();
        }
    }
}
