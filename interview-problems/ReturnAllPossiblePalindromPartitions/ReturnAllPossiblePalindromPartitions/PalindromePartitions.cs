using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnAllPossiblePalindromPartitions
{
    public static class PalindromePartitions
    {
        public static List<List<string>> GeneratePalindromePartitions(string inputString)
        {
            var allPartitions = new List<List<string>>();

            var currentPartition = new List<string>();

            var inputLength = inputString.Length;

            PalindromPartitionRecursion(allPartitions, currentPartition, inputString, inputLength);

            return allPartitions;
        }

        private static void PalindromPartitionRecursion(List<List<string>> allParitions, List<string> currentPartition, string input, int stringLength, int start = 0)
        {
            if (start >= stringLength)
            {
                allParitions.Add(new List<string>(currentPartition));
                return;
            }

            for (int i = start; i < stringLength; i++)
            {
                if (IsPalindrome(input, start, i))
                {
                    currentPartition.Add(input.Substring(start, i + 1 - start));

                    PalindromPartitionRecursion(allParitions, currentPartition, input, stringLength, i + 1);

                    currentPartition.RemoveAt(currentPartition.Count - 1);
                }
            }
        }


        private static bool IsPalindrome(string input)
        {
            char[] strChar = input.ToCharArray();
            Array.Reverse(strChar);
            var newString = new String(strChar);

            if (input == newString)
                return true;

            return false;
        }

        private static bool IsPalindrome(string input, int start, int i)
        {
            while (start < i)
            {
                if (input[start++] != input[i--])
                    return false;
            }
            return true;
        }
    }
}
