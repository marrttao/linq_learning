namespace linq;

class Program
{
    static void Main(string[] args)
    {
        Brand[] brands = new Brand[3];
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

        IEnumerable<Brand> allBrands = brands;
        IEnumerable<Brand> BrandsInNameFood = brands
            .Where(brand => brand.name.Contains("Food"));
        IEnumerable<Brand> MarketingBrands = brands
            .Where(brand => brand.profile == "marketing");
        IEnumerable<Brand> MarketinkOrITBrands = brands
            .Where(brand => brand.profile == "marketing" || brand.profile == "IT");
        IEnumerable<Brand> BrandsEmployeesMoreThan100 = brands
            .Where(brand => brand.employees > 100);
        IEnumerable<Brand> BrandsEmployeesBetween100and300 = brands
            .Where(brand => brand.employees > 100 && brand.employees < 300);
        IEnumerable<Brand> BrandsInLondon = brands
            .Where(brand => brand.country == "London");
        IEnumerable<Brand> BrandDirectorSurnameWhite = brands
            .Where(brand => brand.Director.surname == "White");
        IEnumerable<Brand> BrandStartedMoreThan2yearsAgo = brands
            .Where(brand => (DateTime.Now.Year - brand.date.year) > 2);
        IEnumerable<Brand> BrandStarted123days = brands
            .Where(brand => (DateTime.Now - new DateTime(brand.date.year, brand.date.month, brand.date.day)).TotalDays > 123);
        IEnumerable<Brand> BrandDirectorSurnameBlackandNameofbrandIncludesBlack = brands
            .Where(brand => brand.Director.surname == "Black" && brand.name.Contains("Black"));
    }
}

public class Brand
{
    public string name { get; set; }
    public Date date { get; set; }
    public string profile { get; set; }
    public Director Director { get; set; }
    public int employees { get; set; }
    public string country { get; set; }
}

public struct Date
{
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }
}

public struct Director
{
    public string name { get; set; }
    public string surname { get; set; }
    public string patronymic { get; set; }
}