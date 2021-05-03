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
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(10);
            hashTable.Add(1, "főzelék");
            string value = hashTable[1];
            int length = hashTable.Count;
            Assert.Equal(1, length);
        }
        [Fact]
        public static void HashSearchTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(10);
            hashTable.Add(1, "főzelék");
            int result = hashTable.search(1);
            Assert.Equal(1, result);
        }

        [Fact]
        public static void ExpandHashSizeTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            hashTable.Add(1, "főzelék");
            hashTable.Add(2, "pörkölt");
            hashTable.Add(3, "savanyúság");
            int length = hashTable.Count;
            Assert.Equal(3, length);
        }

        [Fact]
        public static void IndexingHashTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            hashTable.Add(1, "főzelék");
            string value = hashTable[1];
            Assert.Equal("főzelék", value);
        }

        [Fact]
        public static void RemoveTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            hashTable.Add(1, "főzelék");
            hashTable.Remove(1);
            int length = hashTable.Count;
            Assert.Equal(0, length);
        }

        [Fact]
        public static void IndexElementExceptionTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            Assert.Throws<KeyNotFoundException>(() => hashTable[1] = "főzelék");
        }

        [Fact]
        public static void ClearElementsTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            hashTable.Add(1, "főzelék");
            hashTable.Add(2, "pörkölt");
            hashTable.Add(3, "savanyúság");
            hashTable.Clear();
            int length = hashTable.Count;
            Assert.Equal(0, length);
        }

        [Fact]
        public static void ContainsElementTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            hashTable.Add(1, "főzelék");
            KeyValuePair<int, string> element = new KeyValuePair<int, string>(1, "főzelék");
            bool result = hashTable.Contains(element);
            Assert.True(result);
        }

        [Fact]
        public static void TryGetValueTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            hashTable.Add(1, "főzelék");
            string value;
            bool result = hashTable.TryGetValue(1,out value);
            Assert.True(result);
        }
        [Fact]
        public static void AddElementStringKeyTest()
        {
            OpenAddressingHashTable<string, string> hashTable = new OpenAddressingHashTable<string, string>(2);
            hashTable.Add("1", "főzelék");
            hashTable.Add("2", "pörkölt");
            hashTable.Add("3", "savanyúság");
            int length = hashTable.Count;
            Assert.Equal(3, length);

        }

        [Fact]
        public static void RemoveKeyTest()
        {
            OpenAddressingHashTable<int, string> hashTable = new OpenAddressingHashTable<int, string>(2);
            hashTable.Add(1, "főzelék");
            KeyValuePair<int, string> element = new KeyValuePair<int, string>(1, "főzelék");
            hashTable.Remove(element);
            int length = hashTable.Count;
            Assert.Equal(0, length);

        }

     }
}
