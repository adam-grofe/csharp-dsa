
using System.Reflection.Metadata.Ecma335;

namespace DynamicProgramming;

static public class LongestCommonSubstring
{

    static public int LCS_DPTabulation(string left, string right)
    {
        int m = left.Length;
        int n = right.Length;

        int[,] table = new int[m+1, n+1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (left[i - 1] == right[j - 1])
                {
                    // When they are same add one to the next element
                    table[i, j] = table[i - 1, j - 1] + 1;
                }
                else
                {
                    // Else choose the highest out of the previous elements
                    table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                }
            }
        }
        return table[m, n];
    }
}
