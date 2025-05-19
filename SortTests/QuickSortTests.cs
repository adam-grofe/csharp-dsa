using Sort;

namespace SortTests;
public class QuickSortTests
{
    static public List<int> parseListString(string str)
    {
        var result = new List<int>();
        foreach (var c in str)
        {
            string intStr = $"{c}";
            result.Add(Convert.ToInt32(intStr));
        }
        return result;

    }

    [Theory]
    [InlineData("123456", "123456")]
    [InlineData("654321", "123456")]
    [InlineData("164523", "123456")]
    public void QuickSort_UniqueElements_Sorted(string inputStr, string expectedStr)
    {
        // Arrange
        var list = parseListString(inputStr);
        var expected = parseListString(expectedStr);

        // Act
        var sorted = QuickSort.Sort(list);

        // Assert
        Assert.Equal(expected, sorted);
    }

    [Theory]
    [InlineData("1236456", "1234566")]
    [InlineData("65241321", "11223456")]
    [InlineData("16452353", "12334556")]
    [InlineData("11111111111111", "11111111111111")]
    public void QuickSort_WithDuplicateElements_Sorted(string inputStr, string expectedStr)
    {
        // Arrange
        var list = parseListString(inputStr);
        var expected = parseListString(expectedStr);

        // Act
        var sorted = QuickSort.Sort(list);

        // Assert
        Assert.Equal(expected, sorted);
    }
}
