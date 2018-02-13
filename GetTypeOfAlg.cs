using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// Struct for getting type and name of algorithm from input.
    /// </summary>
    public struct GetTypeOfAlg
    {
        /// <summary>
        /// Getting type.
        /// </summary>
        /// <param name="intput elem"></param>
        /// <returns></returns>
        public Sorting SortAlg(char s)
        {
            int num = Convert.ToInt32(s-'0');
            Sorting ans = new InsertionSort();
            if (num == 1)
                ans = new InsertionSort();
            if (num == 2)
                ans = new BubbleSort();
            if (num == 3)
                ans = new QuickSort();
            if (num == 4)
                ans = new HeapSort();
            if (num == 5)
                ans = new MergeSort();
            return ans;
        }
        
        /// <summary>
        /// Getting name.
        /// </summary>
        /// <param name="input elem"></param>
        /// <returns></returns>
        public string GetName(char s)
        {
            int num = Convert.ToInt32(s - '0');
            if (num == 1)
                return "Insertion Sort ";
            if (num == 2)
                return "Bubble Sort ";
            if (num == 3)
                return "Quick Sort ";
            if (num == 4)
                return "Heap Sort ";
            if (num == 5)
                return "Merge Sort ";
            return null;
        }
    }
}
