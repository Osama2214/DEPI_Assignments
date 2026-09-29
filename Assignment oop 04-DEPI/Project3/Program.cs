
using System;

namespace Assignment04Project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Example 1

            Duration D1 = new Duration(1, 10, 15);

            Console.WriteLine(D1.ToString());


            // Example 2

            Duration D2 = new Duration(3600);

            Console.WriteLine(D2.ToString());


            // Example 3

            Duration D3 = new Duration(7800);

            Console.WriteLine(D3.ToString());


            // Example 4

            Duration D4 = new Duration(666);

            Console.WriteLine(D4.ToString());


            // Test Equals

            Console.WriteLine(D1.Equals(D2));


            // Test GetHashCode

            Console.WriteLine(D1.GetHashCode());
        }
    }
}