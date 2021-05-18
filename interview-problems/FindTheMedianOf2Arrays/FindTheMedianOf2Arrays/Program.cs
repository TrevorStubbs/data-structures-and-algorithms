using System;

namespace FindTheMedianOf2Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] array1 = {1, 3};
            int[] array2 = {2, 4};

            var answer = FindTheMedian.FindMedianSortedArrays(array1, array2);

            Console.WriteLine($"The answer is: {answer}.");



        }
    }
}
