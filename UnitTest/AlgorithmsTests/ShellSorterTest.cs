using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    public static class ShellSorterTest
    {
        [Fact]
        public static void ShellSortAscendingTest()
        {
            var list = new List<int>() { 0, 44, 61, 12, 33, 29, 10, 22, 42, 53, 85, 26, 34, 91 };
            list.ShellSort();

            Assert.True(list.SequenceEqual(list.OrderBy(x => x)), "Wrong ShellSort ascending");

            
        }

        [Fact]
        public static void ShellSortDescendingTest()
        {
            var list = new List<int>() { 0, 44, 61, 12, 33, 29, 10, 22, 42, 53, 85, 26, 34, 91 };

            list.ShellSortDescending(Comparer<int>.Default);
            Assert.True(list.SequenceEqual(list.OrderByDescending(x => x)), "Wrong ShellSort descending");
        }
    }
}
