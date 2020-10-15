using System;
using System.Collections.Concurrent;
using System.Reflection.Metadata;

namespace QuickSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] input1 = { 8, 4, 23, 42, 16, 15 };

            QuickSortMethod(input1);

            for (int i = 0; i < input1.Length; i++)
            {
                Console.Write(input1[i] + " ");
            }
        }

        /// <summary>
        /// This is the main quick-sort method. It takes and array of integers and then sends it through the method of the same name which has the overloads.
        /// </summary>
        /// <param name="arr">An array of integers</param>
        /// <returns>The sorted array</returns>
        public static int[] QuickSortMethod(int[] arr)
        {
           return QuickSortMethod(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// This method takes an array and its upper and lower bounds.
        /// </summary>
        /// <param name="arr">Integer Array</param>
        /// <param name="left">Lower bound of the array</param>
        /// <param name="right">Upper bound of the array</param>
        /// <returns>A sorted integer array</returns>
        private static int[] QuickSortMethod(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int position = Partition(arr, left, right);

                QuickSortMethod(arr, left, position - 1);

                QuickSortMethod(arr, position + 1, right);
            }

            return arr;
        }

        /// <summary>
        /// This is the helper method for the Quick-Sort method. It takes an array with its left most and right most position. It creates a pivot with the left most item then compares that item with the rest of the array and finds exactly where that pivot needs to be in the array.
        /// </summary>
        /// <param name="arr">Integer array</param>
        /// <param name="left">Left most position</param>
        /// <param name="right">Right most position</param>
        /// <returns>the position of where the pivot needs to be.</returns>
        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];

            int low = left - 1;

            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    low++;

                    int temp1 = arr[low];
                    arr[low] = arr[i];
                    arr[i] = temp1;
                }
            }

            int temp2 = arr[low + 1];
            arr[low + 1] = arr[right];
            arr[right] = temp2;

            return low + 1;
        }
    }
}
