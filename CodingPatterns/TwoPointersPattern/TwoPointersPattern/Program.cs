using System;
using System.Collections.Generic;

namespace TwoPointersPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var sumList = PairSum.FindAPairsSumThatMatchesTarget(new List<int>() { 1, 2, 3, 4, 6 }, 6);

            Console.WriteLine($"Sum List [{sumList[0]}, {sumList[1]}]");

            Console.WriteLine();

            var sumListAlt = PairSum.FindAPairsAltSolution(new List<int>() { 1, 2, 3, 4, 6 }, 6);

            Console.WriteLine($"Sum List Alt [{sumList[0]}, {sumList[1]}]");

            Console.WriteLine();

            var removeDups = RemoveDuplicates.RemoveAllDuplicateNumbers(new List<int>() { 2, 2, 2, 11 });

            Console.WriteLine($"Length after Dups have been removed: {removeDups}");

            Console.WriteLine();
        }

        public static class PairSum
        {
            // Time - O(n)
            // Space - O(1)
            public static List<int> FindAPairsSumThatMatchesTarget(List<int> inputList, int target)
            {
                // These are the 2 pointers.
                int leftIndex = 0, rightIndex = inputList.Count - 1;

                // We don't know how long this is going to run so we use a while loop
                while (leftIndex < rightIndex)
                {
                    // This is the thing we are trying to do.
                    int sum = inputList[leftIndex] + inputList[rightIndex];

                    // If we accomplish the goal then we can build what we need and return it.
                    if (sum == target)
                    {
                        List<int> outputList = new List<int>()
                        {
                            leftIndex,
                            rightIndex
                        };

                        return outputList;
                    }

                    // ============ Moving the Pointers ====================

                    // If the product of our algorithm is bigger than the goal then move the right pointer left.
                    if (sum > target)
                    {
                        rightIndex--;
                    }

                    // If the product of our algorithm is smaller than the goal then move the left pointer right.
                    if (sum < target)
                    {
                        leftIndex++;
                    }
                }

                return new List<int>() { -1, -1 };
            }

            // ******** Not Two Pointers *****************
            // Time - O(n)
            // Space - O(1)
            public static List<int> FindAPairsAltSolution(List<int> inputList, int target)
            {
                // Since we are using a dictionary it takes up space.                
                Dictionary<int, int> numberDict = new Dictionary<int, int>();   // int -> number, int -> number's index

                for (int i = 0; i < inputList.Count; i++)
                {
                    if (numberDict.ContainsKey(target - inputList[i]))
                        return new List<int>() { target - inputList[i], i };
                    else
                        numberDict.Add(inputList[i], i);
                }

                return new List<int>() { -1, -1 };
            }
        }
        public static class RemoveDuplicates
        {
            public static int RemoveAllDuplicateNumbers(List<int> inputList)
            {
                // These are the 2 pointers
                int pointer1 = 0, pointer2 = 1;

                while (pointer1 < inputList.Count && pointer2 < inputList.Count)
                {
                    // if the number at the right pointer and the number at the left pointer are the same number then remove the right number.
                    if (inputList[pointer1] == inputList[pointer2])
                    {
                        inputList.RemoveAt(pointer2);
                    }
                    else
                    {
                        // else iterate both numbers to the right.
                        pointer1++;
                        pointer2++;
                    }
                }

                return inputList.Count;
            }

            public static int RemoveAllDupsWithArray(int[] inputArr)
            {
                // This is the index of the next non-duplicate element.
                int nextNonDup = 1;

                // We iterate the left pointer with this for loop
                for (int i = 1; i < inputArr.Length; i++)
                {
                    if (inputArr[nextNonDup - 1] != inputArr[i])
                    {
                        inputArr[nextNonDup] = inputArr[i];
                        nextNonDup++;
                    }
                }

                return nextNonDup;
            }
        }
    }
}
