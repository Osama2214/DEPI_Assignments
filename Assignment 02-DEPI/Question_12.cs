using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter operator (+, -, *, /): ");
        char operation = Convert.ToChar(Console.ReadLine());

        Console.Write("Enter second number: ");
        double number2 = Convert.ToDouble(Console.ReadLine());

        switch (operation)
        {
            case '+':
                Console.WriteLine(number1 + number2);
                break;

            case '-':
                Console.WriteLine(number1 - number2);
                break;

            case '*':
                Console.WriteLine(number1 * number2);
                break;

            case '/':
                Console.WriteLine(number1 / number2);
                break;

            default:
                Console.WriteLine("Invalid operator");
                break;
        }
    }
}