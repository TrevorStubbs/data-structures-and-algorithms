using System;
using System.Collections.Concurrent;

namespace InsertionSortProgram
{
    public class Program
    {
        static void Main(string[] args)
        {            
            int[] input1 = { 20, 18, 12, 8, 5, -2 };
            int[] input2 = { 5, 12, 7, 5, 5, 7 };
            int[] input3 = { 2, 3, 5, 7, 13, 11 };

            int[] output = InsertionSortMethod(input1);

            foreach (var item in output)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            output = InsertionSortMethod(input2);

            foreach (var item in output)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            output = InsertionSortMethod(input3);

            foreach (var item in output)
            {
                Console.Write(item + " ");
            }
        }

        public static int[] InsertionSortMethod(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int temp = arr[i];

                while (j >= 0 && temp < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = temp;
            }

            return arr;
        }
    }
}
