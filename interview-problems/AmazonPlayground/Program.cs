using System;

namespace AmazonPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string word = "bag";
            string words = "baggage";

            Console.WriteLine(word[2]);

            var split = word.Split(word[2]);
            Console.WriteLine(split[0]);

              
            Console.WriteLine(words.Contains(word));

        }
    }
}
