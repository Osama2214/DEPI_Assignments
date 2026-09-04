using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a character: ");
        char character = Convert.ToChar(Console.ReadLine());

        if (character == 'a' || character == 'e' || character == 'i' ||
            character == 'o' || character == 'u' ||
            character == 'A' || character == 'E' || character == 'I' ||
            character == 'O' || character == 'U')
        {
            Console.WriteLine("vowel");
        }
        else
        {
            Console.WriteLine("consonant");
        }
    }
}