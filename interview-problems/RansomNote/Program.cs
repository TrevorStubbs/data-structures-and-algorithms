using System;
using System.Collections.Generic;

namespace RansomNote
{
    class Program
    {
        static void Main(string[] args)
        {
            var mag = new List<string>() { "give", "me", "one", "grand", "today", "night" };
            var note = new List<string>() { "give", "one", "grand", "today" };

            var canNote = RansomNote.CanMakeNote(mag, note);

            Console.WriteLine($"Can Note? {canNote}");

            var mag2 = new List<string>() { "two", "times", "three", "is", "not", "four" };
            var note2 = new List<string>() { "two", "times", "two", "is", "four" };

            var canNote2 = RansomNote.CanMakeNote(mag2, note2);

            Console.WriteLine($"Can Note? {canNote2}");

        }

        public static class RansomNote
        {
            // Space: O(n)
            // Space: O(n)
            public static string CanMakeNote(List<string> magazine, List<string> note)
            {
                Dictionary<string, int> magWords = new Dictionary<string, int>();

                foreach (var word in magazine)
                {
                    if (magWords.ContainsKey(word))
                        magWords[word]++;
                    else
                        magWords.Add(word, 1);
                }

                foreach (var word in note)
                {
                    if (magWords.ContainsKey(word))
                    {
                        magWords[word]--;
                    }
                    else
                        return "No";
                }

                foreach (var word in note)
                {
                    if (magWords[word] != 0)
                        return "No";
                }

                return "Yes";
            }
        }
        
    }
}
