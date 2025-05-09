using linq;

namespace tests;

[TestClass]
public sealed class Test1
{
    private Brand[] brands;
    private readonly DateTime fixedNow = new DateTime(2025, 5, 9);

    [TestInitialize]
    public void Setup()
    {
        brands = new Brand[3];
        brands[0] = new Brand
        {
            name = "Food Company",
            date = new Date { year = 2020, month = 12, day = 23 },
            profile = "restorants",
            Director = new Director { name = "Jack", surname = "White", patronymic = "Paul" },
            employees = 105,
            country = "USA"
        };
        brands[1] = new Brand
        {
            name = "Black and White",
            date = new Date { year = 2021, month = 2, day = 2 },
            profile = "marketing",
            Director = new Director { name = "Paul", surname = "Black", patronymic = "Mike" },
            employees = 99,
            country = "London"
        };
        brands[2] = new Brand
        {
            name = "Global Logic",
            date = new Date { year = 2022, month = 3, day = 3 },
            profile = "IT",
            Director = new Director { name = "Walter", surname = "White", patronymic = "Idk" },
            employees = 400,
            country = "Ukraine"
        };
    }

    [TestMethod]
    public void TestBrandsInNameFood()
    {
        var result = brands
            .Where(brand => brand.name.Contains("Food"));

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Food Company", result.First().name);
    }

    [TestMethod]
    public void TestMarketingBrands()
    {
        var result = brands
            .Where(brand => brand.profile == "marketing");

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Black and White", result.First().name);
    }

    [TestMethod]
    public void TestMarketinkOrITBrands()
    {
        var result = brands
            .Where(brand => brand.profile == "marketing" || brand.profile == "IT");

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void TestBrandsEmployeesMoreThan100()
    {
        var result = brands
            .Where(brand => brand.employees > 100);

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void TestBrandsEmployeesBetween100and300()
    {
        var result = brands
            .Where(brand => brand.employees > 100 && brand.employees < 300);

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Food Company", result.First().name);
    }

    [TestMethod]
    public void TestBrandsInLondon()
    {
        var result = brands
            .Where(brand => brand.country == "London");

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Black and White", result.First().name);
    }

    [TestMethod]
    public void TestBrandDirectorSurnameWhite()
    {
        var result = brands
            .Where(brand => brand.Director.surname == "White");

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void TestBrandStartedMoreThan2YearsAgo()
    {
        var result = brands
            .Where(brand =>
                (fixedNow - new DateTime(brand.date.year, brand.date.month, brand.date.day)).TotalDays > 730);

        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void TestBrandStarted123DaysAgo()
    {
        var result = brands
            .Where(brand =>
                (fixedNow - new DateTime(brand.date.year, brand.date.month, brand.date.day)).TotalDays > 123);

        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void TestBrandDirectorSurnameBlackAndNameIncludesBlack()
    {
        var result = brands
            .Where(brand => brand.Director.surname == "Black" && brand.name.Contains("Black"));

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Black and White", result.First().name);
    }
}
