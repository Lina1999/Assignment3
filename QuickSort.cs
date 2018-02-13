using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    /// <summary>
    /// Quicksort. 
    /// </summary>
    class QuickSort : Sorting
    {
        /// <summary>
        /// Overriding sort function from inherited abstract class Sorting.
        /// </summary>
        override public int[] Sort(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] ans = new int[arr.Length];
            for (int i = 0; i < arr.Length; ++i)
            {
                ans[i] = arr[i];
            }
            quickSort(ans, 0, arr.Length - 1);
            DateTime now = DateTime.Now;
            runningTime= stopwatch.Elapsed;
            Process currentProc = Process.GetCurrentProcess();
            memory = currentProc.PrivateMemorySize64;
            return ans;
        }

        /// <summary>
        /// Sorting recursively.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private  void quickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int piv = Partition(arr, left, right);
                quickSort(arr, left, piv - 1);
                quickSort(arr, piv + 1, right);
            }
        }

        /// <summary>
        /// Partition.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int pivInd = left;
            for(int i=left; i<right; i++)
            {
                if (arr[i] <= pivot)
                {
                    Swap(arr, i, pivInd);
                    pivInd++;
                }
            }
            Swap(arr, right, pivInd);
            return pivInd;
        }
    }
}