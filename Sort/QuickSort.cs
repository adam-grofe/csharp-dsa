namespace Sort;
public static class QuickSort
{
    public static List<int> Sort(List<int> input)
    {
        if (input.Count < 2)
        {
            return input;
        }

        int pivot = RandomIndex(input.Count);
        var less = new List<int>();
        var more = new List<int>();

        for (int i = 0; i < input.Count; i++)
        {
            if (i != pivot)
            {
                if (input[i] <= input[pivot])
                {
                    less.Add(input[i]);
                }
                else
                {
                    more.Add(input[i]);
                }
            }
        }
        return QuickSort.Sort(less).Concat(new List<int>() { input[pivot] }).Concat(QuickSort.Sort(more)).ToList();
    }

    private static int RandomIndex(int length)
    {
        if (length < 1)
        {
            return 0;
        }
        Random random = new Random();
        return random.Next(1, length);
    }

}
