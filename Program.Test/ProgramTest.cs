namespace Program.Test;

public class ProgramTest
{
    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithEmptyList_ThrowsArgumentException()
    {
        var program = new Program();

        Action action = () => program.SumOfTwoMinimalNumbers(new List<int>(100));
        ArgumentException exception = Assert.Throws<ArgumentException>(action);

        Assert.Equal("Not enough numbers in array", exception.Message);
    }

    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithNull_ThrowsArgumentNullException()
    {
        var program = new Program();
        List<int> list = null;

        Action action = () => program.SumOfTwoMinimalNumbers(null);
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(action);

        Assert.Equal("Array cannot be null", exception.ParamName);
    }

    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithBigList_ThrowsArgumentOutOfRangeException()
    {
        var program = new Program();

        Action action = () => program.SumOfTwoMinimalNumbers(new List<int>(new int[100_000_000]));
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(action);

        Assert.Equal("Array is too big", exception.ParamName);
    }

    [Fact]
    public void Program_SumOfTwoMinimalNumbersWithIntMaxValues_ThrowsOverflowException()
    {
        var program = new Program();
        var testData = new List<int>([int.MinValue, -10]);


        Action action = () => program.SumOfTwoMinimalNumbers(testData);
        OverflowException exception = Assert.Throws<OverflowException>(action);

        Assert.Equal("Sum of two minimal numbers resulted in an overflow", exception.Message);
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Program_SumOfTwoMinimalNumbersWithCorrectData_ReturnInt(List<int> arr, int expectedResult)
    {
        var program = new Program();

        int result = program.SumOfTwoMinimalNumbers(arr);

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
