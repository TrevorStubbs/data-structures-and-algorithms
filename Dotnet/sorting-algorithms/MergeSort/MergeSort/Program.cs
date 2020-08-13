using System;
using System.IO.MemoryMappedFiles;

namespace MergeSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 8, 4, 23, 42, 16, 15 };

            MergeSortMethod(input1);

            foreach (var item in input1)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// This method splits the input array in half and then recursively calls itself again to keep splitting the array up. Once its split it sends it through the next method.
        /// </summary>
        /// <param name="arr">An array of integers</param>
        /// <returns>An array of integers</returns>
        public static int[] MergeSortMethod(int[] arr)
        {
            int n = arr.Length;

            if (n > 1)
            {
                int mid = n / 2;
                int[] left = new int[mid];
                int[] right;

                if(arr.Length % 2 == 0)
                {
                    right = new int[mid];
                }
                else
                {
                    right = new int[mid + 1];
                }

                for (int i = 0; i < mid; i++)
                {
                    left[i] = arr[i];
                }

                int x = 0;
                for (int i = mid; i < arr.Length; i++)
                {
                    right[x] = arr[i];
                    x++;
                }

                MergeSortMethod(left);

                MergeSortMethod(right);

                MergeSortMethod(left, right, arr);
            }

            return arr;
        }

        /// <summary>
        /// This method takes the input array and the upper and low bounds of the array. The rest of the method stitches the array back together while sorting its elements.
        /// </summary>
        /// <param name="left">The low bound of the array</param>
        /// <param name="right">The upper bound of the array</param>
        /// <param name="arr">An integer array</param>
        static void MergeSortMethod(int[] left, int[] right, int[] arr)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while(i < left.Length && j < right.Length)
            {
                if(left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }

                k++;
            }

            if (i == left.Length)
            {
                while (j < right.Length)
                {
                    arr[k] = right[j];
                    j++;
                    k++;
                }
            }
            else
            {
                while (i < left.Length)
                {
                    arr[k] = left[i];
                    i++;
                    k++;
                }
            }
        }
    }
}
