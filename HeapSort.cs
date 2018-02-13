using System.Diagnostics;

namespace SortingAlgorithms
{
    /// <summary>
    /// Heapsort.
    /// </summary>
    class HeapSort:Sorting
    {
        /// <summary>
        /// Overriding sort function from inherited abstract class Sorting.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        override public int[] Sort(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] ans = new int[arr.Length];
            for (int i = 0; i < arr.Length; ++i)
            {
                ans[i] = arr[i];
            }
            int heapSize = ans.Length;
            for (int i= (heapSize - 1) / 2; i >= 0; --i)
                Heapify(ans, i, heapSize);
            for (int i = ans.Length - 1; i > 0; i--)
            {
                Swap(ans, 0, i);
                heapSize--;
                Heapify(ans,0, heapSize);
            }
            stopwatch.Stop();
            runningTime = stopwatch.Elapsed;
            Process currentProc = Process.GetCurrentProcess();
            memory = currentProc.PrivateMemorySize64;
            return ans;
        }

        /// <summary>
        /// Putting elements in place.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <param name="heap size"></param>
        private void Heapify(int[] arr, int ind, int size)
        {
            int left = (ind + 1) * 2 - 1;
            int right = (ind + 1) * 2;
            int max = 0;
            if (left < size && arr[left] > arr[ind])
                max = left;
            else
                max = ind;

            if (right < size && arr[right] > arr[max])
                max = right;

            if (max != ind)
            {
                Swap(arr, ind, max);
                Heapify(arr, max, size);
            }
        }
    }
}

