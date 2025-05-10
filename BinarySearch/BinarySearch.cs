using System.Diagnostics;

namespace Binary.Search
{

    public class BinarySearchClass
    {
        public int BinarySearch(List<int> l, int val)
        {
            if (l == null) return -1;
            Trace.WriteLine("Enter binary search");
            int high = l.Count - 1;
            int low = 0;
            while (high >= low)
            {
                int mid = (high + low) / 2;
                Trace.WriteLine($"Mid = {mid}  High = {high}  Low = {low}");
                if (l[mid] == val)
                {
                    return mid;
                }
                else if (l[mid] < val)
                {
                    low = mid + 1;
                }
                else if (l[mid] > val)
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }
}
