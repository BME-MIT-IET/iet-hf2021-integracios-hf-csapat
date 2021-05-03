using DataStructures.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.DataStructuresTests
{
    public static class OpenAddressingHashTableTest
    {
        [Fact]
        public static void AddValueToHashTableTest()
        {
            OpenAddressingHashTable<int,string> hashTable = new OpenAddressingHashTable<int, string>(10);
            hashTable.Add(1, "főzelék");
            int length = hashTable.Count;
            Assert.Equal(1,length);
        }
        [Fact]
        public static void AddValueToHashTableTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(10);
            hashTable.Add(1, "főzelék");
            int result = hashTable.search(1);
            
            Assert.Equal(1, length);
        }
    }
}
