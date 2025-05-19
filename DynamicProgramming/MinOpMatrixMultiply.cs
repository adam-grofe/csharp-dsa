namespace DynamicProgramming;
public static class MinOpMatrixMultiply
{
    public static int MinOp(List<int> dims)
    {
        int N = dims.Count;

        int[,] table = new int[N, N];

        for (int len = 2; len < N; len++)
        {
            for (int i = 0; i < N - len; i++)
            {
                int j = i + len;
                table[i, j] = int.MaxValue;

                for (int k = i + 1; k < j; k++)
                {
                    int cost = table[i, k] + table[k, j] + dims[i] * dims[k] * dims[j];
                    if (cost < table[i, j])
                    {
                        table[i, j] = cost;
                    }
                }
            }
        }
        return table[0, N - 1];
    }
}
