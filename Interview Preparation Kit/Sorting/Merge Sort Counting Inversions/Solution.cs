﻿using System;
using System.Diagnostics;

namespace Interview_Preparation_Kit.Sorting.Merge_Sort_Counting_Inversions
{
    internal class Solution
    {
        //// Complete the countInversions function below.
        private static long countInversions(int[] arr)
        {
            long countSwaps = 0;

            mergeSort(arr, ref countSwaps);

            return countSwaps;
        }
        private static int[] mergeSort(int[] array, ref long countSwaps)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int[] arrayLeft = new int[array.Length/2], 
                  arrayRight = new int[array.Length - (array.Length / 2)];

            Array.Copy(array, 0, arrayLeft, 0, arrayLeft.Length);
            Array.Copy(array, arrayLeft.Length, arrayRight, 0, arrayRight.Length);

            arrayLeft = mergeSort(arrayLeft, ref countSwaps);
            arrayRight = mergeSort(arrayRight, ref countSwaps);

            return merge(arrayLeft, arrayRight, ref countSwaps);
        }

        private static int[] merge(int[] arrayLeft, int[] arrayRight, ref long countSwaps)
        {
            int[] merged = new int[arrayLeft.Length + arrayRight.Length];
            int leftIndex = 0, rightIndex = 0, mergedIndex = 0;

            while (leftIndex < arrayLeft.Length && rightIndex < arrayRight.Length)
            {
                if (arrayLeft[leftIndex] > arrayRight[rightIndex])
                {
                    countSwaps += arrayLeft.Length - leftIndex;

                    merged[mergedIndex] = arrayRight[rightIndex];
                    rightIndex++;
                }
                else
                {
                    merged[mergedIndex] = arrayLeft[leftIndex];
                    leftIndex++;
                   // countSwaps++;
                }

                mergedIndex++;
            }

            if (leftIndex < arrayLeft.Length)
            {
                Array.Copy(arrayLeft, leftIndex, merged, mergedIndex, arrayLeft.Length - leftIndex);
            }
            else if (rightIndex < arrayRight.Length)
            {
                Array.Copy(arrayRight, rightIndex, merged, mergedIndex, arrayRight.Length - rightIndex);
            }

            return merged;
        }
       
        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            
            var watch = Stopwatch.StartNew();

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                long result = countInversions(arr);

                Console.WriteLine(result);
            }

            watch.Stop();

            Console.WriteLine(string.Format("Elapsed time: {0} seconds", watch.Elapsed.TotalSeconds));

            Console.ReadKey();
        }
    }
}
