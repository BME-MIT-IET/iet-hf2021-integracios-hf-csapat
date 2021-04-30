using DataStructures.Hashing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.DataStructuresTests
{
    
    public static class PrimeHashingFamilyTest
    {
        [Fact]
        public static void CheckHashIdenticalInt()
        {
            PrimeHashingFamily hash1 = new PrimeHashingFamily(1);
            PrimeHashingFamily hash2 = new PrimeHashingFamily(1);
            int hashValue = "főzelék".GetHashCode();

            for (int i = 1; i < hash1.NumberOfFunctions; i++)
            {
                hash1 = new PrimeHashingFamily(i);
                hash2 = new PrimeHashingFamily(i);
                int result1 = hash1.Hash(hashValue, i);
                int result2 = hash2.Hash(hashValue, i);
                Assert.Equal(result1, result2);
            } 
        }
        [Fact]
        public static void CheckInvalidHashConstruction()
        {
            PrimeHashingFamily hashFamily;

            Assert.Throws<ArgumentOutOfRangeException>(() => hashFamily = new PrimeHashingFamily(0));
            
        }

        [Fact]
        public static void CheckInvalidHashFunction()
        {
            int hashValue = "főzelék".GetHashCode();

            PrimeHashingFamily hashFamily = new PrimeHashingFamily(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => hashFamily.Hash(hashValue,0));

        }

        [Fact]
        public static void CheckHashIdenticalString()
        {
            PrimeHashingFamily hash1 = new PrimeHashingFamily(10);
            PrimeHashingFamily hash2 = new PrimeHashingFamily(10);
            string hashValue = "főzelék";

            for (int i = 1; i < hash1.NumberOfFunctions; i++)
            {
                hash1 = new PrimeHashingFamily(i);
                hash2 = new PrimeHashingFamily(i);
                int result1 = hash1.Hash(hashValue, i);
                int result2 = hash2.Hash(hashValue, i);
                Assert.Equal(result1, result2);
            }
        }

        [Fact]
        public static void CheckInvalidHashFunctionString()
        {
            string hashValue = null;

            PrimeHashingFamily hashFamily = new PrimeHashingFamily(1);

            Assert.Throws<ArgumentException>(() => hashFamily.Hash(hashValue, 1));

        }
    }
}
