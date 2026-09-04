using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[size];

        for (int i = 0; i < size; i++)
        {
            Console.Write("Enter element " + i + ": ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < size; i++)
        {
            int count = 0;

            for (int j = 0; j < size; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    count++;
                }
            }

            bool alreadyPrinted = false;

            for (int j = 0; j < i; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    alreadyPrinted = true;
                    break;
                }
            }

            if (!alreadyPrinted)
            {
                Console.WriteLine(numbers[i] + " = " + count);
            }
        }
    }
}