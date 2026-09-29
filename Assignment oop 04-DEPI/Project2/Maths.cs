
using System;

namespace Assignment04Project2
{
    public class Maths
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }


        public static int Subtract(int x, int y)
        {
            return x - y;
        }


        public static int Multiply(int x, int y)
        {
            return x * y;
        }


        public static double Divide(double x, double y)
        {
            if (y == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return 0;
            }

            return x / y;
        }
    }
}