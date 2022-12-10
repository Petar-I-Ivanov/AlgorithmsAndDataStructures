using System;

namespace Algorithms
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            int[] array = RandomArray();

            // Sorts
            Console.WriteLine("Before:");
            PrintArray(array);

            Sort.BubbleSort(array);
            Sort.InsertionSort(array);
            Sort.SelectionSort(array);
            Sort.QuickSort(array);
            Sort.MergeSort(array);
            Sort.ShellSort(array);

            Console.WriteLine("After:");
            PrintArray(array);

            // Searches
            Console.WriteLine($"Is {array[0]} found - {Search.LinerSearch(array,array[0])}");
            Console.WriteLine($"Is {20} found - {Search.LinerSearch(array, 20)}");

            Sort.QuickSort(array);

            Console.WriteLine($"Is {array[0]} found - {Search.BinarySearch(array, array[0])}");
            Console.WriteLine($"Is {20} found - {Search.BinarySearch(array, 20)}");
        }

        private static int[] RandomArray()
        {
            Random random = new Random();
            int[] array = new int[15];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(20);
            }

            return array;
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.Write("- " + IsSorted(array));
            Console.WriteLine();
        }
    
        private static bool IsSorted(int[] array)
        {
            bool isSorted = true;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    isSorted = false;
                }
            }

            return isSorted;
        }
    }
}
