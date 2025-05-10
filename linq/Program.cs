namespace linq;

class Program
{
    static void Main(string[] args)
    {
        string [] numbers = { "11", "35", "78", "12", "98" };
        var sortBySumOfNumber = 
            from number in numbers
            where number.Length == 2
            let sum = number[0] - '0' + number[1] - '0'
            orderby sum
            select sum;
        var AnotherSortBySumOfNumber = 
            from number in numbers
            where number.Length == 2
            let sum = number[0] - '0' + number[1] - '0'
            orderby sum descending 
            select sum;

    }
}