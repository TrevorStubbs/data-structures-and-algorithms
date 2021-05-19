using System;

namespace RemoveDuplicatesFromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine();

            int[] inputArray = { 0, 1, 1, 2, 2, 3, 5, 6, 6 };

            var ouput = SortedArrayMethods.RemoveDuplicates(inputArray);

            foreach (var item in ouput)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
