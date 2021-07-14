using NUnit.Framework;

namespace GenericSort.Test
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void TestPersonEquality()
        {
            Assert.AreEqual(new Person("David", 12), new Person("David", 12));
        }

        [Test]
        public void TestInvalidEqualityComparison()
        {
            Assert.AreNotEqual(new Person("David", 12), null);
            Assert.AreNotEqual(new Person("David", 12), 12);
        }
    }
}