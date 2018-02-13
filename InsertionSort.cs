using System.Diagnostics;

namespace SortingAlgorithms
{
    /// <summary>
    /// Insertion sort.
    /// </summary>
    class InsertionSort:Sorting
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
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (ans[j - 1] > ans[j])
                        Swap(ans, j - 1, j);
                    j--;
                }
            }
            stopwatch.Stop();
            Process currentProc = Process.GetCurrentProcess();
            memory = currentProc.PrivateMemorySize64;
            runningTime = stopwatch.Elapsed;
            return ans;
        }
    }
}
