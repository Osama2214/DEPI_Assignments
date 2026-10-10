using System.Globalization;
using System.Text;

namespace Day_01_G03;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        Directory.SetCurrentDirectory(AppContext.BaseDirectory);

        var products = ListGenerator.ProductsList;
        var customers = ListGenerator.CustomersList;
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        string[] mixedCaseWords = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        string[] dictionary = File.ReadAllLines("dictionary_english.txt");

        // LINQ - Restriction Operators

        // 1. Find all products that are out of stock.
        var restriction1 = from p in products
                           where p.UnitsInStock == 0
                           select p;
        Console.WriteLine("\nRestriction 1");
        foreach (var item in restriction1)
            Console.WriteLine(item.ProductName);

        // 2. Find all products that are in stock and cost more than 3.00 per unit.
        var restriction2 = from p in products
                           where p.UnitsInStock > 0 && p.UnitPrice > 3.00m
                           select p;
        Console.WriteLine("\nRestriction 2");
        foreach (var item in restriction2)
            Console.WriteLine($"{item.ProductName} - Price: {item.UnitPrice:0.00}, Stock: {item.UnitsInStock}");

        // 3. Return digits whose name is shorter than their value.
        var restriction3 = from value in Enumerable.Range(0, digits.Length)
                           let name = digits[value]
                           where name.Length < value
                           select name;
        Console.WriteLine("\nRestriction 3");
        foreach (var item in restriction3)
            Console.WriteLine(item);

        // LINQ - Element Operators

        // 1. Get the first product out of stock.
        var element1 = (from p in products
                        where p.UnitsInStock == 0
                        select p).First();
        Console.WriteLine("\nElement 1");
        Console.WriteLine(element1.ProductName);

        // 2. Return the first product whose price > 1000, or null if there is no match.
        var element2 = (from p in products
                        where p.UnitPrice > 1000m
                        select p).FirstOrDefault();
        Console.WriteLine("\nElement 2");
        Console.WriteLine(element2?.ProductName ?? "null");

        // 3. Retrieve the second number greater than 5.
        var element3 = (from n in numbers
                        where n > 5
                        select n).ElementAt(1);
        Console.WriteLine("\nElement 3");
        Console.WriteLine(element3);

        // LINQ - Aggregate Operators

        // 1. Use Count to get the number of odd numbers in the array.
        var aggregate1 = (from n in numbers
                          where n % 2 != 0
                          select n).Count();
        Console.WriteLine("\nAggregate 1");
        Console.WriteLine(aggregate1);

        // 2. Return a list of customers and how many orders each has.
        var aggregate2 = (from c in customers
                          select new
                          {
                              c.CustomerID,
                              c.CustomerName,
                              OrderCount = c.Orders.Count()
                          }).ToList();
        Console.WriteLine("\nAggregate 2");
        foreach (var item in aggregate2)
            Console.WriteLine($"{item.CustomerName}: {item.OrderCount} orders");

        // 3. Return a list of categories and how many products each has.
        var aggregate3 = (from p in products
                          group p by p.Category into g
                          select new { Category = g.Key, ProductCount = g.Count() }).ToList();
        Console.WriteLine("\nAggregate 3");
        foreach (var item in aggregate3)
            Console.WriteLine($"{item.Category}: {item.ProductCount} products");

        // 4. Get the total of the numbers in an array.
        var aggregate4 = (from n in numbers select n).Sum();
        Console.WriteLine("\nAggregate 4");
        Console.WriteLine(aggregate4);

        // 5. Get the total number of characters of all words in dictionary_english.txt.
        var aggregate5 = (from word in dictionary select word.Length).Sum();
        Console.WriteLine("\nAggregate 5");
        Console.WriteLine(aggregate5);

        // 6. Get the length of the shortest word in dictionary_english.txt.
        var aggregate6 = (from word in dictionary select word.Length).Min();
        Console.WriteLine("\nAggregate 6");
        Console.WriteLine(aggregate6);

        // 7. Get the length of the longest word in dictionary_english.txt.
        var aggregate7 = (from word in dictionary select word.Length).Max();
        Console.WriteLine("\nAggregate 7");
        Console.WriteLine(aggregate7);

        // 8. Get the average length of the words in dictionary_english.txt.
        var aggregate8 = (from word in dictionary select word.Length).Average();
        Console.WriteLine("\nAggregate 8");
        Console.WriteLine(aggregate8);

        // LINQ - Ordering Operators

        // 1. Sort a list of products by name.
        var ordering1 = from p in products
                        orderby p.ProductName
                        select p;
        Console.WriteLine("\nOrdering 1");
        foreach (var item in ordering1)
            Console.WriteLine(item.ProductName);

        // 2. Use a custom comparer to do a case-insensitive sort of the words in an array.
        var ordering2 = mixedCaseWords.OrderBy(word => word, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("\nOrdering 2");
        foreach (var item in ordering2)
            Console.WriteLine(item);

        // 3. Sort products by units in stock from highest to lowest.
        var ordering3 = from p in products
                        orderby p.UnitsInStock descending
                        select p;
        Console.WriteLine("\nOrdering 3");
        foreach (var item in ordering3)
            Console.WriteLine($"{item.ProductName} - Stock: {item.UnitsInStock}");

        // 4. Sort digits first by name length, then alphabetically by name.
        var ordering4 = from name in digits
                        orderby name.Length, name
                        select name;
        Console.WriteLine("\nOrdering 4");
        foreach (var item in ordering4)
            Console.WriteLine(item);

        // 5. Sort first by word length, then by a case-insensitive sort of the words.
        var ordering5 = (from word in mixedCaseWords
                         orderby word.Length
                         select word).ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("\nOrdering 5");
        foreach (var item in ordering5)
            Console.WriteLine(item);

        // 6. Sort products first by category, then by unit price from highest to lowest.
        var ordering6 = from p in products
                        orderby p.Category, p.UnitPrice descending
                        select p;
        Console.WriteLine("\nOrdering 6");
        foreach (var item in ordering6)
            Console.WriteLine($"{item.Category} - {item.ProductName} - Price: {item.UnitPrice:0.00}");

        // 7. Sort first by word length, then by a case-insensitive descending sort.
        var ordering7 = (from word in mixedCaseWords
                         orderby word.Length
                         select word).ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("\nOrdering 7");
        foreach (var item in ordering7)
            Console.WriteLine(item);

        // 8. Return digits whose second letter is 'i', reversing their original order.
        var ordering8 = (from name in digits
                         where name.Length > 1 && name[1] == 'i'
                         select name).Reverse().ToList();
        Console.WriteLine("\nOrdering 8");
        foreach (var item in ordering8)
            Console.WriteLine(item);

        // LINQ - Transformation Operators

        // 1. Return a sequence of just the names of a list of products.
        var transformation1 = from p in products select p.ProductName;
        Console.WriteLine("\nTransformation 1");
        foreach (var item in transformation1)
            Console.WriteLine(item);

        // 2. Produce uppercase and lowercase versions of each word using anonymous types.
        string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

        var transformation2 = from word in words
                              select new
                              {
                                  Upper = word.ToUpperInvariant(),
                                  Lower = word.ToLowerInvariant()
                              };
        Console.WriteLine("\nTransformation 2");
        foreach (var item in transformation2)
            Console.WriteLine($"{item.Upper} / {item.Lower}");

        // 3. Select some product properties, renaming UnitPrice to Price.
        var transformation3 = from p in products
                              select new
                              {
                                  p.ProductID,
                                  p.ProductName,
                                  Price = p.UnitPrice
                              };
        Console.WriteLine("\nTransformation 3");
        foreach (var item in transformation3)
            Console.WriteLine($"{item.ProductID} - {item.ProductName} - Price: {item.Price:0.00}");

        // 4. Determine whether each number matches its position in the array.
        var transformation4 = from index in Enumerable.Range(0, numbers.Length)
                              let number = numbers[index]
                              select new
                              {
                                  Number = number,
                                  InPlace = number == index
                              };
        Console.WriteLine("\nTransformation 4");
        foreach (var item in transformation4)
            Console.WriteLine($"{item.Number}: {item.InPlace}");

        // 5. Return all pairs where the number from numbersA is less than the number from numbersB.
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var transformation5 = from a in numbersA
                              from b in numbersB
                              where a < b
                              select new { A = a, B = b };
        Console.WriteLine("\nTransformation 5");
        foreach (var item in transformation5)
            Console.WriteLine($"{item.A} < {item.B}");

        // 6. Select all orders where the order total is less than 500.00.
        var transformation6 = from c in customers
                              from order in c.Orders
                              where order.Total < 500.00m
                              select order;
        Console.WriteLine("\nTransformation 6");
        foreach (var item in transformation6)
            Console.WriteLine($"Order {item.OrderID} - Total: {item.Total:0.00}");

        // 7. Select all orders made in 1998 or later.
        var transformation7 = from c in customers
                              from order in c.Orders
                              where order.OrderDate >= new DateTime(1998, 1, 1)
                              select order;
        Console.WriteLine("\nTransformation 7");
        foreach (var item in transformation7)
            Console.WriteLine($"Order {item.OrderID} - Date: {item.OrderDate:yyyy-MM-dd}");

    }
}
