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

        int max = numbers[0];
        int min = numbers[0];

        for (int i = 1; i < size; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }

            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }

        Console.WriteLine("Maximum element = " + max);
        Console.WriteLine("Minimum element = " + min);
    }
}