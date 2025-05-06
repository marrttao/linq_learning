namespace linq;

class Program
{
    static void Main(string[] args)
    {
        string [] strings = { "one", "two", "three" };
        IEnumerable<string> UserSortDescending =
            from s in strings
            orderby s.Length descending
            select s;
        IEnumerable<string> UserSortAscending =
            from s in strings
            orderby s.Length
            select s;
    }
    
}