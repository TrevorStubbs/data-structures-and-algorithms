using System;

namespace RunningSumOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var array = RunningSum(new int[] { 1, 2, 3, 4 });
        }

        private static int[] RunningSum(int[] nums)
        {
            if (nums.Length == 1)
                return new int[] { nums[0] };

            var recusrionArray = new int[nums.Length - 1];

            for (int i = 0; i < recusrionArray.Length; i++)
            {
                recusrionArray[i] = nums[i];
            }

            var array = RunningSum(recusrionArray);

            var sum = 0;
            foreach (var number in nums)
            {
                sum += number;
            }

            var outputArray = new int[array.Length + 1];

            for (int i = 0; i < outputArray.Length - 1; i++)
            {
                outputArray[i] = array[i];
            }

            outputArray[outputArray.Length - 1] = sum;

            return outputArray;
        }

        private static int[] RunningSumV2(int[] nums)
        {
            if (nums.Length == 1)
                return new int[] { nums[0] };

            var recusrionArray = new int[nums.Length - 1];

            for (int i = 0; i < recusrionArray.Length; i++)
            {
                recusrionArray[i] = nums[i];
            }

            var array = RunningSumV2(recusrionArray);

            var sum = 0;
            foreach (var number in nums)
            {
                sum += number;
            }

            var outputArray = new int[array.Length + 1];

            for (int i = 0; i < outputArray.Length - 1; i++)
            {
                outputArray[i] = array[i];
            }

            outputArray[outputArray.Length - 1] = sum;

            return outputArray;
        }
    }
}
