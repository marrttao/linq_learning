using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    [TestClass]
    public sealed class LinqTests
    {
        private readonly string[] Towns = { "Amsterdam", "Stockholm", "New York", "Neenah" };

        [TestMethod]
        public void Test_AllTowns()
        {
            IEnumerable<string> expected = Towns;
            IEnumerable<string> actual = from Town in Towns select Town;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StartsWithA()
        {
            IEnumerable<string> expected = new[] { "Amsterdam" };
            IEnumerable<string> actual = from Town in Towns where Town.StartsWith("A") select Town;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_EndsWithM()
        {
            IEnumerable<string> expected = new[] { "Amsterdam", "Stockholm" };
            IEnumerable<string> actual = from Town in Towns where Town.EndsWith("m") select Town;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StartsWithNAndEndsWithK()
        {
            IEnumerable<string> expected = new[] { "New York" };
            IEnumerable<string> actual = from Town in Towns where Town.StartsWith("N") && Town.EndsWith("k") select Town;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StartsWithNe()
        {
            IEnumerable<string> expected = new[] { "New York", "Neenah" }; // Ordered descending
            IEnumerable<string> actual = (from Town in Towns where Town.StartsWith("Ne") orderby Town descending select Town);

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_LengthOfName()
        {
            int n = 6; // Example length
            IEnumerable<string> expected = new[] { "Neenah" };
            IEnumerable<string> actual = from Town in Towns where Town.Length == n select Town;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }
    }
}