using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    /// <summary>
    /// This class is made for unit testing SelectionSorter but with using a complex own type as an element
    /// </summary>
    public static class SelectionSorterTest
    {
        private static readonly Random rnd = new Random();

        [Fact]
        public static void SelectionSorterAscendingTest()
        {
            List<Person> allPersons = new List<Person>();
            for(int i=0; i<100; i++)
            {
                Person p = new Person(rnd.Next(20, 40), rnd.Next(1000, 10000), $"person {i}");
                allPersons.Add(p);
            }

            allPersons.SelectionSort(new Person(0,0,""));

            Assert.True(allPersons.SequenceEqual(allPersons.OrderBy(x => x.age*x.salary)), "Wrong ascending order!");
        }


        [Fact]
        public static void SelectionSorterDescendingTest()
        {
            List<Person> allPersons = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                Person p = new Person(rnd.Next(20, 40), rnd.Next(1000, 10000), $"person {i}");
                allPersons.Add(p);
            }

            allPersons.SelectionSortDescending(new Person(0, 0, ""));

            Assert.False(allPersons.SequenceEqual(allPersons.OrderBy(x => x.age * x.salary))); 
            Assert.True(allPersons.SequenceEqual(allPersons.OrderByDescending(x => x.age * x.salary)), "Wrong descending order!");

        }
    }

    //the complex type also impelements the Comparer interface
    public class Person : Comparer<Person>
    {
        public readonly int age;
        public readonly int salary;
        public readonly string name;

        public Person(int age, int salary, string name)
        {
            this.age = age;
            this.name = name;
            this.salary = salary;
        }
        public override int Compare(Person x, Person y)
        {
            int xPersonValue = x.age * x.salary;
            int yPersonValue = y.age * y.salary;
            if (xPersonValue == yPersonValue)
                return 0;
            return xPersonValue - yPersonValue;
        }
    }
}
