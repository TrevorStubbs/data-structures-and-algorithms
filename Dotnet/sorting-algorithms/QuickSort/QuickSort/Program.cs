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

            QuickSortMethod(input1, 0, input1.Length - 1 );

            for (int i = 0; i < input1.Length; i++)
            {
                Console.Write(input1[i] + " ");
            }
        }

        public static int[] QuickSortMethod(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int position = Partition(arr, left, right);

                QuickSortMethod(arr, left, position - 1);

                QuickSortMethod(arr, position + 1, right);
            }

            return arr;
        }

        public static int Partition(int[] arr, int left, int right)
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
