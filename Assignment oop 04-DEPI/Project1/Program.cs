
using System;

namespace Assignment04Project1
{
    internal class Program
    {
        static int ReadCoordinate(string message)
        {
            int value;

            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter an integer: ");
            }

            return value;
        }

        static void Main(string[] args)
        {
            // Create P1

            Console.WriteLine("Enter coordinates for P1:");

            int x1 = ReadCoordinate("X: ");
            int y1 = ReadCoordinate("Y: ");
            int z1 = ReadCoordinate("Z: ");

            Point3D P1 = new Point3D(x1, y1, z1);


            // Create P2

            Console.WriteLine("\nEnter coordinates for P2:");

            int x2 = ReadCoordinate("X: ");
            int y2 = ReadCoordinate("Y: ");
            int z2 = ReadCoordinate("Z: ");

            Point3D P2 = new Point3D(x2, y2, z2);


            // Display Points

            Console.WriteLine("\nP1:");
            Console.WriteLine(P1.ToString());

            Console.WriteLine("\nP2:");
            Console.WriteLine(P2.ToString());


            // Compare using ==

            Console.WriteLine("\nCompare P1 and P2:");

            if (P1 == P2)
            {
                Console.WriteLine("P1 equals P2");
            }
            else
            {
                Console.WriteLine("P1 does not equal P2");
            }


            // Create Array of Points

            Point3D[] points =
            {
                new Point3D(5, 3, 1),
                new Point3D(2, 8, 4),
                new Point3D(2, 4, 6),
                new Point3D(1, 9, 2)
            };


            // Sort Array

            Array.Sort(points);

            Console.WriteLine("\nSorted Points:");

            foreach (Point3D point in points)
            {
                Console.WriteLine(point);
            }


            // Clone P1

            Point3D P3 = (Point3D)P1.Clone();

            Console.WriteLine("\nCloned Point:");
            Console.WriteLine(P3);
        }
    }
}