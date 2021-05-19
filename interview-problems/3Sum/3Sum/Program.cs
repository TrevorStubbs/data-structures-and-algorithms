using System;
using System.Collections.Generic;
using System.Linq;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            list1.Add(1);
            list1.Add(2);
            list1.Add(3);

            list2.Add(1);
            list2.Add(2);
            list2.Add(3);

            var isEqual = Enumerable.SequenceEqual(list1, list2);

            var array1 = new int[] { 1, 2, 3 };
            var array2 = new int[] { 1, 2, 3 };

            Console.WriteLine(array1 == array2);
            Console.WriteLine("Hello World!");

            var sumList = ThreeSumIterative(new int[] { -1, 0, 1, 2, -1, -4 });

            foreach (var list in sumList)
            {
                Console.WriteLine($"{list[0]}, {list[1]}, {list[2]}");
            }

            var listOfLists = ThreeSumRecursive(new int[] { -1, 0, 1, 2, -1, -4 }, 1, 2, 3);
        }

        public static List<List<int>> ThreeSum(int[] numbers)
        {
            var outputListOfLists = new List<List<int>>();

            if (numbers.Length < 3)
                return outputListOfLists;

            foreach (var number in numbers)
            {

            }

            return outputListOfLists;
        }

        public static List<List<int>> ThreeSumIterative(int[] numbers)
        {
            var outputListOfLists = new List<List<int>>();
            var dict = new Dictionary<int, List<int>>();

            var set = new HashSet<int[]>();

            if (numbers.Length < 3)
                return outputListOfLists;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            var sum = numbers[i] + numbers[j] + numbers[k];

                            if (sum == 0)
                            {
                                if (!set.Contains(new int[] { numbers[i], numbers[j], numbers[k] }))
                                {
                                    var newList = new List<int>();
                                    newList.Add(numbers[i]);
                                    newList.Add(numbers[j]);
                                    newList.Add(numbers[k]);
                                    outputListOfLists.Add(newList);
                                    set.Add(new int[] { numbers[i], numbers[j], numbers[k] });
                                    set.Add(new int[] { numbers[j], numbers[k], numbers[i] });
                                    set.Add(new int[] { numbers[k], numbers[i], numbers[j] });
                                }
                            }


                            //var sum = numbers[i] + numbers[j] + numbers[k];
                            //var newList = new List<int>();
                            //newList.Add(numbers[i]);
                            //newList.Add(numbers[j]);
                            //newList.Add(numbers[k]);
                            //if (!set.Contains(newList))
                            //{
                            //    set.Add(newList);

                            //    if (sum == 0)
                            //    {
                            //        outputListOfLists.Add(newList);
                            //    }
                            //    else
                            //    {
                            //        set.Add(newList);
                            //    }
                            //}
                        }
                    }
                }
            }

            return outputListOfLists;
        }

        private static List<int> ThreeSumRecursive(int[] numbers, int i, int j, int k, Dictionary<int, int> memo = null)
        {
            if (memo == null)
                memo = new Dictionary<int, int>();

            if (i > numbers.Length || j > numbers.Length || k > numbers.Length)
                return null;

            if (i == j || i == k || j == k)
                return null;

            var list1 = ThreeSumRecursive(numbers, i + 1, j, k, memo);
            var list2 = ThreeSumRecursive(numbers, i, j + 1, k, memo);
            var list3 = ThreeSumRecursive(numbers, i, j, k + 1, memo);

            var sum = numbers[i] + numbers[j] + numbers[k];
            if (sum == 0)
            {
                var outputList = new List<int>();

                outputList.Add(numbers[i]);
                outputList.Add(numbers[j]);
                outputList.Add(numbers[k]);

                return outputList;
            }

            return null;
        }
    }
}
