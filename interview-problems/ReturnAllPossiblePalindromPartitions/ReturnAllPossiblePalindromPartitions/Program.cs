﻿using System;
using System.Collections.Generic;

namespace ReturnAllPossiblePalindromPartitions
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");

        //    var input = "nitin";

        //    var listOfLists = PalindromePartitions.GeneratePalindromePartitions(input);

        //    foreach (var list in listOfLists)
        //    {
        //        foreach (var item in list)
        //        {
        //            Console.Write($"{item} ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public static void Main(String[] args)
        {
            String input = "nitin";

            Console.WriteLine("All possible palindrome" +
                                "partions for " + input
                                + " are :");

            allPalPartitions(input);
        }

        // Function to print all possible
        // palindromic partitions of str.
        // It mainly creates vectors and
        // calls allPalPartUtil()
        private static void allPalPartitions(String input)
        {
            int n = input.Length;

            // To Store all palindromic partitions
            List<List<String>> allPart = new List<List<String>>();

            // To store current palindromic partition
            List<String> currPart = new List<String>();

            // Call recursive function to generate 
            // all partiions and store in allPart
            allPalPartitonsUtil(allPart, currPart, 0, n, input);

            // Print all partitions generated by above call
            for (int i = 0; i < allPart.Count; i++)
            {
                for (int j = 0; j < allPart[i].Count; j++)
                {
                    Console.Write(allPart[i][j] + " ");
                }
                Console.WriteLine();
            }

        }

        // Recursive function to find all palindromic
        // partitions of input[start..n-1] allPart --> A
        // List of Deque of strings. Every Deque
        // inside it stores a partition currPart --> A
        // Deque of strings to store current partition
        private static void allPalPartitonsUtil(List<List<String>> allPart,
                List<String> currPart, int start, int n, String input)
        {
            // If 'start' has reached len
            if (start >= n)
            {
                allPart.Add(new List<String>(currPart));
                return;
            }

            // Pick all possible ending points for substrings
            for (int i = start; i < n; i++)
            {

                // If substring str[start..i] is palindrome
                if (isPalindrome(input, start, i))
                {

                    // Add the substring to result
                    currPart.Add(input.Substring(start, i + 1 - start));

                    // Recur for remaining remaining substring
                    allPalPartitonsUtil(allPart, currPart, i + 1, n, input);

                    // Remove substring str[start..i] from current
                    // partition
                    currPart.RemoveAt(currPart.Count - 1);
                }
            }
        }

        // A utility function to check 
        // if input is Palindrome
        private static bool isPalindrome(String input,
                                        int start, int i)
        {
            while (start < i)
            {
                if (input[start++] != input[i--])
                    return false;
            }
            return true;
        }
    }
}

