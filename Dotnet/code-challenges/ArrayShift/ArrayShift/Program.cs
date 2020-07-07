using System;

namespace ArrayShift
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int[] InsertShiftArray(int[] inputArray, int inputValue)
        {
            int[] newArray = new int[inputArray.Length + 1];

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i == newArray.Length - 1)
                    newArray[i] = inputValue;
                else
                    newArray[i] = inputArray[i];
            }

            return newArray;
        }
    }
}
