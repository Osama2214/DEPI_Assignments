using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int columns = Convert.ToInt32(Console.ReadLine());

        int[,] array1 = new int[rows, columns];
        int[,] array2 = new int[rows, columns];

        Console.WriteLine("Enter elements of first array:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array1[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array2[i, j] = array1[i, j];
            }
        }

        Console.WriteLine("Second array:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(array2[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}