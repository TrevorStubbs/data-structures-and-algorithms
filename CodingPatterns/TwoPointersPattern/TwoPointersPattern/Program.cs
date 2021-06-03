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

            var removeDupsEducativeVersion = RemoveDuplicates.RemoveAllDupsWithArray(new int[] { 2, 3, 3, 3, 6, 9, 9 });

            Console.WriteLine($"Length after Dups have been removed: {removeDupsEducativeVersion}");

            Console.WriteLine();

            var easySquares = SquareArray.GenerateListOfSquaresEasy(new List<int>() { -2, -1, 0, 2, 3 });

            Console.Write($"[ ");

            foreach (var number in easySquares)
            {
                Console.Write($"{number} ");
            }

            Console.Write($"]");

            Console.WriteLine();

            var squares = SquareArray.GenerateArrayOfSquares(new int[] {-2, -1, 0, 2, 3 });

            Console.Write($"[ ");

            foreach (var number in squares)
            {
                Console.Write($"{number} ");
            }

            Console.Write($"]");

            Console.WriteLine();

            var listSquares = SquareArray.GenerateListOfSquares(new List<int>() { -2, -1, 0, 2, 3 });

            Console.Write($"[ ");

            foreach (var number in listSquares)
            {
                Console.Write($"{number} ");
            }

            Console.Write($"]");

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
            // Time - O(n)
            // Space - O(1)
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
                // This is 1 of the index pointers but it is also the end of the nonduplicated numbers.
                int nextNonDup = 1;

                // We start at 1 not zero cause we are going to be looking back 1 step.
                for (int i = 1; i < inputArr.Length; i++)
                {
                    // If the previous index to nextNonDup is not the same as the index we are currently look in at then...
                    if (inputArr[nextNonDup - 1] != inputArr[i])
                    {
                        // Make the array at nextNonDup index equal to the item we are looking at.
                        inputArr[nextNonDup] = inputArr[i];
                        // Iterate nextNonDup one spot.
                        nextNonDup++;
                    }
                }

                // The position of nextNonDup is the new length of the array.
                return nextNonDup;
            }
        }
        public static class SquareArray
        {
            // Time - O(n+n)
            // Space - O(n)
            public static List<int> GenerateListOfSquaresEasy(List<int> inputList)
            {
                List<int> squares = new List<int>();

                foreach (var number in inputList)
                {
                    squares.Add(number * number);
                }

                squares.Sort();

                return squares;
            }

            // Time - O(n)
            // Space - O(n)
            public static int[] GenerateArrayOfSquares(int[] inputList)
            {
                // The index of the number we are looking at.
                int highestSqrIndex = inputList.Length - 1;
                // This'll be the output
                int[] squares = new int[inputList.Length];

                // The two index pointers
                int left = 0;
                int right = inputList.Length - 1;

                // We dont know how many times we are going to loop so we use a while loop
                while(left <= right)
                {
                    // Find out the square root of the numbers under the left and right indexes
                    int leftSqr = inputList[left] * inputList[left];
                    int rightSqr = inputList[right] * inputList[right];
                                        
                    if(leftSqr > rightSqr)
                    {
                        // Iterate the highestSqrIndex down 1 spot and place the leftSqr into that spot.
                        squares[highestSqrIndex--] = leftSqr;
                        // Move the left index right 1 spot.
                        left++;
                    }
                    else
                    {
                        // Iterate the highestSqrIndexx down 1 spot and place the rightSqr into that spot.
                        squares[highestSqrIndex--] = rightSqr;
                        // Move the right index left 1 spot.
                        right--;
                    }

                }
                                
                return squares;
            }

            // This one is less efficient then the array once since we have to insert numbers at the beginning of the list which each time we do that is an O(n) time complexity. 
            public static List<int> GenerateListOfSquares(List<int> inputList)
            {               
                List<int> squares = new List<int>();

                int left = 0;
                int right = inputList.Count - 1;

                while (left <= right)
                {
                    int leftSqr = inputList[left] * inputList[left];
                    int rightSqr = inputList[right] * inputList[right];

                    if (leftSqr > rightSqr)
                    {
                        squares.Insert(0, leftSqr);
                        left++;
                    }
                    else
                    {
                        squares.Insert(0, rightSqr);
                        right--;
                    }
                }

                return squares;
            }

            public static List<int> GenerateListOfSquaresMiddleOut(List<int> inputList)
            {
                return null;
            }
        }
    }
}
