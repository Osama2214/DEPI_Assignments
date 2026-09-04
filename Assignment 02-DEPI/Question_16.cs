using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number to convert: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int binary = 0;
        int place = 1;

        while (number > 0)
        {
            int remainder = number % 2;

            binary = binary + remainder * place;

            number = number / 2;
            place = place * 10;
        }

        Console.WriteLine("The Binary is " + binary);
    }
}