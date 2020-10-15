using System;
using System.Collections.Generic;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[] inputStr = { "dog", "racecar", "car" };

            Console.WriteLine(FindTheLongestCommonPrefix(inputStr));
        }

        public static string FindTheLongestCommonPrefix(string[] stringArr)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            int largestInt = 0;
            string largestPre = "";

            foreach (var str in stringArr)
            {
                for (int i = 1; i <= str.Length; i++)
                {
                    string subStr = str.Substring(0, i);

                    if (map.ContainsKey(subStr))
                    {
                        map[subStr]++;
                    }
                    else
                    {
                        map.Add(subStr, 1);
                    }

                    if(map[subStr] >= largestInt)
                    {
                        largestInt = map[subStr];
                        largestPre = subStr;
                    }
                }
            }



            //foreach(var item in map)
            //{
            //    if(item.Value >= largestInt && item.Key.Length > largestLength)
            //    {
            //        largestInt = item.Value;
            //        largestLength = item.Key.Length;
            //        largestPre = item.Key;
            //    }
            //}
            if (largestInt == 1)
                return "";
            else
                return largestPre;
        }
    }
}
