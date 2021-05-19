using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveDuplicatesFromSortedArray
{
    public static class SortedArrayMethods
    {
        public static int[] RemoveDuplicates(int[] inputNumbers)
        {
            var arrayLength = inputNumbers.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                if (inputNumbers[i + 1] != default)
                {
                    if (inputNumbers[i] == inputNumbers[i + 1])
                    {
                        for (int j = i + 2; j < arrayLength; j++)
                        {
                            inputNumbers[j - 1] = inputNumbers[j];

                            if (j == arrayLength-1)
                                inputNumbers[j] = default;
                        }

                        arrayLength--;
                    }
                }
            }

            return inputNumbers;
        }
    }
}
