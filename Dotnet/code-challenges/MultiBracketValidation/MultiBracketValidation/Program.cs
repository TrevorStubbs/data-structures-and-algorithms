using System;
using StacksAndQueuesLibrary;

namespace MultiBracketValidation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(MultiBracketValidation("{}"));
            Console.WriteLine(MultiBracketValidation("{}(){}"));
            Console.WriteLine(MultiBracketValidation("{}()[[Extra Characters]]"));
            Console.WriteLine(MultiBracketValidation("(){}[[]]"));
            Console.WriteLine(MultiBracketValidation("{}{Code}[Fellows](())"));
            Console.WriteLine(MultiBracketValidation("[({}]"));
            Console.WriteLine(MultiBracketValidation("(]("));
            Console.WriteLine(MultiBracketValidation("{(})"));

        }

        public static bool MultiBracketValidation(string input)
        {
            Stack<char> stack = new Stack<char>();
            Queue<char> que = new Queue<char>();

            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                    stack.Push(item);
                else if (item == '}' || item == ']' || item == ')')
                    que.Enqueue(item);
            }

            while(!stack.IsEmpty() && !que.IsEmpty())
            {
                char leftChar = stack.Pop().Value;
                char rightChar = que.Dequeue().Value;

                if (leftChar == '{')
                    if (rightChar != '}')
                        return false;
                else if (leftChar == '[')
                    if (rightChar != ']')
                        return false;
                else if (leftChar == '(')
                    if (rightChar != ')')
                        return false;
            }

            if (!stack.IsEmpty() || !que.IsEmpty())
                return false;

            return true;
        }
    }
}
