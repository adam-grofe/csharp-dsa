using DynamicProgramming;

namespace DynamicProgrammingTests;

public class LongestCommonSubstringTests
{
    [Theory]
    [InlineData("")]
    [InlineData("ABC")]
    [InlineData("ABCDEFGHIJKLMNOP")]
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
    public void LongestCommonSubstring_MatchingStrings_ReturnsLength(string input)
    {
        // Arrange

        // Act
        var result = LongestCommonSubstring.LCS_DPTabulation(input, input);

        // Assert
        Assert.Equal(input.Length, result);
    }

    [Theory]
    [InlineData("ABC", "ACD", 2)]
    [InlineData("AGGTAB", "GXTXAYB", 4)]
    [InlineData("ABC", "CBA", 1)]
    public void LongestCommonSubstring_DifferentStrings_ReturnsInt(string left, string right, int expectedResult)
    {
        // Arrange

        // Act
        var result = LongestCommonSubstring.LCS_DPTabulation(left, right);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("ABCD", "EFGH")]
    [InlineData("ABCDEFGH", "IJKLMNOPQ")]
    public void LongestCommonSubstring_CompletelyDifferentStrings_Returns0(string left, string right)
    {
        // Arrange

        // Act
        var result = LongestCommonSubstring.LCS_DPTabulation(left, right);

        // Assert
        Assert.Equal(0, result);
    }
}
