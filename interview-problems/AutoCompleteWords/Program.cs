using System;
using System.Collections.Generic;

namespace AutoCompleteWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var repo = new List<string>()
            {
                "bag",
                "baggage",
                "babage",
                "apple",
                "bagger"
            };

            var keywords = AutoCompleteKeyword(repo, "baggage");

            foreach (var outerList in keywords)
            {
                foreach (var wd in outerList)
                {
                    Console.Write($"{wd} ");
                }
                Console.WriteLine();
            }
        }

        private static List<List<string>> AutoCompleteKeyword(List<string> repo, string userQuery)
        {
            List<List<string>> outputList = new List<List<string>>();

            KeywordRec(repo, userQuery, userQuery.Length, outputList);

            return outputList;
        }

        private static List<string> KeywordRec(List<string> repo, string userQuery, int subStringLength, List<List<string>> outputList, List<string> memo = null)
        {
            if (subStringLength == 2)
            {
                memo = FillWordList(repo, userQuery.Substring(0, subStringLength), subStringLength);
                outputList.Add(memo);
                return memo;
            }

            memo = KeywordRec(repo, userQuery, subStringLength - 1, outputList, memo);

            memo = FillWordList(memo, userQuery.Substring(0, subStringLength), subStringLength);
            outputList.Add(memo);

            return memo;
        }

        private static List<string> FillWordList(List<string> inputList, string querySegment, int subStringLength)
        {
            var list = new List<string>();

            foreach (var word in inputList)
            {
                if (word.Length >= subStringLength && word.Substring(0, subStringLength) == querySegment.Substring(0, subStringLength))
                {
                    list.Add(word.ToLower());
                }
            }

            list.Sort();
            return list;
        }
    }
}
