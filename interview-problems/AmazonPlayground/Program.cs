using System;
using System.Collections.Generic;
using System.Linq;

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

            var list = new List<string>();

            if (list.Any())
              
            Console.WriteLine(words.Contains(word));

        }
    }
}
