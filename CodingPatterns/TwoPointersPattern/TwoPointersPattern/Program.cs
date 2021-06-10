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

            var squares = SquareArray.GenerateArrayOfSquares(new int[] { -2, -1, 0, 2, 3 });

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

            var triplets = TripletsToZero.FindUniqueTripletsThatEqualZero(new List<int>() { -3, 0, 1, 2, -1, 1, -2 });

            foreach (var list in triplets)
            {
                Console.Write($"Triplet: ");
                foreach (var number in list)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            var closestToTarget = TripletSum.FindTripletSumClosestToTarget(new List<int>() { 1, 0, 1, 1 }, 100);

            Console.WriteLine($"Closest: {closestToTarget}");

            Console.WriteLine();

            var searchTriplet = TripletSum.SearchTriplet(new int[] { 1, 0, 1, 1 }, 100);

            Console.WriteLine($"Educative Closest: {searchTriplet}");

            Console.WriteLine();

            var tripletCount = CountTriplets.CountTripletsThatHasASumLessThanTarget(new List<int>() { -1, 4, 2, 1, 3 }, 5);

            Console.WriteLine($"Triplets Less than target: {tripletCount}");

            Console.WriteLine();

            var productsList = ProductLessThanTarget.FindProductsLessThanTarget(new List<int>() { 8, 2, 6, 5 }, 50);

            Console.WriteLine($"Product List: ");
            foreach (var list in productsList)
            {
                Console.Write(" [");
                foreach (var number in list)
                {
                    Console.Write($"{number} ");
                }
                Console.Write("] ");
            }

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
            // Space - O(n)
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
                while (left <= right)
                {
                    // Find out the square root of the numbers under the left and right indexes
                    int leftSqr = inputList[left] * inputList[left];
                    int rightSqr = inputList[right] * inputList[right];

                    if (leftSqr > rightSqr)
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
        public static class TripletsToZero
        {
            // Here we change the goal posts from looking for a '0' but now looking for x + y = -z.
            // z is the what we will be comparing to now.

            // Time -> O(n^2) Comes from O(n * logN + n^2)
            // Space -> O(n)
            public static List<List<int>> FindUniqueTripletsThatEqualZero(List<int> inputList)
            {
                // Use the built in sorting method.
                inputList.Sort();
                List<List<int>> outputList = new List<List<int>>();

                // -2 since we want to stop before the last index in the array.
                for (int i = 0; i < inputList.Count - 2; i++)
                {
                    // Skip repeated numbers.
                    if (i > 0 && inputList[i] == inputList[i - 1])
                        continue;

                    // Here we use another method to build the triplet lists.
                    searchPair(inputList, -inputList[i], i + 1, outputList);
                }

                return outputList;
            }

            /// <summary>
            /// Left is 1 of the 2 pointers
            /// targetSum is what we will be comparing to. We make it a negative of itself so we can follow the x+y = -z pattern.
            /// </summary>
            /// <param name="inputList">Bring in the original list</param>
            /// <param name="targetSum">This is the comparator</param>
            /// <param name="leftIndex">Left Pointer</param>
            /// <param name="triplets">Pointer to the output list of lists</param>
            private static void searchPair(List<int> inputList, int targetSum, int leftIndex, List<List<int>> triplets)
            {
                // This is the right pointer
                int rightIndex = inputList.Count - 1;
                while (leftIndex < rightIndex)
                {
                    // Find the sum
                    int currentSum = inputList[leftIndex] + inputList[rightIndex];
                    // Compare the sum to the target and if they are equal to each other...
                    if (currentSum == targetSum)
                    {
                        // Add a new triplet to the list.
                        triplets.Add(new List<int>()
                        {
                            // Get the targetSum back to it's original state

                            -targetSum,
                            inputList[leftIndex],
                            inputList[rightIndex]
                        });
                        // Iterate the pointers
                        leftIndex++;
                        rightIndex--;

                        // Check for Duplicates we also need to make sure that the original while is being followed.
                        while (leftIndex < rightIndex && inputList[leftIndex] == inputList[leftIndex - 1])
                        {
                            leftIndex++;
                        }
                        while (leftIndex < rightIndex && inputList[rightIndex] == inputList[rightIndex + 1])
                        {
                            rightIndex--;
                        }
                    }
                    // If the target is greater than the current sum then move the left pointer right
                    else if (targetSum > currentSum)
                        leftIndex++;
                    // Move the right pointer left.
                    else
                        rightIndex--;
                }
            }
        }
        public static class TripletSum
        {
            public static int FindTripletSumClosestToTarget(List<int> inputArray, int targetSum)
            {
                // The array is supposed to come sorted but this will make sure it does. (This does add time complexity to the algorithm).
                inputArray.Sort();

                // This is the output integer.
                int sumOfClosest = 0;

                // This for loop is used to capture the one of the digits so we can add it in the next method.
                for (int digit = 0; digit < inputArray.Count - 2; digit++)
                {
                    // Find the closest sum using the captured digit.
                    int sum = FindClosest(inputArray, digit + 1, inputArray[digit], targetSum);

                    // If the sum is the target no need to figure out a closer sum.
                    if (sum == targetSum)
                        return sum;

                    // Check to see if this triplet is closer than the previous closer sum.
                    if (IsCloser(targetSum, sumOfClosest, sum))
                        sumOfClosest = sum;
                }

                return sumOfClosest;
            }

            private static int FindClosest(List<int> inputArray, int leftIndex, int thirdDigit, int targetSum)
            {
                // Var to hold the closest sum
                int sumOfClosest = 0;
                // This is the right Index.
                int rightIndex = inputArray.Count - 1;

                // We don't know how long the loop is going to run since either the rightIndex or the leftIndex will move.
                while (leftIndex < rightIndex)
                {
                    // Get the sum of the triplet
                    int sum = thirdDigit + inputArray[leftIndex] + inputArray[rightIndex];
                    // Find the difference between the triplet and the target.
                    int diff = sum - targetSum;

                    // If the diff == 0 then we have found a triplet that is equal to the target so we just return that without doing anything else.
                    if (diff == 0)
                        return sum;
                    // If the diff is less than the sum then we move the leftIndex right.
                    else if (diff < targetSum)
                        leftIndex++;
                    // Else it diff will be greater than sum so then we move the rightIndex left;
                    else
                        rightIndex--;

                    // Check to see if this sum is closer than the recorded closest sum.
                    if (IsCloser(targetSum, sumOfClosest, sum))
                        sumOfClosest = sum;
                }

                return sumOfClosest;
            }

            private static bool IsCloser(int target, int prevClosest, int thisSum)
            {
                int preDiff = Math.Abs(target - prevClosest);
                int thisDiff = Math.Abs(target - thisSum);

                if (thisDiff < preDiff)
                    return true;

                return false;
            }

            public static int SearchTriplet(int[] arr, int targetSum)
            {
                Array.Sort(arr);
                int smallestDiff = int.MaxValue;

                for (int i = 0; i < arr.Length - 2; i++)
                {
                    int left = i + 1, right = arr.Length - 1;
                    while (left < right)
                    {
                        int targetDiff = targetSum - arr[i] - arr[left] - arr[right];
                        if (targetDiff == 0)
                            return targetSum - targetDiff;

                        if (Math.Abs(targetDiff) < Math.Abs(smallestDiff) || (Math.Abs(targetDiff) == Math.Abs(smallestDiff) && targetDiff > smallestDiff))
                            smallestDiff = targetDiff;

                        if (targetDiff > 0)
                            left++;
                        else
                            right++;
                    }
                }

                return targetSum - smallestDiff;
            }
        }
        public static class CountTriplets
        {
            public static int CountTripletsThatHasASumLessThanTarget(List<int> inputList, int target)
            {
                // Sort the List to be able to use 2 pointers
                inputList.Sort();
                List<List<int>> tripletList = new List<List<int>>();

                // Start a loop to define a comparator pointer
                for (int digit = 0; digit < inputList.Count - 2; digit++)
                {
                    // Left = digit + 1, comparator == inputList[digit]
                    AddToTripletList(inputList, digit + 1, inputList[digit], target, tripletList);
                }

                return tripletList.Count;
            }

            private static void AddToTripletList(List<int> inputList, int leftIndex, int thirdDigit, int target, List<List<int>> tripletList)
            {
                // Right pointer is on the last index
                int rightIndex = inputList.Count - 1;

                // While loop since we don't how many times we are going to go through the list.
                while (leftIndex < rightIndex)
                {                    
                    int sum = thirdDigit + inputList[leftIndex] + inputList[rightIndex];

                    // If the goal has been met...
                    if (sum < target)
                    {
                        // Add the triplet to the triplet list
                        tripletList.Add(new List<int>() { thirdDigit, inputList[leftIndex], inputList[rightIndex] });

                        // Since the these 3 numbers work we know that any number less than the number at the right index will be less than the target so we just add those triplets to the list.
                        for (int i = rightIndex - 1; i > leftIndex; i--)
                        {
                            tripletList.Add(new List<int>() { thirdDigit, inputList[leftIndex], inputList[rightIndex] });
                        }

                        // Iterate the leftIndex to the right.
                        leftIndex++;
                    }

                    // Once out of the loop we iterate the right index to the left.
                    rightIndex--;
                }
            }
        }
        public static class ProductLessThanTarget
        {
            public static List<List<int>> FindProductsLessThanTarget(List<int> inputList, int target)
            {
                List<List<int>> outputList = new List<List<int>>();

                if (inputList[0] < target)
                    outputList.Add(new List<int>() { inputList[0] });

                for (int i = 1; i < inputList.Count; i++)
                {
                    if(inputList[i] < target)
                    {
                        outputList.Add(new List<int>() { inputList[i] });

                        if(inputList[i] * inputList[i-1] < target)
                        {
                            outputList.Add(new List<int>() { inputList[i - 1], inputList[i] });
                        }
                    }
                }

                return outputList;
            }
        }
    }
}
