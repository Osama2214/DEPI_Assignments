using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int number1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int number2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int number3 = Convert.ToInt32(Console.ReadLine());

        int max = number1;
        int min = number1;

        if (number2 > max)
        {
            max = number2;
        }

        if (number3 > max)
        {
            max = number3;
        }

        if (number2 < min)
        {
            min = number2;
        }

        if (number3 < min)
        {
            min = number3;
        }

        Console.WriteLine("Max element = " + max);
        Console.WriteLine("Min element = " + min);
    }
}