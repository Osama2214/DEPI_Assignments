using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter marks of five subjects: ");

        int mark1 = Convert.ToInt32(Console.ReadLine());
        int mark2 = Convert.ToInt32(Console.ReadLine());
        int mark3 = Convert.ToInt32(Console.ReadLine());
        int mark4 = Convert.ToInt32(Console.ReadLine());
        int mark5 = Convert.ToInt32(Console.ReadLine());

        int total = mark1 + mark2 + mark3 + mark4 + mark5;
        int average = total / 5;
        int percentage = total / 5;

        Console.WriteLine("Total marks = " + total);
        Console.WriteLine("Average Marks = " + average);
        Console.WriteLine("Percentage = " + percentage);
    }
}