namespace DynamicProgramming;
public static class Knapsack
{
    public static int MaxProfit(List<int> profit, List<int> weight, int maxWeight)
    {
        if (profit.Count != weight.Count)
        {
            throw new ArgumentException("The sizes of the arrays are not the same.");
        }

        int n = profit.Count;

        int[,] table = new int[n + 1, maxWeight + 1];
        for (int i = 0; i <= n; i++)
        {
            table[i, 0] = 0;
            table[0, i] = 0;
        }
        table[0, 0] = 0;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= maxWeight; j++)
            {
                int pick = 0;

                if (weight[i-1] <= j)
                {
                    pick = profit[i - 1] + table[i - 1, j - weight[i - 1]];
                }
                int nopick = table[i - 1, j];

                table[i, j] = Math.Max(pick, nopick);
            }
        }
        return table[n, maxWeight];
    }
}
