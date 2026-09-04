using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the base: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the power: ");
        int power = Convert.ToInt32(Console.ReadLine());

        int result = 1;

        for (int i = 1; i <= power; i++)
        {
            result = result * number;
        }

        Console.WriteLine(result);
    }
}