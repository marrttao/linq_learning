namespace linq;

class Program
{
    static void Main(string[] args)
    {
        string [] Towns = { "Amsterdam", "Stockholm", "New York", "Neenah" };
        
        
        
        IEnumerable<string> AllTowns =
            from Town in Towns
            select Town;
        Random random = new Random();
        
        int n = random.Next(0, 10);
        
        
        IEnumerable<string> LenghtOfName =
            from Town in Towns
            where Town.Length == n
            select Town;
        
        
        IEnumerable<string> StartsWithA =
            from Town in Towns
            where Town.StartsWith("A")
            select Town;
        
        
        IEnumerable<string> EndsWithM =
            from Town in Towns
            where Town.EndsWith("m")
            select Town;
        
        
        IEnumerable<string> StartsWithNAndEndsWithK =
            from Town in Towns
            where Town.StartsWith("N") && Town.EndsWith("K")
            select Town;
        
        
        IEnumerable<string> StartsWithNe = 
            from Town in Towns
            where Town.StartsWith("Ne")
            orderby Town descending
            select Town;
    }
}