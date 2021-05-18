using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindTheMedianOf2Arrays
{
    public static class FindTheMedian
    {
        public static double FindMedianSortedArrays(int[] array1, int[] array2)
        {
            //if (array1.Length == 0 || array2.Length == 0)
            //    return 0;

            var newList = array1.Concat(array2).ToList();
            newList.Sort();

            return FindMedian(newList);
        }

        private static double FindMedian(List<int> inputList)
        {
            double output = 0;

            if (inputList.Count % 2 == 0)
            {
                int index = inputList.Count / 2;
                output = ((double)inputList[index - 1] + (double)inputList[index]) / 2;
            }
            else
            {
                int index = inputList.Count / 2;
                output = inputList[index];
            }

            return output;
        }
    }
}
