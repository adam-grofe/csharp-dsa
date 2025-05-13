using DynamicProgramming;

namespace DynamicProgrammingTests;
public class KnapsackTests
{
    static List<int> parseListString(string listStr)
    {
        var result = new List<int>();
        foreach (var c in listStr)
        {
            string intStr = $"{c}";
            result.Add(Convert.ToInt32(intStr));
        }
        return result;
    }

    [Theory]
    [InlineData("123", "451", 4, 3)]
    [InlineData("123", "451", 5, 4)]
    [InlineData("123", "451", 6, 5)]
    [InlineData("123", "451", 12, 6)]
    [InlineData("2423", "1324", 9, 9)]
    public void Knapsack_ValidArrays_ReturnProfit(string profitItems, string weightItems, int maxWeight, int expectedResult)
    {
        // Arrange
        var profit = parseListString(profitItems);
        var weight = parseListString(weightItems);

        // Act
        var result = Knapsack.MaxProfit(profit, weight, maxWeight);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
