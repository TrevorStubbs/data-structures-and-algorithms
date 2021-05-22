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

            var sub = str.Substring(1);

            Console.WriteLine(sub);

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


    }
}
