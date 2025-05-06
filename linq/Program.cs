namespace linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var students = new List<Student>
        {
            new Student { Name = "Boris", Surname = "Doe", Age = 20, University = "Harvard" },
            new Student { Name = "Jane", Surname = "Smith", Age = 22, University = "MIT" },
            new Student { Name = "Sam", Surname = "Brown", Age = 19, University = "Oxford" },
            new Student { Name = "Alice", Surname = "Johnson", Age = 21, University = "Oxford" },
            new Student { Name = "Bob", Surname = "Davis", Age = 23, University = "Oxford" }
        };
        IEnumerable<Student> Students = 
            from student in students
            select student;
        IEnumerable<Student> StudentsBoris =
            from student in students
            where student.Name == "Boris"
            select student;
        IEnumerable<Student> StudentsSurnameStartsBro =
            from student in students
            where student.Surname.StartsWith("Bro") 
            select student;
        IEnumerable<Student> StudentsOlderThan19 = 
            from student in students 
            where student.Age > 19
            select student;
        IEnumerable <Student> StudentsOlderThan20AndYoungerThan23 =
            from student in students
            where student.Age > 20 && student.Age < 23
            select student;
        IEnumerable <Student> StudentsInMIT = 
            from student in students
            where student.University == "MIT"
            select student;
        IEnumerable<Student> StudentsInOxfordAndOlderThan18 =
            from student in students
            where student.University == "Oxford" && student.Age > 18
            orderby student.Age
            select student;
    }
}

 class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string University { get; set; }
}