using System;

class Person
{
    public string Name;
}

class Program
{
    static void Main()
    {
        Person person1 = new Person();
        person1.Name = "Ahmed";

        Person person2 = person1;

        person2.Name = "Mohamed";

        Console.WriteLine(person1.Name);
        Console.WriteLine(person2.Name);
    }
}