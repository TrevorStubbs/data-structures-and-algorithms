using System;

namespace LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string s = "abgeba";

            var longestPal = LongestPalindromicSub(s);

            Console.WriteLine(longestPal);
        }

        public static string LongestPalindromicSub(string input)
        {
            // Edge cases
            if (input.Length == 1)
                return input;

            if (IsPalindrom(input))
                return input;

            if (input.Length == 2)
                return input[0].ToString();

            if (input.Length == 3)
            {
                if (IsPalindrom(input.Substring(0, 2)))
                    return input.Substring(0, 2);

                if (IsPalindrom(input.Substring(1)))
                    return input.Substring(1);

                return input[0].ToString();
            }

            var longestPal = LongestPalindromicSub(input, 0, input.Length);

            return longestPal;
        }

        public static string LongestPalindromicSub(string input, int left, int right, string longest = null)
        {
            if (Math.Abs(left - right) <= 2)
            {
                longest = IfPalReturnIt(input, left, right);
                return longest;
            }

            //if (Math.Abs(left - right) == input.Length - 1)
            //{
            //    if (right == input.Length)
            //    {
            //        left++;
            //    }
            //    else if (left == 1)
            //        right--;
            //}

            longest = LongestPalindromicSub(input, left, right - 1, longest);
            longest = LongestPalindromicSub(input, left + 1, right, longest);

            if (left != 0 && right != input.Length)
            {
                var pal = IfPalReturnIt(input, left, right);

                if (pal != null && longest != null)
                {
                    if (pal.Length > longest.Length)
                        longest = pal;
                }
            }

            return longest;
        }

        private static string IfPalReturnIt(string input, int left, int right)
        {
            if (right == input.Length)
            {
                var subs = input.Substring(left);
                if (IsPalindrom(subs))
                    return subs;
            }
            else
            {
                var length = Math.Abs(left - right);
                var sub = input.Substring(left, length);
                if (IsPalindrom(sub))
                    return sub;
            }
            return null;
        }

        private static bool IsPalindrom(string input)
        {
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            var revStr = new string(charArray);

            if (input == revStr)
                return true;

            return false;
        }


    }
}
