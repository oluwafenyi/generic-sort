using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace GenericSort.Test
{
    public class GenericSorterTests
    {
        [Test]
        public void TestIntArraySort()
        {
            int[] arrayInt = {5, 2, 3, 1, 6, 8, 4};
            GenericSorter.Sort<int[], int>(arrayInt);
            CollectionAssert.AreEqual(arrayInt, new int[] {1, 2, 3, 4, 5, 6, 8});
        }

        [Test]
        public void TestIntArraySortDescending()
        {
            int[] arrayInt = {5, 2, 3, 1, 6, 8, 4};
            GenericSorter.Sort<int[], int>(arrayInt, GenericSorter.DESCENDING);
            CollectionAssert.AreEqual(arrayInt, new int[] {8, 6, 5, 4, 3, 2, 1});
        }
        
        [Test]
        public void TestStringArraySort()
        {
            string[] arrayString = {"Cat", "Bag", "Apple"};
            GenericSorter.Sort<string[], string>(arrayString);
            CollectionAssert.AreEqual(arrayString, new[] {"Apple", "Bag", "Cat"});
        }

        [Test]
        public void TestStringArraySortDescending()
        {           
            string[] arrayString = {"Cat", "Bag", "Apple"};
            GenericSorter.Sort<string[], string>(arrayString, GenericSorter.DESCENDING);
            CollectionAssert.AreEqual(arrayString, new[] {"Cat", "Bag", "Apple"});
        }

        [Test]
        public void TestInvalidOrderParamThrowsException()
        {
            string[] arrayString = {"Cat", "Bag", "Apple"};
            Assert.Throws<ArgumentException>(delegate
            {
                GenericSorter.Sort<string[], string>(arrayString, 'B');
            });
        }

        [Test]
        public void TestComparableObjectSort()
        {
            Person[] people = new[] {
                new Person("Violet", 14),
                new Person("Dash", 10),
                new Person("Robert", 43),
                new Person("Helen", 40),
                new Person("Jack Jack", 1)
            };
            GenericSorter.Sort<Person[], Person>(people);
            CollectionAssert.AreEqual(people, new Person[]
            {
                new Person("Jack Jack", 1),
                new Person("Dash", 10),
                new Person("Violet", 14),
                new Person("Helen", 40),
                new Person("Robert", 43)
            });
        }

        [Test]
        public void TestListSort()
        {
            List<int> list = new List<int> {2, 4, 1, 5, 6};
            GenericSorter.Sort<List<int>, int>(list);
            CollectionAssert.AreEqual(list, new List<int>{1, 2, 4, 5, 6});
        }
    }
}