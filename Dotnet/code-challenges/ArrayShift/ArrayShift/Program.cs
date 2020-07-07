using System;

namespace ArrayShift
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] providedArray1 = new int[] { 1, 4, 6, 8 };
            int providedValue1 = 5;

            int[] arrayFromMethod1 = InsertShiftArray(providedArray1, providedValue1);

            int[] providedArray2 = new int[] { 4, 8, 15, 23, 42 };
            int providedValue2 = 16;

            int[] arrayFromMethod2 = InsertShiftArray(providedArray2, providedValue2);

            Console.Write($"First Test: ");

            foreach (int number in arrayFromMethod1)
                Console.Write($"{number} ");

            Console.WriteLine();

            Console.Write($"Second Test: ");
            foreach (int number in arrayFromMethod2)
                Console.Write($"{number} ");

        }

        public static int[] InsertShiftArray(int[] inputArray, int inputValue)
        {
            int[] newArray = new int[inputArray.Length + 1];
            int middleIndex;

            middleIndex = newArray.Length / 2;
            newArray[middleIndex] = inputValue;

            for (int i = 0; i < newArray.Length; i++)
            {
                    if(i < middleIndex)
                    {
                        newArray[i] = inputArray[i];
                    }
                    else if (i > middleIndex)
                    {
                        newArray[i] = inputArray[i - 1];
                    }
            }

            return newArray;
        }
    }
}
