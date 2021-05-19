using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPractice
{
    public static class GridTravel
    {
        public static long GridTraveler(long m, long n)
        {
            return GridTravelerHelper(m, n);
        }

        private static long GridTravelerHelper(long m, long n, Dictionary<string, long> memo = null)
        {
            if (memo == null)
                memo = new Dictionary<string, long>();

            string key = $"{m},{n}";

            if (memo.ContainsKey(key))
                return memo[key];
            if (m == 1 & n == 1)
                return 1;
            if (m == 0 || n == 0)
                return 0;


            memo[key] = GridTravelerHelper(m - 1, n, memo) + GridTravelerHelper(m, n - 1, memo);
            return memo[key];
        }
    }
}
