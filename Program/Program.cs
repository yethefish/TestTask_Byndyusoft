using System.ComponentModel.DataAnnotations;
namespace Program;
public class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int>([4, 0, 3, 19, 492, -10, 1]);
        var sumOfTwoMinimalNumbers = new SumOfTwoMinimalNumbers();
        var answer = sumOfTwoMinimalNumbers.Calculate(numbers);
        
        Console.WriteLine(answer);
    }
}