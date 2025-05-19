using DynamicProgramming;
using System.Text;

namespace DynamicProgrammingTests;
public class MinOpMatrixMultiplyTests
{
    private List<int> parseStr(string inputStr)
    {
        var result = new List<int>();
        var idxList = inputStr.Split(",").ToList();
        foreach (var idx in idxList)
        {
            int i = Convert.ToInt32(idx.Trim());
            result.Add( i );
        }
        return result;
    }

    [Theory]
    [InlineData("2, 3", 0)]
    [InlineData("2, 1, 3, 4", 20)]
    [InlineData("1, 2, 3, 4, 3", 30)]
    public void MinOp_ValidList_ReturnsExpectedResult(string inputStr, int expected)
    {
        // Arrange
        List<int> input = parseStr(inputStr);

        // Act
        var result = MinOpMatrixMultiply.MinOp(input);


        // Assert
        Assert.Equal(expected, result);
    }
}
