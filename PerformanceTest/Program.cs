using System;
using System.Collections.Generic;
using System.Diagnostics;
using Algorithms.Sorting; 

namespace PerformanceTest
{
    class Program
    {
        static List<int> list = new List<int>();
        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < 3000000; i++)
                list.Add(rnd.Next());

            TestAlgorithm("heap", list => list.HeapSort());
            TestAlgorithm("merge", list => list.MergeSort());
            TestAlgorithm("quick", list => list.QuickSort());
            TestAlgorithm("sort", list => list.Sort());

            Console.ReadKey();
        }

        public static void TestAlgorithm(string name, Action<List<int>> sortFunction)
        {
            List<int> clonedList = new List<int>(list);
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortFunction(clonedList);
            stopwatch.Stop();
            Console.WriteLine(name + " time: " + stopwatch.Elapsed);
        }
    }
}
