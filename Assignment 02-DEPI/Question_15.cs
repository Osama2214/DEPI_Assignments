using System;

class Program
{
    static void Main()
    {
        Console.Write("Input starting number of range: ");
        int start = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input ending number of range: ");
        int end = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("The prime numbers between " + start + " and " + end + " are:");

        for (int number = start; number <= end; number++)
        {
            if (number < 2)
                continue;

            bool isPrime = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.Write(number + " ");
            }
        }
    }
}