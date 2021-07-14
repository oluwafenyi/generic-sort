#nullable enable
using System;

namespace GenericSort
{
    /// <summary>
    /// Test class to show the importance of generics. This class implements the System.IComparable interface
    /// </summary>
    public class Person: IComparable
    {
        /// <summary>
        /// Identifier for Person object
        /// </summary>
        /// <value>person's name</value>
        public string Name { get; set; }
        
        /// <summary>
        /// Value for comparison
        /// </summary>
        /// <value>person's age >= 0</value>
        public uint Age { get; set; }

        
        /// <summary>
        /// Constructor to instantiate a new Person object
        /// </summary>
        /// <param name="name">person's name</param>
        /// <param name="age">person's age</param>
        public Person(string name, uint age)
        {
            Name = name;
            Age = age;
        }

        /// <summary>
        /// Overrides default method
        /// </summary>
        /// <returns>Person.Name</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Base implementation of GetHashCode
        /// </summary>
        /// <returns>hash code value</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Overrides base.Equals() method
        /// </summary>
        /// <param name="obj">object for equality comparison</param>
        /// <returns>true if <paramref name="obj"/> is a Person object and has the same name and age as this instance, false otherwise</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Person)) return false;

            Person otherPerson = (Person) obj;
            return otherPerson.Name == Name && otherPerson.Age == Age;
        }

        /// <summary>
        /// Implements the System.IComparable interface to enable comparison by the GenericSorter algorithm
        /// </summary>
        /// <param name="other">other object to compare this instance to</param>
        /// <returns>0 if other.Age eq this.Age;
        /// -1 if this.Age lt other.Age;
        /// 1 if this.Age gt other.Age</returns>
        /// <exception cref="ArgumentException">Exception raised when <paramref name="other"/> is null or not an instance of Person</exception>
        public int CompareTo(object? other)
        {
            if (other == null)
            {
                throw new ArgumentException("cannot compare Person to null");
            }

            if (other.GetType() != typeof(Person))
            {
                throw new ArgumentException("cannot compare Person to " + other.GetType());
            }

            Person otherPerson = (Person) other;
            if (Age == otherPerson.Age) return 0;
            if (Age < otherPerson.Age) return -1;
            return 1;
        }
    }
}