using System;
using System.Collections;

namespace GenericSort
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = {3, 2, 1};
            Console.WriteLine(String.Join(" ", intArray));
            GenericSorter.Sort<int[], int>(intArray);
            Console.WriteLine(String.Join(" ", intArray));

            string[] stringArray = {"ball", "apple", "xylophone", "cat"};
            Console.WriteLine(String.Join(" ", stringArray));
            GenericSorter.Sort<string[], string>(stringArray, GenericSorter.DESCENDING);
            Console.WriteLine(String.Join(" ", stringArray));

            Person[] personArray = {
                new Person("Violet", 14),
                new Person("Dash", 10),
                new Person("Robert", 43),
                new Person("Helen", 40),
                new Person("Jack Jack", 1)
            };
            
            PrintCollection(personArray);
            GenericSorter.Sort<Person[], Person>(personArray);
            PrintCollection(personArray);
        }

        static void PrintCollection(IList collection)
        {
            foreach (var o in collection)
            {
                Console.Write(o + ", ");
            }
            Console.Write("\n");
        }
    }
}