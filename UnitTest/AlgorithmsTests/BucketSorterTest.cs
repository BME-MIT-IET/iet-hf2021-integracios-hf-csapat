using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    public static class BucketSorterTest
    {
        [Fact]
        public static void BucketSorterAscendingTest()
        {
            var list = new List<int>() { 0, 44, 61, 12, 33, 29, 10, 22, 42, 53, 85, 26, 34, 91 };
            list.BucketSort();

            Assert.True(list.SequenceEqual(list.OrderBy(x => x)), "Wrong BucketSort ascending");


        }

        [Fact]
        public static void BucketSorterDescendingTest()
        {
            var list = new List<int>() { 0, 44, 61, 12, 33, 29, 10, 22, 42, 53, 85, 26, 34, 91 };

            list.BucketSortDescending();
            Assert.True(list.SequenceEqual(list.OrderByDescending(x => x)), "Wrong BucketSort descending");
        }
    }
}
