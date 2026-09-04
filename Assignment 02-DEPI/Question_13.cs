using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string text = Console.ReadLine();

        for (int i = text.Length - 1; i >= 0; i--)
        {
            Console.Write(text[i]);
        }
    }
}