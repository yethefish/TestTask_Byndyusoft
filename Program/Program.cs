using System.ComponentModel.DataAnnotations;

namespace Program;
public class Program
{
    public int SumOfTwoMinimalNumbers(List<int> numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException("Array cannot be null");
        }
        else if (numbers.Count <= 1)
        {
            throw new ArgumentException("Not enough numbers in array");
        }
        else if (numbers.Count >= 100_000_000)
        {
            throw new ArgumentOutOfRangeException("Array is too big");
        }

        int firstMin = int.MaxValue, secondMin = int.MaxValue;

        foreach(int number in numbers)
        {
            if (firstMin > number)
            {
                secondMin = firstMin;
                firstMin = number;
            }
            else if (secondMin > number && firstMin <= number)
            {
                secondMin = number;
            }
        }

        try
        {
            checked
            {
                return firstMin + secondMin;
            }
        }
        catch
        {
            throw new OverflowException("Sum of two minimal numbers resulted in an overflow");
        }
    }
    
    static void Main(string[] args)
    {
        var numbers = new List<int>([4, 0, 3, 19, 492, -10, 1]);

        var program = new Program();
        var answer = program.SumOfTwoMinimalNumbers(numbers);
        
        Console.WriteLine(answer);
    }
}