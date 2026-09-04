using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[size];
        int sum = 0;

        for (int i = 0; i < size; i++)
        {
            Console.Write("Enter element " + i + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());

            sum += numbers[i];
        }

        Console.WriteLine("Sum = " + sum);
    }
}