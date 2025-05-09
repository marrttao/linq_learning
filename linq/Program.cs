namespace linq;

class Program
{
    static void Main(string[] args)
    {
        // array of brands
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
        IEnumerable<Brand> BrandsInNameFood =
            from brand in brands
            where brand.name.Contains("Food")
            select brand;
        IEnumerable<Brand> MarketingBrands =
            from brand in brands
            where brand.profile == "marketing"
            select brand;
        IEnumerable<Brand> MarketinkOrITBrands =
            from brand in brands
            where brand.profile == "marketing" || brand.profile == "IT"
            select brand;
        IEnumerable<Brand> BrandsEmployeesMoreThan100 =
            from brand in brands
            where brand.employees > 100
            select brand;
        IEnumerable<Brand> BrandsEmployeesBetween100and300 =
            from brand in brands
            where brand.employees > 100 && brand.employees < 300
            select brand;
        IEnumerable<Brand> BrandsInLondon = 
            from brand in brands
            where brand.country == "London"
            select brand;
        IEnumerable<Brand> BrandDirectorSurnameWhite =
            from brand in brands
            where brand.Director.surname == "White"
            select brand;
        IEnumerable<Brand> BrandStartedMoreThan2yearsAgo =
            from brand in brands
            where (DateTime.Now.Year - brand.date.year) > 2
            select brand;
        IEnumerable<Brand> BrandStarted123days =
            from brand in brands
            where (DateTime.Now - new DateTime(brand.date.year, brand.date.month, brand.date.day)).TotalDays > 123
            select brand;
        IEnumerable<Brand> BrandDirectorSurnameBlackandNameofbrandIncludesBlack =
            from brand in brands
            where brand.Director.surname == "Black" && brand.name.Contains("Black")
            select brand;
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