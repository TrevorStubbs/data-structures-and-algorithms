using System;
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

            Console.Write($"{windowSum}");
        }

        // Find the average of all contiguous subarrays of size 'K'.
        static class AverageOfSubarrayOfSizeK
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

                        if(windowEnd >= windowSize - 1)
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

    }
}
