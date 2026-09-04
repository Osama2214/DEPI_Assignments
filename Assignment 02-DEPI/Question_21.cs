using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of arrays: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] array1 = new int[size];
        int[] array2 = new int[size];
        int[] mergedArray = new int[size * 2];

        Console.WriteLine("Enter elements of first array:");

        for (int i = 0; i < size; i++)
        {
            array1[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Enter elements of second array:");

        for (int i = 0; i < size; i++)
        {
            array2[i] = Convert.ToInt32(Console.ReadLine());
        }

        int index = 0;
        int i1 = 0;
        int i2 = 0;

        while (i1 < size && i2 < size)
        {
            if (array1[i1] < array2[i2])
            {
                mergedArray[index] = array1[i1];
                i1++;
            }
            else
            {
                mergedArray[index] = array2[i2];
                i2++;
            }

            index++;
        }

        while (i1 < size)
        {
            mergedArray[index] = array1[i1];
            i1++;
            index++;
        }

        while (i2 < size)
        {
            mergedArray[index] = array2[i2];
            i2++;
            index++;
        }

        Console.WriteLine("Merged array:");

        for (int i = 0; i < mergedArray.Length; i++)
        {
            Console.Write(mergedArray[i] + " ");
        }
    }
}