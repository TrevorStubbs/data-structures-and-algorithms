using LongestSubsring.Classes;
using System;

namespace LongestSubsring
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr1 = "abcabcbb"; // Expected: 3
            string inputStr2 = "bbbb"; // Expected: 1
            string inputStr3 = "pwwkew"; // Expected: 3
            string inputStr4 = "au";
            string inputStr5 = "aab";

            Console.WriteLine($"Expected: 3 Answer: {RepeatingSubstring.LongestSubstringWithoutRepeats(inputStr1)}");
            Console.WriteLine();
            Console.WriteLine($"Expected: 1 Answer: {RepeatingSubstring.LongestSubstringWithoutRepeats(inputStr2)}");
            Console.WriteLine();
            Console.WriteLine($"Expected: 3 Answer: {RepeatingSubstring.LongestSubstringWithoutRepeats(inputStr3)}");
            Console.WriteLine();
            Console.WriteLine($"Expected: 2 Answer: {RepeatingSubstring.LongestSubstringWithoutRepeats(inputStr4)}");
            Console.WriteLine();
            Console.WriteLine($"Expected: 2 Answer: {RepeatingSubstring.LongestSubstringWithoutRepeats(inputStr5)}");
        }
    }
}
