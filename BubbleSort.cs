using System.Diagnostics;

namespace SortingAlgorithms
{
    /// <summary>
    /// Bubble sort.
    /// </summary>
    class BubbleSort:Sorting
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
            bool isSorted = true;
            while (isSorted)
            {
                isSorted = false;
                for (int i = 0; i < ans.Length - 1; ++i)
                {
                    if (ans[i] > ans[i + 1])
                    {
                        Swap(ans, i, i + 1);
                        isSorted = true;
                    }
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
