using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseWithStringManipulation(-123));
        }

        public static int ReverseWithStringManipulation(int inputInt)
        {
            List<char> charList = inputInt.ToString().ToCharArray().ToList();

            char negative = default;

            if (charList[0] == '-')
            {
                charList.Remove(charList[0]);
                negative = '-';
            }

            charList.Reverse();

            if (negative != default)
            {
                charList.Insert(0, '-');
            }

            StringBuilder sb = new StringBuilder();

            foreach (var character in charList)
            {
                sb.Append(character.ToString());
            }

            string outputStr = sb.ToString();

            bool tryThis = Int32.TryParse(outputStr, out int outputInt);

            if (!tryThis)
                return 0;

            return outputInt;
        }
    }
}

