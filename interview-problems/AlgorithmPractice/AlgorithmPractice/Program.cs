using System;
using System.Collections.Generic;

namespace AlgorithmPractice
{
    class Program
    {


        static void Main(string[] args)
        {


            Console.WriteLine("Hello World!");

            //Console.WriteLine(GridTravel.GridTraveler(1, 1));
            //Console.WriteLine(GridTravel.GridTraveler(2, 3));
            //Console.WriteLine(GridTravel.GridTraveler(3, 2));
            //Console.WriteLine(GridTravel.GridTraveler(3, 3));
            //Console.WriteLine(GridTravel.GridTraveler(10, 10));
            //Console.WriteLine(GridTravel.GridTraveler(12, 12));
            //Console.WriteLine(GridTravel.GridTraveler(14, 14));
            //Console.WriteLine(GridTravel.GridTraveler(16, 16));


            //Console.WriteLine(GridTravel.GridTraveler(18, 18));

            Console.WriteLine(CanSum.CanSumArray(7, new int[] { 2, 3 }));
            Console.WriteLine(CanSum.CanSumArray(7, new int[] { 5, 3, 5, 7 }));
            Console.WriteLine(CanSum.CanSumArray(7, new int[] { 2, 4 }));
            Console.WriteLine(CanSum.CanSumArray(7, new int[] { 2, 3, 5 }));
            Console.WriteLine(CanSum.CanSumArray(300, new int[] { 7, 14 }));
        }
    }
}
