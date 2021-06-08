using System;
using System.Collections;
using System.Collections.Generic;

namespace SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var brute = AverageOfSubarrayOfSizeK.FindAveragesBruteForce(5, new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 });

            foreach (var number in brute)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();

            var window = AverageOfSubarrayOfSizeK.FindAveragesBruteForce(5, new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 });

            foreach (var number in window)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();

            var windowSum = SmallestSubarray.SmallestSubarrayGreaterThanS(8, new int[] { 3, 4, 1, 1, 6 });

            Console.Write($"WindowSum: {windowSum}");

            Console.WriteLine();

            var distinct = LongestSubstring.LongestSubstringWithNoMoreThanKDistinctChars("cbbbebi", 1);

            Console.WriteLine($"Longest Substring: {distinct}");


            Console.WriteLine();

            var fruits = FruitTree.MaxNoOfFruits(new char[] { 'A', 'B', 'C', 'B', 'B', 'C' });

            Console.WriteLine($"Fruits: {fruits}");

            Console.WriteLine();

            var maxNoRepeats = NoRepeatChars.NoRepeatCharsInASubstring("abccde");

            Console.WriteLine($"Max No Repeats: {maxNoRepeats}");

            Console.WriteLine();

            var longestSubstring = ReplaceToFindLongest.ReplaceKCharsToFindLongestSubString("aabccbb", 2);

            Console.WriteLine($"Replace to find longest: {longestSubstring}");

            Console.WriteLine();

            var replaceBits = BitArrayReplace.ReplaceK1sInBitArray(new List<int>() { 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }, 3);

            Console.WriteLine($"Longest Replaced 0s: {replaceBits}");

            Console.WriteLine();

            var isPermutation = ContainsPermuations.DoesContainPermutation("oidbcaf", "abc");

            Console.WriteLine($"Is Permutation: {isPermutation}");

            Console.WriteLine();

            var isEducativePermutation = ContainsPermuations.EducativeVersion("oidbcaf", "abc");

            Console.WriteLine($"Is Permutation: {isEducativePermutation}");

            Console.WriteLine();

            List<List<int>> sixBySixList = new List<List<int>>()
            {
                new List<int>(){1, 1, 1, 0, 0, 0},
                new List<int>(){0, 1, 0, 0, 0, 0},
                new List<int>(){1, 1, 1, 0, 0, 0},
                new List<int>(){0, 9, 2, -4, -4, 0},
                new List<int>(){0, 0, 0, -2, 0, 0},
                new List<int>(){0, 0, -1, -2, -4, 0},

            };

            var largestHourGlass = HourGlass.HourglassSum(sixBySixList);

            Console.WriteLine($"Hour Glass Max: {largestHourGlass}");

            Console.WriteLine();
        }

        // Find the average of all contiguous subarrays of size 'K'.
        public static class AverageOfSubarrayOfSizeK
        {
            // Brute Force Method -
            // Time Complexity O(K*N) where N is the number of elements in the array.
            // This will cause elements in this array to be evaluated more than once.

            public static double[] FindAveragesBruteForce(int k, int[] arr)
            {
                double[] result = new double[arr.Length - k + 1];

                for (int i = 0; i <= arr.Length - k; i++)
                {
                    double sum = 0;
                    for (int j = i; j < i + k; j++)
                    {
                        sum += arr[j];
                    }

                    result[i] = sum / k;
                }

                return result;
            }

            // Sliding window Approach
            public static double[] FindAveragesSlidingWindow(int k, int[] arr)
            {
                double[] result = new double[arr.Length - k + 1];
                double windowSum = 0;
                int windowStart = 0;
                for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
                {
                    // Add the next element to the window
                    windowSum += arr[windowEnd];

                    // Slide the window (if window is not at the desired size yet then this if statement is not triggered)]
                    if (windowEnd >= k - 1) // -1 since arr starts at 0
                    {
                        result[windowStart] = windowSum / k; // Find the average of this window

                        // Slide the window
                        windowSum -= arr[windowStart]; // Remove the first element of the window
                        windowStart++; // Iterate the start index
                    }

                }

                return null;
            }            
        }

        public static class SmallestSubarray
        {
            public static int SmallestSubarrayGreaterThanS(int s, int[] arr)
            {
                int windowSize = 1;

                while (windowSize <= arr.Length)
                {
                    int windowSum = 0;
                    List<int> window = new List<int>();

                    for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
                    {
                        window.Add(arr[windowEnd]);
                        windowSum += arr[windowEnd];

                        if (windowSum >= s)
                            return windowSize;

                        if (windowEnd >= windowSize - 1)
                        {
                            windowSum -= window[0];
                            window.RemoveAt(0);
                        }
                    }

                    windowSize++;
                }

                return 0;
            }
        }

        public static class LongestSubstring
        {
            // Time - O(n)
            // Space - O(k) 
            public static int LongestSubstringWithNoMoreThanKDistinctChars(string input, int k)
            {
                HashSet<char> window = new HashSet<char>();

                // This is the output.
                int maxLength = 0;

                int windowEnd = 0;
                int windowStart = 0;

                while (windowEnd < input.Length)
                {
                    // If the char at "windowEnd" is not in the hashset then add it.
                    if (!window.Contains(input[windowEnd]))
                    {
                        window.Add(input[windowEnd]);
                    }

                    // While the hashset is larger than "k" number of distinct characters then keep removing chars until the length of the window is less than or equal to "k".
                    // Every time we remove an item from the window iterate "windowStart" to shrink the window.
                    while (window.Count > k)
                    {
                        window.Remove(input[windowStart]);
                        windowStart++;
                    }

                    maxLength = Math.Max(maxLength, (windowEnd - windowStart + 1));

                    windowEnd++;
                }

                return maxLength;
            }
        }

        public static class FruitTree
        {
            // Time O(n) - O(n+n) If it gets triggered the inner loop is processed only once.
            // Space O(1) - constant space
            public static int MaxNoOfFruits(char[] charArray)
            {
                HashSet<char> window = new HashSet<char>();

                int maxFruits = 0;
                int windowStart = 0;

                for (int windowEnd = 0; windowEnd < charArray.Length; windowEnd++)
                {
                    if (!window.Contains(charArray[windowEnd]))
                    {
                        window.Add(charArray[windowEnd]);
                    }

                    while (window.Count > 2)
                    {
                        window.Remove(charArray[windowStart]);
                        windowStart++;
                    }

                    maxFruits = Math.Max(maxFruits, (windowEnd - windowStart + 1));
                }

                return maxFruits;

            }
        }

        public static class NoRepeatChars
        {
            public static int NoRepeatCharsInASubstring(string inputString)
            {
                // This time we need a Dictionary to keep track of the char's index in the string.
                Dictionary<char, int> indexMap = new Dictionary<char, int>();

                // Same as above
                int maxLength = 0;
                int windowStart = 0;

                for (int windowEnd = 0; windowEnd < inputString.Length; windowEnd++)
                {
                    // If the Dictionary contains the key then we will move the windowStart to the farthest right repeat char.  
                    if (indexMap.ContainsKey(inputString[windowEnd]))
                    {
                        // We add 1 due to iterators starting at 0.
                        windowStart = Math.Max(windowStart, indexMap[inputString[windowEnd]] + 1);
                        indexMap[inputString[windowEnd]] = windowEnd;
                    }
                    else
                    {
                        // If indexMap doesn't have the char then it is distinct so we should add it to the Dictionary.
                        indexMap.Add(inputString[windowEnd], windowEnd);
                    }

                    maxLength = Math.Max(maxLength, (windowEnd - windowStart + 1));

                }

                return maxLength;
            }
        }

        public static class ReplaceToFindLongest
        {
            public static int ReplaceKCharsToFindLongestSubString(string inputString, int k)
            {
                // We need a dictionary to record the number of times a char is repeated
                Dictionary<char, int> freqDict = new Dictionary<char, int>();

                int maxLength = 0;
                int windowStart = 0;

                // Keep track to the longest repeated character
                int maxRepeatLetterCount = 0;

                for (int windowEnd = 0; windowEnd < inputString.Length; windowEnd++)
                {
                    // If the char is not in the dictionary then add it with a value of 0.
                    if (!freqDict.ContainsKey(inputString[windowEnd]))
                    {
                        freqDict.Add(inputString[windowEnd], 0);
                    }

                    // No matter what add 1 to that char's counter.
                    freqDict[inputString[windowEnd]] += 1;

                    // Check to see which if the char at window end has more repeats than the previous longest.
                    maxRepeatLetterCount = Math.Max(maxRepeatLetterCount, freqDict[inputString[windowEnd]]);

                    // Determine if we need to shrink the window.
                    // ie - 3 - 1 + 1 + 4
                    // This doesn't need to be a while loop since we have only added 1 char to the Dict.
                    if ((windowEnd - windowStart + 1 - maxRepeatLetterCount) > k)
                    {
                        // Remove 1 from the char at index windowStart
                        freqDict[inputString[windowStart]] -= 1;
                        // Move window start 1 spot to the right. 
                        windowStart += 1;
                    }

                    // Check to see if this window is biggest window.
                    maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
                }

                return maxLength;
            }
        }

        public static class BitArrayReplace
        {
            public static int ReplaceK1sInBitArray(List<int> inputArray, int k)
            {
                Dictionary<int, int> freqDict = new Dictionary<int, int>();

                int windowStart = 0;
                int maxLength = 0;

                // Find a window with k number of 0s. and that will be compared to maxLength.
                for (int windowEnd = 0; windowEnd < inputArray.Count; windowEnd++)
                {
                    if (!freqDict.ContainsKey(inputArray[windowEnd]))
                    {
                        freqDict.Add(inputArray[windowEnd], 0);
                    }

                    freqDict[inputArray[windowEnd]] += 1;

                    while (freqDict[0] > k)
                    {
                        freqDict[inputArray[windowStart]] -= 1;
                        windowStart += 1;
                    }

                    maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
                }

                return maxLength;
            }
        }

        public static class ContainsPermuations
        {
            public static bool DoesContainPermutation(string inputString, string pattern)
            {
                // Build a Dictionary that has all the Chars as the keys and the values are the number of times those chars appear in the input pattern.
                var permutationDict = GeneratePermutationDict(pattern);

                // A list of chars that represents the window.
                List<char> window = new List<char>();

                // Keep track of the start position
                int windowStart = 0;

                for (int windowEnd = 0; windowEnd < inputString.Length; windowEnd++)
                {
                    // add the last char of the input to the window
                    window.Add(inputString[windowEnd]);

                    // if the window is larger than the length of the pattern then remove the first element from the window.
                    if (windowEnd - windowStart + 1 > pattern.Length)
                    {
                        window.Remove(inputString[windowStart]);
                        // Move the start point 1 spot to the right.
                        windowStart++;
                    }

                    // if the window is the size of the pattern then start the comparison. 
                    if (window.Count == pattern.Length)
                    {
                        // If the window matches a permutation then return true.
                        if (DoesContainPerm(window, permutationDict))
                            return true;
                    }
                }

                return false;
            }

            private static Dictionary<char, int> GeneratePermutationDict(string pattern)
            {
                Dictionary<char, int> freqDict = new Dictionary<char, int>();

                // Go through each character and count how many times it shows up in the pattern and add that number to the Dict
                foreach (var ch in pattern)
                {
                    if (!freqDict.ContainsKey(ch))
                        freqDict.Add(ch, 0);

                    freqDict[ch] += 1;
                }

                return freqDict;
            }

            private static bool DoesContainPerm(List<char> listOfChars, Dictionary<char, int> freqDict)
            {
                // Build a temp dict so we are not changing the original dict.
                var tempDict = new Dictionary<char, int>(freqDict);

                // Go through the list of characters and see if they match the permutation dictionary.          
                foreach (var ch in listOfChars)
                {
                    // If the char is not in the dict then just return false cause the rest will not be true.
                    if (!tempDict.ContainsKey(ch))
                        return false;
                    else
                        // Subtract 1 from that dict
                        tempDict[ch]--;
                }

                // Here we are checking to see if all the values of the keys are 0. If they are then we can return true.
                foreach (var ch in tempDict)
                {
                    if (ch.Value != 0)
                        return false;
                }

                return true;
            }
            public static bool EducativeVersion(string str, string pattern)
            {
                int windowStart = 0, matched = 0;

                // The example has the same statements but all in this method (no need to rewrite it).
                Dictionary<char, int> charFreqDict = GeneratePermutationDict(pattern);

                // Everything is done in place. No multiple loops.
                for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
                {
                    // If char is in the Dict
                    if (charFreqDict.ContainsKey(str[windowEnd]))
                    {
                        //...If so then subtract that 1 from that key.
                        charFreqDict[str[windowEnd]] -= 1;

                        // If char's counter is 0 then add 1 to the match variable
                        if (charFreqDict[str[windowEnd]] == 0)
                            matched++;
                    }


                    // If match number matches the count of the dict then we know that this window is a permutation of the pattern.
                    if (matched == charFreqDict.Count)
                        return true;

                    // Move windowStart if the window becomes larger than pattern.
                    if (windowEnd >= pattern.Length - 1)
                    {
                        // Variable for clarity
                        var leftChar = str[windowStart++];

                        // If str[windowStart] is in the dictionary then revert what we did above.
                        if (charFreqDict.ContainsKey(leftChar))
                        {
                            // Take 1 away from matched
                            if (charFreqDict[leftChar] == 0)
                                matched--;

                            // Add 1 back to the key's counter.
                            charFreqDict[leftChar] += 1;
                        }
                    }
                }

                return false;
            }

        }

        public static class HourGlass
        {
            public static int HourglassSum(List<List<int>> arr)
            {
                int max = int.MinValue;

                for (int row = 0; row < arr.Count - 2; row++)
                {

                    int topSum = 0;
                    int bottomSum = 0;

                    int windowStart = 0;
                    int windowSize = 3;

                    for (int windowEnd = 0; windowEnd < arr[row].Count; windowEnd++)
                    {
                        topSum += arr[row][windowEnd];
                        bottomSum += arr[row + 2][windowEnd];

                        if (windowEnd - windowStart > windowSize - 1)
                        {
                            topSum -= arr[row][windowStart];
                            bottomSum -= arr[row + 2][windowStart];
                            windowStart++;
                        }

                        if (windowEnd - windowStart == windowSize - 1)
                        {
                            int middle = arr[row + 1][windowEnd - 1];                  

                            int sum = CountGlass(topSum, bottomSum, middle);

                            max = Math.Max(max, sum);
                        }

                    }
                }

                return max;
            }

            public static int CountGlass(int top, int bottom, int middle)
            {
                return (top + bottom + middle);
            }
        }
    }

}
