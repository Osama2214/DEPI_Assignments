using System;

class Program
{


    // Question 1

    

    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }




    // Question 2



    struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }




    // Question 3



    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }




    // Question 4



    [Flags]
    enum Permissions
    {
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }




    // Question 5



    enum Colors
    {
        Red,
        Green,
        Blue
    }




    // Question 6



    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }


    static void Main()
    {


        // Question 1



        foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
        {
            Console.WriteLine(day);
        }




        // Question 2



        Person[] persons =
        {
            new Person { Name = "Ahmed", Age = 20 },
            new Person { Name = "Omar", Age = 25 },
            new Person { Name = "Ali", Age = 22 }
        };

        foreach (Person person in persons)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }




        // Question 3



        Console.Write("Enter season: ");
        string input = Console.ReadLine();

        Season season = Enum.Parse<Season>(input, true);

        switch (season)
        {
            case Season.Spring:
                Console.WriteLine("March to May");
                break;

            case Season.Summer:
                Console.WriteLine("June to August");
                break;

            case Season.Autumn:
                Console.WriteLine("September to November");
                break;

            case Season.Winter:
                Console.WriteLine("December to February");
                break;
        }




        // Question 4



        Permissions permissions = Permissions.Read | Permissions.Write;

        permissions |= Permissions.Delete;

        permissions &= ~Permissions.Write;

        bool hasPermission = permissions.HasFlag(Permissions.Read);

        Console.WriteLine(permissions);
        Console.WriteLine(hasPermission);




        // Question 5



        Console.Write("Enter color: ");
        input = Console.ReadLine();

        if (Enum.TryParse(input, true, out Colors color))
        {
            Console.WriteLine($"{color} is a primary color.");
        }
        else
        {
            Console.WriteLine($"{input} is not a primary color.");
        }




        // Question 6



        Console.Write("Enter X1: ");
        double x1 = double.Parse(Console.ReadLine());

        Console.Write("Enter Y1: ");
        double y1 = double.Parse(Console.ReadLine());

        Console.Write("Enter X2: ");
        double x2 = double.Parse(Console.ReadLine());

        Console.Write("Enter Y2: ");
        double y2 = double.Parse(Console.ReadLine());

        Point point1 = new Point { X = x1, Y = y1 };
        Point point2 = new Point { X = x2, Y = y2 };

        double distance = Math.Sqrt(
            Math.Pow(point2.X - point1.X, 2) +
            Math.Pow(point2.Y - point1.Y, 2)
        );

        Console.WriteLine(distance);




        // Question 7



        Person[] people = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter name: ");
            people[i].Name = Console.ReadLine();

            Console.Write("Enter age: ");
            people[i].Age = int.Parse(Console.ReadLine());
        }

        Person oldest = people[0];

        for (int i = 1; i < 3; i++)
        {
            if (people[i].Age > oldest.Age)
            {
                oldest = people[i];
            }
        }

        Console.WriteLine($"Name: {oldest.Name}, Age: {oldest.Age}");
    }
}