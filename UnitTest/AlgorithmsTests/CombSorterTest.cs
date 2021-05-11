using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    public static class CombSorterTest
    {
        [Fact]
        public static void CombSorterAscendingTest()
        {
            var list = new List<int>() { 0, 44, 61, 12, 33, 29, 10, 22, 42, 53, 85, 26, 34, 91 };
            list.CombSort();

            Assert.True(list.SequenceEqual(list.OrderBy(x => x)), "Wrong CombSort ascending");


        }

        [Fact]
        public static void CombSortDescendingTest()
        {
            var list = new List<int>() { 0, 44, 61, 12, 33, 29, 10, 22, 42, 53, 85, 26, 34, 91 };

            list.CombSortDescending(Comparer<int>.Default);
            Assert.True(list.SequenceEqual(list.OrderByDescending(x => x)), "Wrong CombSort descending");
        }
    }
}
