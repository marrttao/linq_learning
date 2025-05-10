using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace tests;

[TestClass]
public class LinqTests
{
    [TestMethod]
    public void TestSortBySumOfNumberAscending()
    {
        // Arrange
        string[] numbers = { "11", "35", "78", "12", "98" };

        // Act
        var result = (from number in numbers
            where number.Length == 2
            let sum = number[0] - '0' + number[1] - '0'
            orderby sum
            select sum).ToArray();

        // Assert
        CollectionAssert.AreEqual(new[] { 2, 3, 8, 15, 17 }, result);
    }

    [TestMethod]
    public void TestSortBySumOfNumberDescending()
    {
        // Arrange
        string[] numbers = { "11", "35", "78", "12", "98" };

        // Act
        var result = (from number in numbers
            where number.Length == 2
            let sum = number[0] - '0' + number[1] - '0'
            orderby sum descending
            select sum).ToArray();

        // Assert
        CollectionAssert.AreEqual(new[] { 17, 15, 8, 3, 2 }, result);
    }
}