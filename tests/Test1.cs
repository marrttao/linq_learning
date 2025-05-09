using linq;

namespace tests;

[TestClass]
public sealed class Test1
{
    private Brand[] brands;
    private readonly DateTime fixedNow = new DateTime(2025, 5, 9); // Фиксированная дата

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
        var result = from brand in brands
                     where brand.name.Contains("Food")
                     select brand;

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Food Company", result.First().name);
    }

    [TestMethod]
    public void TestMarketingBrands()
    {
        var result = from brand in brands
                     where brand.profile == "marketing"
                     select brand;

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Black and White", result.First().name);
    }

    [TestMethod]
    public void TestMarketinkOrITBrands()
    {
        var result = from brand in brands
                     where brand.profile == "marketing" || brand.profile == "IT"
                     select brand;

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void TestBrandsEmployeesMoreThan100()
    {
        var result = from brand in brands
                     where brand.employees > 100
                     select brand;

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void TestBrandsEmployeesBetween100and300()
    {
        var result = from brand in brands
                     where brand.employees > 100 && brand.employees < 300
                     select brand;

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Food Company", result.First().name);
    }

    [TestMethod]
    public void TestBrandsInLondon()
    {
        var result = from brand in brands
                     where brand.country == "London"
                     select brand;

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Black and White", result.First().name);
    }

    [TestMethod]
    public void TestBrandDirectorSurnameWhite()
    {
        var result = from brand in brands
                     where brand.Director.surname == "White"
                     select brand;

        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void TestBrandStartedMoreThan2YearsAgo()
    {
        var result = from brand in brands
            where (fixedNow - new DateTime(brand.date.year, brand.date.month, brand.date.day)).TotalDays > 730
            select brand;

        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void TestBrandStarted123DaysAgo()
    {
        var result = from brand in brands
            where (fixedNow - new DateTime(brand.date.year, brand.date.month, brand.date.day)).TotalDays > 123
            select brand;

        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void TestBrandDirectorSurnameBlackAndNameIncludesBlack()
    {
        var result = from brand in brands
                     where brand.Director.surname == "Black" && brand.name.Contains("Black")
                     select brand;

        Assert.AreEqual(1, result.Count());
        Assert.AreEqual("Black and White", result.First().name);
    }
}
