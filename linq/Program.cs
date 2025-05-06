namespace linq;

class Program
{
    int randomNumbers(int[] numbers)
    {
        // for array of numbers set random numbers
        Random random = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 100);
        }
        return numbers.Length;
    }
    int getRandomNumber()
    {
        Random random = new Random();
        return random.Next(1, 100);
    }
    static void Main(string[] args)
    {
        Program program = new Program();
        // random numbers
        int[] numbers = new int[10];
        program.randomNumbers(numbers);

        IEnumerable<int> PairNumbers =
            from number in numbers
            where number % 2 == 0
            select number;

        IEnumerable<int> NonPairNumbers =
            from number in numbers
            where number % 2 != 0
            select number;
        
        int n = program.getRandomNumber();
        
        IEnumerable<int> BiggerThanN =
            from number in numbers
            where number > n
            select number;

        int a = program.getRandomNumber();
        int b = program.getRandomNumber();

        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        IEnumerable<int> InRange =
            from number in numbers
            where number >= a && number <= b
            select number;
        
        IEnumerable<int> Multiplies7 =
            from number in numbers
            where number % 7 == 0
            orderby number
            select number;
        
        IEnumerable<int> Multiplies8 =
            from number in numbers
            where number % 8 == 0
            orderby number descending
            select number;
    }
    
    
}