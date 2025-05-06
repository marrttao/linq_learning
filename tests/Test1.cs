using linq;

namespace tests;

[TestClass]
public sealed class Test1
{
    
    [TestMethod]
    public void TestAllNumbers()
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        // Act
        var allNumbers = from number in numbers
                         select number;

        // Assert
        CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, allNumbers.ToArray());
    }
    
    [TestMethod]
    public void TestPairNumbers()
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        // Act
        var pairNumbers = from number in numbers
                          where number % 2 == 0
                          select number;

        // Assert
        CollectionAssert.AreEqual(new[] { 2, 4, 6 }, pairNumbers.ToArray());
    }

    [TestMethod]
    public void TestNonPairNumbers()
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        // Act
        var nonPairNumbers = from number in numbers
                             where number % 2 != 0
                             select number;

        // Assert
        CollectionAssert.AreEqual(new[] { 1, 3, 5 }, nonPairNumbers.ToArray());
    }

    [TestMethod]
    public void TestBiggerThanN()
    {
        // Arrange
        int[] numbers = { 10, 20, 30, 40, 50 };
        int n = 25;

        // Act
        var biggerThanN = from number in numbers
                          where number > n
                          select number;

        // Assert
        CollectionAssert.AreEqual(new[] { 30, 40, 50 }, biggerThanN.ToArray());
    }

    [TestMethod]
    public void TestInRange()
    {
        // Arrange
        int[] numbers = { 5, 10, 15, 20, 25, 30 };
        int a = 10, b = 25;

        // Act
        var inRange = from number in numbers
                      where number >= a && number <= b
                      select number;

        // Assert
        CollectionAssert.AreEqual(new[] { 10, 15, 20, 25 }, inRange.ToArray());
    }

    [TestMethod]
    public void TestMultiplies7()
    {
        // Arrange
        int[] numbers = { 7, 14, 21, 28, 35, 42 };

        // Act
        var multiplies7 = from number in numbers
                          where number % 7 == 0
                          orderby number
                          select number;

        // Assert
        CollectionAssert.AreEqual(new[] { 7, 14, 21, 28, 35, 42 }, multiplies7.ToArray());
    }

    [TestMethod]
    public void TestMultiplies8()
    {
        // Arrange
        int[] numbers = { 8, 16, 24, 32, 40 };

        // Act
        var multiplies8 = from number in numbers
                          where number % 8 == 0
                          orderby number descending
                          select number;

        // Assert
        CollectionAssert.AreEqual(new[] { 40, 32, 24, 16, 8 }, multiplies8.ToArray());
    }
}