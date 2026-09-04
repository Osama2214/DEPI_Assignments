using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x3: ");
        double x3 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y3: ");
        double y3 = Convert.ToDouble(Console.ReadLine());

        if ((y2 - y1) * (x3 - x2) == (y3 - y2) * (x2 - x1))
        {
            Console.WriteLine("The points lie on a single straight line.");
        }
        else
        {
            Console.WriteLine("The points do not lie on a single straight line.");
        }
    }
}