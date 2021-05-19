using System;
using System.Collections.Generic;

namespace GreatestNumberOfCandies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var list = KidsWithCandiesRec(new int[] { 2, 3, 5, 1, 3 }, 3);

            foreach (var kid in list)
            {
                Console.Write(kid);
            }
        }

        private static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            IList<bool> outputList = new List<bool>();

            int greatest = 0;

            foreach (var kid in candies)
            {
                if (kid > greatest)
                    greatest = kid;
            }

            foreach (var kid in candies)
            {
                if ((kid + extraCandies) >= greatest)
                    outputList.Add(true);
                else
                    outputList.Add(false);
            }

            return outputList;
        }

        private static IList<bool> KidsWithCandiesRec(int[] candies, int extraCandies)
        {
            IList<bool> outputList = new List<bool>();

            int greatest = FindHighest(candies, 0, candies.Length - 1);

            IList<bool> output = WouldBeGreater(candies, greatest, candies.Length - 1, extraCandies);

            foreach (var kid in candies)
            {
                if ((kid + extraCandies) >= greatest)
                    outputList.Add(true);
                else
                    outputList.Add(false);
            }

            return outputList;
        }

        private static int FindHighest(int[] candies, int greatest, int position)
        {
            if (position == 0)
                return candies[0];

            greatest = FindHighest(candies, greatest, position - 1);

            if (candies[position] > greatest)
                greatest = candies[position];

            return greatest;
        }

        private IList<bool> WouldBeGreater(int[] candies, int greatest, int position, int extraCandies)
        {
            IList<bool> outputList = new List<bool>();

            if (position == 0)
            {

                if ((candies[position] + extraCandies) >= greatest)
                    outputList.Add(true);
                else
                    outputList.Add(false);

                return outputList;
            }

            // outputList.Add(WouldBeGreater)

            return outputList;
        }
    }
}
