using System;

namespace FindTheMedianOf2Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] array1 = {1, 2};
            int[] array2 = {3, 4};

            var answer = FindTheMedian.FindMedianSortedArrays(array1, array2);

            Console.WriteLine($"The answer is: {answer}.");

        }
    }
}
