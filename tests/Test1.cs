using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    [TestClass]
    public sealed class LinqTests
    {
        private readonly List<Student> students = new()
        {
            new Student { Name = "Boris", Surname = "Doe", Age = 20, University = "Harvard" },
            new Student { Name = "Jane", Surname = "Smith", Age = 22, University = "MIT" },
            new Student { Name = "Sam", Surname = "Brown", Age = 19, University = "Oxford" },
            new Student { Name = "Alice", Surname = "Johnson", Age = 21, University = "Oxford" },
            new Student { Name = "Bob", Surname = "Davis", Age = 23, University = "Oxford" }
        };

        [TestMethod]
        public void Test_AllStudents()
        {
            IEnumerable<Student> expected = students;
            IEnumerable<Student> actual = from student in students select student;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StudentsBoris()
        {
            IEnumerable<Student> expected = students.Where(s => s.Name == "Boris");
            IEnumerable<Student> actual = from student in students where student.Name == "Boris" select student;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StudentsSurnameStartsBro()
        {
            IEnumerable<Student> expected = students.Where(s => s.Surname.StartsWith("Bro"));
            IEnumerable<Student> actual = from student in students where student.Surname.StartsWith("Bro") select student;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StudentsOlderThan19()
        {
            IEnumerable<Student> expected = students.Where(s => s.Age > 19);
            IEnumerable<Student> actual = from student in students where student.Age > 19 select student;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StudentsOlderThan20AndYoungerThan23()
        {
            IEnumerable<Student> expected = students.Where(s => s.Age > 20 && s.Age < 23);
            IEnumerable<Student> actual = from student in students where student.Age > 20 && student.Age < 23 select student;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StudentsInMIT()
        {
            IEnumerable<Student> expected = students.Where(s => s.University == "MIT");
            IEnumerable<Student> actual = from student in students where student.University == "MIT" select student;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }

        [TestMethod]
        public void Test_StudentsInOxfordAndOlderThan18()
        {
            IEnumerable<Student> expected = students.Where(s => s.University == "Oxford" && s.Age > 18).OrderBy(s => s.Age);
            IEnumerable<Student> actual = from student in students where student.University == "Oxford" && student.Age > 18 orderby student.Age select student;

            CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string University { get; set; }
    }
}