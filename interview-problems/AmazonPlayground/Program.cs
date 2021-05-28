using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //string word = "bag";
            //string words = "baggage";

            //Console.WriteLine(word[2]);

            //var split = word.Split(word[2]);
            //Console.WriteLine(split[0]);

            //var list = new List<string>();

            //if (list.Any())

            //    Console.WriteLine(words.Contains(word));

            //if (words.Split(words[2])[0] == split[0])
            //    Console.WriteLine(true);

            //var sub = words.Substring(0, 2);

            //Console.WriteLine(sub);

            //Console.WriteLine();

            //Console.Write("abcd");
            //Console.Write("\n");
            //Console.Write("efgh \n");

            //List<int> arr = new List<int>()
            //{
            //    942381765,
            //    627450398,
            //    954173620,
            //    583762094,
            //    236817490
            //};

            //List<int> arr2 = new List<int>() { 254961783, 604179258, 462517083, 967304281, 860273491 };
            //List<int> arr3 = new List<int>() { 793810624, 895642170, 685903712, 623789054, 468592370 };

            //miniMaxSum(arr);
            //Console.WriteLine();
            //miniMaxSum(arr2);        
            //Console.WriteLine();
            //miniMaxSum(arr3);

            var str = "abcd";

            Console.WriteLine(str[4 - 1]);

            // Inclusive to the param
            var sub = str.Substring(str.Length - 2);

            //From position to length. Do no have it over run or it will error
            var sub2 = str.Substring(3, str.Length - 3);

            // Start at 0 and return a string of length 3
            var sub3 = str.Substring(0, 3);

            Console.WriteLine("Here: " + sub);
            Console.WriteLine(sub2);
            Console.WriteLine(sub3);
            Console.WriteLine(str.Last());

            var str1 = "abc";
            var str2 = "abc";

            Console.WriteLine(str1 == str2);

            var list1 = new List<string>() { str1, str2, "string4" };
            var list2 = new List<string>() { str1, str2, "string3"};

            Console.WriteLine(list1 == list2);

            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write($"{list1[i] == list2[i]}, ");
            }

            Tuple<int, int> tuple = new Tuple<int, int>(item1: 0, item2:0);

            tuple = 3;
        }

        public static void miniMaxSum(List<int> arr)
        {
            ulong min = 0x7FFFFFFF;
            ulong max = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                ulong sum = CalculateFromThisIndex(arr, i);

                if (sum > max)
                    max = sum;
                if (sum < min)
                    min = sum;
            }

            Console.Write($"{min} {max}");

        }

        private static ulong CalculateFromThisIndex(List<int> arr, int index)
        {
            ulong output = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (i != index)
                {
                    output += (ulong)arr[i];
                }
            }

            return output;
        }

        // What are the inputs?
        // What are the outputs?
        // What kind of comparison or adding or subtracting needs to happen?
        // Are we looking for the greatest or least of something?
        // How do we keep track of that?
        // How does that need to be returned?
        // How do we need to iterate through all the things?
        // Recusive?
        // Iterative?

        public static void Algorithm(string input)
        {
            // output var

            // Edge Cases and Base Cases

            // Iterate

            // Edge Cases

            // Return output
        }

        private static void DoTheThing(string input, int index)
        {
            // What are the required inputs?
            // What do i do when we find solution?
            // Do we add it to a list and return that list?
            // Do we return a bool?
            // Do we return a string?
            // Do we modifiy a global item.
        }

    }
}
