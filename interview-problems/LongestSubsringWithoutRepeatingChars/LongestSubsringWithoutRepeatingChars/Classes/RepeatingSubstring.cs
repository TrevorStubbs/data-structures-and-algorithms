using System;
using System.Collections.Generic;
using System.Text;

namespace LongestSubsring.Classes
{
    public static class RepeatingSubstring
    {
        public static int LongestSubstringWithoutRepeats(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            List<char> charList = new List<char>();
            int counter = 0;
            int subCounter = 0;

            if (charArray.Length == 0)
            {
                return 0;
            }

            foreach (var character in charArray)
            {
                if (charList.Count == 0)
                {
                    charList.Add(character);
                    counter = 1;
                    subCounter = 1;
                }
                else
                {
                    if (charList.Contains(character))
                    {
                        if (counter < charList.Count)
                        {
                            counter = charList.Count;
                        }

                        charList.Clear();

                        charList.Add(character);
                        subCounter = 0;
                    }
                    else
                    {
                        charList.Add(character);
                        subCounter++;
                    }
                }
            }

            if (counter < charList.Count)
            {
                counter = charList.Count;
            }

            if (subCounter > counter)
            {
                return subCounter;
            }
            else
            {
                return counter;
            }

        }
    }
}
