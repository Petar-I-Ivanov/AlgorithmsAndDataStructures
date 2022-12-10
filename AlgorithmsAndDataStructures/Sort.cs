using System;

namespace Algorithms
{
    public static class Sort
    {
        //Average and worst complexity O(n^2)
        //Best case O(n) when array is already sorted
        //Worst case when array is reverse sorted
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        //Average and worst complexity O(n^2)
        //Best case O(n) when array is already sorted
        //Worst case when array is reverse sorted
        public static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        //Best, average and worst case complexity O(n^2)
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int index = GetMinValueIndex(array, i);

                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }
        }

        private static int GetMinValueIndex(int[] array, int start)
        {
            int minValueIndex = start;

            for (int i = start + 1; i < array.Length; i++)
            {
                if (array[minValueIndex] > array[i])
                {
                    minValueIndex = i;
                }
            }

            return minValueIndex;
        }

        // Worst case when array is sorted or reverse sorted the Partition
        // divides the array in two subarrays with 0 and n-1 elements O(n^2)
        // Best and Average case the Partition divides the array in two
        // subarrays with equal size O(n.log(n))
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int start, int end)
        {
            if (start > end)
                return;

            int index = Partition(array, start, end);

            QuickSort(array, start, index - 1);
            QuickSort(array, index + 1, end);
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int temp;
            int index = start;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= arr[end])
                {
                    temp = arr[index];
                    arr[index] = arr[j];
                    arr[j] = temp;

                    index++;
                }
            }

            temp = arr[index];
            arr[index] = arr[end];
            arr[end] = temp;

            return index;
        }

        // Best, average and worst case complexity O(n.log(n))
        public static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private static void MergeSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int middle = (start + end) / 2;

            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);

            Merge(array, start, middle, end);
        }

        private static void Merge(int[] array, int start, int middle, int end)
        {
            int[] firstArray = new int[middle - start + 1];
            int[] secondArray = new int[end - middle];

            Array.Copy(array, start, firstArray, 0, middle - start + 1);
            Array.Copy(array, middle + 1, secondArray, 0, end - middle);

            int firstMarker = 0;
            int secondMarker = 0;

            for (int i = start; i < end + 1; i++)
            {
                if (firstMarker == firstArray.Length)
                {
                    array[i] = secondArray[secondMarker];
                    secondMarker++;
                }
                else if (secondMarker == secondArray.Length)
                {
                    array[i] = firstArray[firstMarker];
                    firstMarker++;
                }
                else if (firstArray[firstMarker] <= secondArray[secondMarker])
                {
                    array[i] = firstArray[firstMarker];
                    firstMarker++;
                }
                else
                {
                    array[i] = secondArray[secondMarker];
                    secondMarker++;
                }
            }
        }

        // O(n(log(n))) in the best case
        // O(n(log(n))^2) in the average
        // it is an unstable comparison sort algorithm with poor performance
        public static void ShellSort(int[] array)
        {
            int length = array.Length;
            int gap = length / 2;

            while (gap > 0)
            {
                for (int i = 0; i + gap < length; i++)
                {
                    int j = i + gap;
                    int temp = array[j];

                    while (j - gap >= 0 && temp < array[j - gap])
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }

                    array[j] = temp;
                }

                gap /= 2;
            }
        }
    }
}
