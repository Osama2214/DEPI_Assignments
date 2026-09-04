using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= 12; i++)
        {
            Console.Write(number * i + " ");
        }
    }
}