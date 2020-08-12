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
