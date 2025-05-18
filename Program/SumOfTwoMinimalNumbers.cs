namespace Program;

public class SumOfTwoMinimalNumbers
{
    public int Calculate(List<int>? numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException("Array cannot be null");
        }
        else if (numbers.Count <= 1)
        {
            throw new ArgumentException("Not enough numbers in array");
        }

        int firstMin = int.MaxValue, secondMin = int.MaxValue;

        foreach (int number in numbers)
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

        checked
        {
            return firstMin + secondMin;
        }
    }
}