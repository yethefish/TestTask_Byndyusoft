namespace Program.Test;

public class SumOfTwoMinimalNumbersTest
{
    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithEmptyList_ThrowsArgumentException()
    {
        var sumOfTwoMinimalNumbers = new SumOfTwoMinimalNumbers();

        Action action = () => sumOfTwoMinimalNumbers.Calculate(new List<int>(100));
        ArgumentException exception = Assert.Throws<ArgumentException>(action);

        Assert.Equal("Not enough numbers in array", exception.Message);
    }

    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithNull_ThrowsArgumentNullException()
    {
        var sumOfTwoMinimalNumbers = new SumOfTwoMinimalNumbers();
        List<int>? list = null;

        Action action = () => sumOfTwoMinimalNumbers.Calculate(list);
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(action);

        Assert.Equal("Array cannot be null", exception.ParamName);
    }

    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithBigList_ThrowsArgumentOutOfRangeException()
    {
        var sumOfTwoMinimalNumbers = new SumOfTwoMinimalNumbers();

        Action action = () => sumOfTwoMinimalNumbers.Calculate(new List<int>(new int[100_000_000]));
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(action);

        Assert.Equal("Array is too big", exception.ParamName);
    }

    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithIntMaxValues_ThrowsOverflowException()
    {
        var sumOfTwoMinimalNumbers = new SumOfTwoMinimalNumbers();
        var testData = new List<int>([int.MinValue, -10]);
        var exceptionType = typeof(OverflowException);

        Action action = () => sumOfTwoMinimalNumbers.Calculate(testData);
        
        Assert.Throws(exceptionType, action);
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Program_SumOfTwoMinimalNumbersWithCorrectData_ReturnInt(List<int> arr, int expectedResult)
    {
        var sumOfTwoMinimalNumbers = new SumOfTwoMinimalNumbers();

        int result = sumOfTwoMinimalNumbers.Calculate(arr);

        Assert.Equal(expectedResult, result);
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { new List<int>([4, 0, 3, 19, 492, -10, 1 ]), -10 };
        yield return new object[] { new List<int>([4, -10, 3, 19, 492, 0, 1 ]), -10 };
        yield return new object[] { new List<int>([-10, -10, 3, 19, 492, 0, 1 ]), -20 };
        yield return new object[] { new List<int>([ 5, 2, 8 ]), 7 };
        yield return new object[] { new List<int>([ 0, 0, 0 ]), 0 };
        yield return new object[] { new List<int>([ -5367, 123, 999, -4566, -777 ]), -9933};
        yield return new object[] { new List<int>([ -536_567_857, 121_237_783, 99_934_899, -4_522_266, -0, +1, +0]), -541_090_123};
        yield return new object[] { new List<int>([ -111, 111, 999]), 0};
    }

}
