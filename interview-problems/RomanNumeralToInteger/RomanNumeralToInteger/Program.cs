using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace RomanNumeralToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(RomanToInt("III"));
            Console.WriteLine(RomanToInt("IV"));
            Console.WriteLine(RomanToInt("LVIII"));
            Console.WriteLine(RomanToInt("MCMXCIV"));
            Console.WriteLine(RomanToInt("MMMXLV"));
        }

        public static int RomanToInt(string inputStr)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>()
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };

            char[] charArray = inputStr.ToUpper().ToCharArray();
            int outputInt = 0;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (i - 1 >= 0)
                {
                    if (charArray[i] == 'V' && charArray[i - 1] == 'I')
                        outputInt += 3;
                    else if (charArray[i] == 'X' && charArray[i - 1] == 'I')
                        outputInt += 8;
                    else if (charArray[i] == 'L' && charArray[i - 1] == 'X')
                        outputInt += 30;
                    else if (charArray[i] == 'C' && charArray[i - 1] == 'X')
                        outputInt += 80;
                    else if (charArray[i] == 'D' && charArray[i - 1] == 'C')
                        outputInt += 300;
                    else if (charArray[i] == 'M' && charArray[i - 1] == 'C')
                        outputInt += 800;
                    else
                        outputInt += dic[charArray[i]];
                }
                else
                    outputInt += dic[charArray[i]];
            }
            return outputInt;
        }
    }
}
