using System;
using SortingAlgorithms;

/// <summary>
/// Program.
/// </summary>
class Program
{
    /// <summary>
    /// Main function.
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Please enter the size of an array that you want to sort:");
        ///Reading size from console.
        
        string s = Console.ReadLine();
        int size = Convert.ToInt32(s);
        int[] arr = new int[size];
        Random r = new Random();
        
        ///Generating array from random numbers;
        for (int i = 0; i < size; ++i)
            arr[i] = r.Next(1,100);

        Console.WriteLine();
        Console.WriteLine("Select which algorithm you want to perform:");
        Console.WriteLine("1. Insertion sort");
        Console.WriteLine("2. Bubble sort");
        Console.WriteLine("3. Quick sort");
        Console.WriteLine("4. Heap sort");
        Console.WriteLine("5. Merge sort");
        Console.WriteLine("6. All");

        ///Reading algorithms the user chose.
        string chosenAlg = Console.ReadLine();
        GetTypeOfAlg getTypeOfAlg;

        ///Creating arrays for name, memory usage and running time of alggorithm.    
        Tuple<string, long>[] nameAndMemory=new Tuple<string, long>[1];
        TimeSpan[] time=new TimeSpan[1];

        ///Case user chose only one algorithm.
        if (chosenAlg.Length == 1 && chosenAlg[0] != '6')
        {
            Sorting alg = getTypeOfAlg.SortAlg(chosenAlg[0]);
            alg.Sort(arr);
            Console.WriteLine(getTypeOfAlg.GetName(chosenAlg[0]));
            Console.WriteLine();
            Console.WriteLine("Running Time: " + alg.RunningTime);
            Console.WriteLine("Memory usage: " + alg.MemoryCounter);
            return;
        }

        ///Case user chose all algorithms.
        if (chosenAlg.Length == 1 && chosenAlg[0] == '6')
            chosenAlg = "1-5";

        ///Case user chose algorithm in format a-b.
        if (chosenAlg[1] == '-')
        {
            nameAndMemory = new Tuple<string, long>[(Convert.ToInt32(chosenAlg[chosenAlg.Length - 1]) - '0') - (Convert.ToInt32(chosenAlg[0]) - '0') + 1];
            time = new TimeSpan[(Convert.ToInt32(chosenAlg[chosenAlg.Length - 1]) - '0') - (Convert.ToInt32(chosenAlg[0]) - '0') + 1];
            int ind = Convert.ToInt32(chosenAlg[0]) - '0';
            for (int i = 0; i < time.Length; ++i)
            {
                Sorting alg = getTypeOfAlg.SortAlg(Convert.ToChar(ind + '0'));
                alg.Sort(arr);
                nameAndMemory[i] = Tuple.Create(getTypeOfAlg.GetName(Convert.ToChar(ind + '0')), alg.MemoryCounter);
                time[i] = alg.RunningTime;
                ind++;
            }
        }

        ///Case user algorithm in format a, b, c...
        if (chosenAlg[1] == ',')
        {
            var charsToRemove = new string[] { " ", "," };
            foreach (var i in charsToRemove)
            {
                chosenAlg = chosenAlg.Replace(i, string.Empty);
            }
            nameAndMemory = new Tuple<string, long>[chosenAlg.Length];
            time = new TimeSpan[chosenAlg.Length];
            for (int i = 0; i < time.Length; ++i)
            {
                Sorting alg = getTypeOfAlg.SortAlg(chosenAlg[i]);
                alg.Sort(arr);
                nameAndMemory[i] = Tuple.Create(getTypeOfAlg.GetName(chosenAlg[i]), alg.MemoryCounter);
                time[i] = alg.RunningTime;
            }
        }

        ///finding min running time
        int minInd = 0;
        TimeSpan minEl = time[0];
        for (int i = 1; i < time.Length; ++i)
        {
            if (time[i] < minEl)
            {
                minInd = i;
                minEl = time[i];
            }
        }

        ///output
        for (int i = 0; i < time.Length; ++i)
        {
            Console.WriteLine();
            Console.WriteLine(nameAndMemory[i].Item1);
            Console.Write("Running Time: ");
            if (i == minInd)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(time[i]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Memory Usage: " + nameAndMemory[i].Item2);
            Console.WriteLine();
        }
    }
}
