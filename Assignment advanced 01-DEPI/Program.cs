
using System;

class Program
{
    static void OptimizedBubbleSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    swapped = true;
                }
            }

            // Stop if the array is already sorted
            if (!swapped)
                break;
        }
    }

    static void Main()
    {
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        OptimizedBubbleSort(numbers);

        Console.WriteLine("Sorted array:");

        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
    }
}