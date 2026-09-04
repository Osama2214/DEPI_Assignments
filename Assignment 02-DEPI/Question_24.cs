using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("Enter element " + i + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        int largest = numbers[0];
        int secondLargest = int.MinValue;

        for (int i = 1; i < size; i++)
        {
            if (numbers[i] > largest)
            {
                secondLargest = largest;
                largest = numbers[i];
            }
            else if (numbers[i] > secondLargest && numbers[i] != largest)
            {
                secondLargest = numbers[i];
            }
        }

        Console.WriteLine("Second largest element = " + secondLargest);
    }
}