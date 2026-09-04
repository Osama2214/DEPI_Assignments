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

        int maxDistance = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    int distance = j - i - 1;

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }
            }
        }

        Console.WriteLine("Longest distance = " + maxDistance);
    }
}