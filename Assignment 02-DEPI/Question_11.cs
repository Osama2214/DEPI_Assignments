using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter month number: ");
        int month = Convert.ToInt32(Console.ReadLine());

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                Console.WriteLine("Days in Month: 31");
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                Console.WriteLine("Days in Month: 30");
                break;

            case 2:
                Console.WriteLine("Days in Month: 28");
                break;

            default:
                Console.WriteLine("Invalid month");
                break;
        }
    }
}