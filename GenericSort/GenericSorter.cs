using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSort
{
    /// <summary>
    /// GenericSorter is a static class that encapsulates the generic sort method which
    /// implements insertion sort to sort through any object that implements the System.Collections.Generic.IList
    /// interface where the elements in the IList container implement the System.IComparable interface.
    /// </summary>
    
    public static class GenericSorter
    {
        /// <summary>
        /// The ASCENDING field provides the user with a reference for ascending order option while calling the .Sort() method.
        /// </summary>
        /// <value>the char value: 'A'</value>
        public static char ASCENDING = 'A';
        /// <summary>
        /// The DESCENDING field provides the user with a reference for descending order option while calling the .Sort() method.
        /// </summary>
        /// <value>the char value: 'D'</value>
        public static char DESCENDING = 'D';

        // internal sorting method
        private static void sort<TList, TItem>(TList collection, char order) where TList : IList<TItem> where TItem : IComparable
        {
            if (!new [] {ASCENDING, DESCENDING}.Contains(order))
            {
                throw new ArgumentException($"{order} is not a valid sort order, use GenericSorter.ASCENDING or GenericSorter.DESCENDING");
            }
            
            if (collection.Count <= 1)
            {
                return;
            }

            for (int i = 1; i < collection.Count; i++)
            {
                TItem key = collection[i];
                int j = i - 1;

                // local function to evaluate the correct position of collection[i] based on the specified order
                bool comp(int index) => order == ASCENDING
                    ? collection[index].CompareTo(key) > 0
                    : collection[index].CompareTo(key) < 0;
                
                while (j >= 0 && comp(j))
                {
                    collection[j + 1] = collection[j];
                    j--;
                }

                collection[j + 1] = key;
            }
        }
        
        /// <summary>
        /// Generic static sort method, sorts in ascending order and in place.
        /// </summary>
        /// <param name="collection">An instance of a class that implements the System.Collections.Generic.IList interface</param>
        /// <typeparam name="TList">A class that implements the System.Collections.Generic.IList interface</typeparam>
        /// <typeparam name="TItem">The class of elements in the TList, this class must implement the System.IComparable interface</typeparam>
        public static void Sort<TList, TItem>(TList collection) where TList: IList<TItem> where TItem: IComparable
        {
            sort<TList, TItem>(collection, ASCENDING);
        }

        /// <summary>
        /// Generic static sort method with order specification, sorts in place.
        /// </summary>
        /// <param name="collection">An instance of a class that implements the System.Collections.Generic.IList interface</param>
        /// <param name="order">Either GenericSorter.ASCENDING or GenericSorter.DESCENDING to specify the sort order</param>
        /// <typeparam name="TList">A class that implements the System.Collections.Generic.IList interface</typeparam>
        /// <typeparam name="TItem">The class of elements in the TList, this class must implement the System.IComparable interface</typeparam>
        /// <exception cref="ArgumentException">Exception raised when order is neither GenericSorter.ASCENDING not GenericSorter.DESCENDING</exception>
        public static void Sort<TList, TItem>(TList collection, char order)
            where TList : IList<TItem> where TItem : IComparable
        {
            sort<TList, TItem>(collection, order);
        }
    }
}