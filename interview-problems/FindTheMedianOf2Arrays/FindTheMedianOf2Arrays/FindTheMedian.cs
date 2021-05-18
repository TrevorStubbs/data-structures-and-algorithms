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
            var newArray = array1.Concat(array2).ToArray<int>();
            MergeSort(newArray);
            var med = FindMedian(newArray.ToList());

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

        private static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + (right - 1)) / 2;

                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int arrayLength1 = middle - left + 1;
            int arrayLength2 = right - middle;

            int[] leftArray = new int[arrayLength1];
            int[] rightArray = new int[arrayLength2];

            int i;


            for (i = 0; i < arrayLength1; i++)            
                leftArray[i] = array[left + i];

            for (i = 0; i < arrayLength2; i++)
                rightArray[i] = array[middle + 1 + i];

            int index = left;
            i = 0;
            int j = 0;

            while(i < arrayLength1 && j < arrayLength2)
            {
                if(leftArray[i] <= rightArray[j])
                {
                    array[index] = leftArray[i];
                    i++;
                }
                else
                {
                    array[index] = rightArray[j];
                    j++;
                }
                index++;
            }

            while(i < arrayLength1)
            {
                array[index] = leftArray[i];
                i++;
                index++;
            }

            while(j < arrayLength2)
            {
                array[index] = rightArray[j];
                j++;
                index++;
            }
        }
    }
}
