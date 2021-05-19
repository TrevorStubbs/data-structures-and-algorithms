using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPractice
{
    public static class CanSum
    {
        public static bool CanSumArray(int target, int[] array, Dictionary<int, bool> memo = null)
        {
            // Base Cases

            //// Does memo exist? If not create it.
            if (memo == null)
                memo = new Dictionary<int, bool>();

            //// Does memo have the target? If so return the memo at target.
            if (memo.ContainsKey(target))
                return memo[target];

            //// Is target == 0? If so then the method is true.
            if (target == 0)
                return true;

            //// Is target negative? If so then this branch is false.
            if (target < 0)
                return false;

            // Recursively call this method.
            foreach (var number in array)
            {
                var remainder = target - number;
                if (CanSumArray(remainder, array, memo))
                {
                    memo.Add(remainder, true);
                    return memo[remainder];
                }
            }

            // If all else fails return false.
            memo.Add(target, false);
            return memo[target];
        }     
    }
}
