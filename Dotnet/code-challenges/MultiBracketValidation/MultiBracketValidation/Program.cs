using System;
using StacksAndQueuesLibrary;

namespace MultiBracketValidation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Go Team Amanda!");
            Console.WriteLine(MultiBracketValidationMethod("{}"));
            Console.WriteLine(MultiBracketValidationMethod("{}(){}"));
            Console.WriteLine(MultiBracketValidationMethod("{}()[[Extra Characters]]"));
            Console.WriteLine(MultiBracketValidationMethod("(){}[[]]"));
            Console.WriteLine(MultiBracketValidationMethod("{}{Code}[Fellows](())"));
            Console.WriteLine(MultiBracketValidationMethod("[({}]"));
            Console.WriteLine(MultiBracketValidationMethod("(]("));
            Console.WriteLine(MultiBracketValidationMethod("{(})"));
        }

        /// <summary>
        /// This method takes a string and compares the brackets in the string.
        /// If the closing brackets match the opening brackets then return true else return false
        /// </summary>
        /// <param name="input">Take a string</param>
        /// <returns>Returns a boolean</returns>
        public static bool MultiBracketValidationMethod(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                    stack.Push(item);
                else if (item == '}' || item == ']' || item == ')')
                {
                    char leftChar = stack.Pop().Value;

                    if (leftChar == '{')
                        if (item != '}')
                            return false;
                        else if (leftChar == '[')
                            if (item != ']')
                                return false;
                            else if (leftChar == '(')
                                if (item != ')')
                                    return false;
                }

            }

            if (!stack.IsEmpty())
                return false;

            return true;
        }
    }
}
