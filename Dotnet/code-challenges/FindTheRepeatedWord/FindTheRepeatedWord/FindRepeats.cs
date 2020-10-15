using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FindTheRepeatedWord
{
    public static class FindRepeats
    {
        /// <summary>
        /// This method takes a large string and finds the first repeated word.
        /// </summary>
        /// <param name="inputString">A large string</param>
        /// <returns>A single word</returns>
        public static string RepeatedWord(string inputString)
        {
            //var lower = inputString.ToLower();

            string[] words = inputString.Split(' ');
            HashSet<string> table = new HashSet<string>();
           
            foreach(var item in words)
            {

                // Regex Source: https://www.geeksforgeeks.org/removing-punctuations-given-string/
                // Moved ToLower() to prevent looping through the string a second time.
                var cleanedWord = Regex.Replace(item.ToLower(), @"[^\w\d\s]", "");
                if (table.Contains(cleanedWord))
                {
                    return item;
                }
                else
                {
                    table.Add(cleanedWord);
                }
            }
            return "There are no repeat words here";
        }
    }
}
