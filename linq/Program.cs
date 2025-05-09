﻿using System.Runtime.CompilerServices;

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
            country = "USA",
            EmployeeList = new List<Employee>
            {
                new Employee { name = "Alice", surname = "Smith", position = "Chef", salary = 50000, phone = "123-456-7890", email = "alice@food.com" },
                new Employee { name = "Bob", surname = "Johnson", position = "Manager", salary = 60000, phone = "123-456-7891", email = "bob@food.com" }
            }
        };
        brands[1] = new Brand
        {
            name = "Black and White",
            date = new Date { year = 2021, month = 2, day = 2 },
            profile = "marketing",
            Director = new Director { name = "Paul", surname = "Black", patronymic = "Mike" },
            country = "London",
            EmployeeList = new List<Employee>
            {
                new Employee { name = "Charlie", surname = "Brown", position = "Designer", salary = 45000, phone = "123-456-7892", email = "dicharlie@bw.com" },
                new Employee { name = "Lionel", surname = "Green", position = "Marketer", salary = 55000, phone = "123-456-7893", email = "diana@bw.com" }
            }
        };
        brands[2] = new Brand
        {
            name = "Global Logic",
            date = new Date { year = 2022, month = 3, day = 3 },
            profile = "IT",
            Director = new Director { name = "Walter", surname = "White", patronymic = "Idk" },
            country = "Ukraine",
            EmployeeList = new List<Employee>
            {
                new Employee { name = "Eve", surname = "Adams", position = "Developer", salary = 70000, phone = "231-456-7894", email = "eve@gl.com" },
                new Employee { name = "Lionelo", surname = "Miller", position = "Manager", salary = 50000, phone = "123-456-7895", email = "lionel@gl.com" }
            }
        };
        
        Console.WriteLine("Write a name of comppany which u want get employees");
        string companyName = Console.ReadLine();
        var emplooyeeOfBrand = brands
            .Where(brand => brand.name.Equals(companyName, StringComparison.OrdinalIgnoreCase))
            .SelectMany(brand => brand.EmployeeList)
            .ToList();
        
        
        Console.WriteLine("Write a compamy which u want get employees");
        companyName = Console.ReadLine();
        Console.WriteLine("Write a min salary");
        int minSalary = Convert.ToInt32(Console.ReadLine());
        var BrandWithSalaryEmployees = brands
            .Where(brand => brand.name.Equals(companyName, StringComparison.OrdinalIgnoreCase))
            .SelectMany(brand => brand.EmployeeList.Where(employee => employee.salary >= minSalary))
            .ToList();
        
        var AllManagers = brands
            .SelectMany(brand => brand.EmployeeList)
            .Where(employee => employee.position == "Manager")
            .ToList();

        var AllEmployeesPhoneStartsWith23 = brands
            .SelectMany(brand => brand.EmployeeList)
            .Where(employee => employee.phone.StartsWith("23"))
            .ToList();
        var AllEmployeesEmailStartsWithDi = brands
            .SelectMany(brand => brand.EmployeeList)
            .Where(employee => employee.email.StartsWith("di"))
            .ToList();
        var AllLionels = brands
            .SelectMany(brand => brand.EmployeeList)
            .Where(employee => employee.name == "Lionel")
            .ToList();
    }
}


 
public class Brand
{
    public string name { get; set; }
    public Date date { get; set; }
    public string profile { get; set; }
    public Director Director { get; set; }
    public List<Employee> EmployeeList { get; set; }
    public string country { get; set; }
}
 
public class Employee
{
    public string name { get; set; }
    public string surname { get; set; }
    public string patronymic { get; set; }
    public string position { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public int salary { get; set; }
    
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