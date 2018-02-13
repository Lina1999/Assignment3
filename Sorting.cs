using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// Abstract class Sorting.
    /// </summary>
    abstract public class Sorting : System.Exception
    {
        /// <summary>
        /// memory usage
        /// </summary>
        protected long memory;

       /// <summary>
       /// running time
       /// </summary>
        protected TimeSpan runningTime;

        /// <summary>
        /// Abstract function for sorting given arry of integers.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        abstract public int[] Sort(int[] arr);
        
        /// <summary>
        /// Getter for memory usage.
        /// </summary>
        public long MemoryCounter
        {
            get
            {
                return memory;
            }
        }

        /// <summary>
        /// Getter for running time.
        /// </summary>
        public TimeSpan RunningTime
        {
            get
            {
                return runningTime;
            }
        }

        /// <summary>
        /// Function for swapping two integers of array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        protected void Swap(int[] arr, int ind1, int ind2)
        {
            int temp = arr[ind2];
            arr[ind2] = arr[ind1];
            arr[ind1] = temp;
        }

    }
}