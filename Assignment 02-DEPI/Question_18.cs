using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the time taken to complete the job: ");
        double hours = Convert.ToDouble(Console.ReadLine());

        if (hours >= 2 && hours <= 3)
        {
            Console.WriteLine("Highly efficient");
        }
        else if (hours > 3 && hours <= 4)
        {
            Console.WriteLine("Increase their speed");
        }
        else if (hours > 4 && hours <= 5)
        {
            Console.WriteLine("Training is required");
        }
        else if (hours > 5)
        {
            Console.WriteLine("Leave the company");
        }
    }
}