using System;

class Program
{
    static void Main()
    {
        int num = 1, z = 5;

        if (!(num <= 0))
        {
            Console.WriteLine(++num + z++ + " " + ++z);
        }
        else
        {
            Console.WriteLine(--num + z-- + " " + --z);
        }
    }
}



//Answer: d) 7 7