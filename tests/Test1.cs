using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using linq;

namespace tests
{
    [TestClass]
    public class LinqTests
    {
       private List<Brand> GetTestBrands()
{
    return new List<Brand>
    {
        new Brand
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
        },
        new Brand
        {
            name = "Black and White",
            date = new Date { year = 2021, month = 2, day = 2 },
            profile = "marketing",
            Director = new Director { name = "Paul", surname = "Black", patronymic = "Mike" },
            country = "London",
            EmployeeList = new List<Employee>
            {
                new Employee { name = "Charlie", surname = "Brown", position = "Designer", salary = 45000, phone = "123-456-7892", email = "di.charlie@bw.com" },
                new Employee { name = "Lionel", surname = "Green", position = "Marketer", salary = 55000, phone = "123-456-7893", email = "diana@bw.com" }
            }
        },
        new Brand
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
        }
    };
}

        [TestMethod]
        public void TestGetEmployeesByCompanyName()
        {
            var brands = GetTestBrands();
            var employees = brands
                .Where(brand => brand.name.Equals("Food Company", System.StringComparison.OrdinalIgnoreCase))
                .SelectMany(brand => brand.EmployeeList)
                .ToList();

            Assert.AreEqual(2, employees.Count);
            Assert.IsTrue(employees.Any(e => e.name == "Alice"));
            Assert.IsTrue(employees.Any(e => e.name == "Bob"));
        }

        [TestMethod]
        public void TestGetEmployeesByMinSalary()
        {
            var brands = GetTestBrands();
            var employees = brands
                .Where(brand => brand.name.Equals("Global Logic", System.StringComparison.OrdinalIgnoreCase))
                .SelectMany(brand => brand.EmployeeList.Where(employee => employee.salary >= 60000))
                .ToList();

            Assert.AreEqual(1, employees.Count);
            Assert.AreEqual("Eve", employees[0].name);
        }

        [TestMethod]
        public void TestGetAllManagers()
        {
            var brands = GetTestBrands();
            var managers = brands
                .SelectMany(brand => brand.EmployeeList)
                .Where(employee => employee.position == "Manager")
                .ToList();

            Assert.AreEqual(2, managers.Count);
            Assert.IsTrue(managers.Any(m => m.name == "Bob"));
            Assert.IsTrue(managers.Any(m => m.name == "Lionelo"));
        }

        [TestMethod]
        public void TestGetEmployeesPhoneStartsWith23()
        {
            var brands = GetTestBrands();
            var employees = brands
                .SelectMany(brand => brand.EmployeeList)
                .Where(employee => employee.phone.StartsWith("23"))
                .ToList();

            Assert.AreEqual(1, employees.Count);
            Assert.AreEqual("Eve", employees[0].name);
        }

        [TestMethod]
        public void TestGetEmployeesEmailStartsWithDi()
        {
            var brands = GetTestBrands();
            var employees = brands
                .SelectMany(brand => brand.EmployeeList)
                .Where(employee => employee.email.StartsWith("di"))
                .ToList();

            Assert.AreEqual(1, employees.Count);
            Assert.AreEqual("Charlie", employees[0].name);
        }

        [TestMethod]
        public void TestGetAllLionels()
        {
            var brands = GetTestBrands();
            var lionels = brands
                .SelectMany(brand => brand.EmployeeList)
                .Where(employee => employee.name == "Lionel")
                .ToList();

            Assert.AreEqual(1, lionels.Count);
            Assert.AreEqual("Lionel", lionels[0].name);
        }
    }
}