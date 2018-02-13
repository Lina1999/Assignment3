using System.Diagnostics;

namespace SortingAlgorithms
{
    /// <summary>
    /// Merge sort.
    /// </summary>
    class MergeSort:Sorting
    {
        /// <summary>
        /// Overriding sort function from inherited abstract class Sorting.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public override int[] Sort(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] ans = new int[arr.Length];
            for (int i = 0; i < arr.Length; ++i)
                ans[i] = arr[i];
            mergeSort(ans, 0, arr.Length - 1);
            stopwatch.Stop();
            Process currentProc = Process.GetCurrentProcess();
            memory = currentProc.PrivateMemorySize64;
            runningTime = stopwatch.Elapsed;
            return ans;
        }

        /// <summary>
        /// Recursively sorting array from start to end.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void mergeSort(int[] arr, int start, int end)
        {
            if (end - start > 0)
            {
                int mid = (end + start) / 2;
                mergeSort(arr, start, mid);
                mergeSort(arr, mid + 1, end);
                Merge(arr, start, mid, end);
            }
        }

        /// <summary>
        /// Merging
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="middle"></param>
        /// <param name="end"></param>
        private void Merge(int[] arr, int start, int mid, int end)
        {
            int[] temp = new int[end - start + 1];
            int i = start;
            int j = mid + 1;
            int ind = 0;
            while (i <= mid && j <= end)
            {
                if (arr[i] < arr[j])
                    temp[ind++] = arr[i++];
                else
                    temp[ind++] = arr[j++];
            }
            if (i > mid)
            {
                while (j <= end)
                    temp[ind++] = arr[j++];
            }
            else
            {
                while (i <= mid)
                    temp[ind++] = arr[i++];
            }
            for (int k = start; k <= end; ++k)
                arr[k] = temp[k - start];
        }
    }
}
