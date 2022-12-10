
namespace Algorithms
{
    public static class Search
    {
        // complexity is O(n) - it is directly related to the size of the inputs
        public static bool LinerSearch(int[] array, int search)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == search)
                {
                    return true;
                }
            }
            return false;
        }

        // complexity is O(log N) - takes an additional step each time the data doubles
        // only works for sorted arrays
        public static bool BinarySearch(int[] array, int search)
        {
            int start = 0;
            int end = array.Length - 1;


            while (start <= end)
            {

                int mid = (start + end) / 2;

                if (search == array[mid])
                {
                    return true;
                }
                else if (search < array[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return false;
        }
    }
}
