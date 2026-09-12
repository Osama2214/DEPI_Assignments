using System;

class Person
{
    public string Name;
}

class Program
{


    // Question 1



    static void ChangeByValue(int number)
    {
        number = 20;
    }

    static void ChangeByReference(ref int number)
    {
        number = 20;
    }




    // Question 2



    static void ChangePersonByValue(Person person)
    {
        person = new Person();
        person.Name = "Ahmed";
    }

    static void ChangePersonByReference(ref Person person)
    {
        person = new Person();
        person.Name = "Ahmed";
    }




    // Question 3



    static (int, int) Calculate(int num1, int num2, int num3, int num4)
    {
        int sum = num1 + num2;
        int subtract = num3 - num4;

        return (sum, subtract);
    }




    // Question 4



    static int SumDigits(int number)
    {
        int sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }




    // Question 5



    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }




    // Question 6



    static void MinMaxArray(int[] array, ref int min, ref int max)
    {
        min = array[0];
        max = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
                min = array[i];

            if (array[i] > max)
                max = array[i];
        }
    }




    // Question 7



    static long Factorial(int number)
    {
        long result = 1;

        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }




    // Question 8



    static string ChangeChar(string text, int position, char newChar)
    {
        char[] chars = text.ToCharArray();
        chars[position] = newChar;

        return new string(chars);
    }


    static void Main()
    {


        // Question 1



        int x = 10;

        ChangeByValue(x);
        Console.WriteLine(x);

        ChangeByReference(ref x);
        Console.WriteLine(x);




        // Question 2



        Person person = new Person();
        person.Name = "Ali";

        ChangePersonByValue(person);
        Console.WriteLine(person.Name);

        ChangePersonByReference(ref person);
        Console.WriteLine(person.Name);




        // Question 3



        Console.WriteLine("Enter four numbers:");

        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        int num4 = int.Parse(Console.ReadLine());

        var result = Calculate(num1, num2, num3, num4);

        Console.WriteLine(result.Item1);
        Console.WriteLine(result.Item2);




        // Question 4



        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine($"The sum of the digits of the number {number} is: {SumDigits(number)}");



        // Question 5



        Console.Write("Enter a number: ");
        number = int.Parse(Console.ReadLine());

        Console.WriteLine(IsPrime(number));




        // Question 6



        int[] array = { 5, 2, 9, 1, 7 };

        int min = 0;
        int max = 0;

        MinMaxArray(array, ref min, ref max);

        Console.WriteLine(min);
        Console.WriteLine(max);




        // Question 7



        Console.Write("Enter a number: ");
        number = int.Parse(Console.ReadLine());

        Console.WriteLine(Factorial(number));




        // Question 8



        Console.Write("Enter a string: ");
        string text = Console.ReadLine();

        Console.Write("Enter position: ");
        int position = int.Parse(Console.ReadLine());

        Console.Write("Enter new character: ");
        char newChar = char.Parse(Console.ReadLine());

        Console.WriteLine(ChangeChar(text, position, newChar));
    }
}