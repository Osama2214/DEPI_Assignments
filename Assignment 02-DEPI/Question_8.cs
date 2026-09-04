using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 2; i <= number; i += 2)
        {
            Console.Write(i + " ");
        }
    }
}