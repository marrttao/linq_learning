using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    [TestClass]
    public sealed class LinqTests
    {
        private readonly string[] strings = { "twooo", "one", "threee" };

        [TestMethod]
        public void Test_UserSortDescending()
        {
            IEnumerable<string> expected = new[] { "threee", "twooo", "one" }; // Ordered by length descending
            IEnumerable<string> actual = from s in strings orderby s.Length descending select s;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_UserSortAscending()
        {
            IEnumerable<string> expected = new[] { "one", "twooo", "threee" }; // Ordered by length ascending
            IEnumerable<string> actual = from s in strings orderby s.Length select s;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }
    }
}