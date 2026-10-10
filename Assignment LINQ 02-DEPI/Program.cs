using System.Globalization;
using System.Text;

namespace ASSLINQ;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        Directory.SetCurrentDirectory(AppContext.BaseDirectory);

        var products = ListGenerators.ProductList;
        var customers = ListGenerators.CustomerList;
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        string[] dictionary = File.ReadAllLines("dictionary_english.txt");

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
                          select new { c.CustomerName, OrderCount = c.Orders.Count() }).ToList();
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

        // 9. Get the total units in stock for each product category.
        var aggregate9 = from p in products
                         group p by p.Category into g
                         select new { Category = g.Key, TotalStock = g.Sum(p => p.UnitsInStock) };
        Console.WriteLine("\nAggregate 9");
        foreach (var item in aggregate9)
            Console.WriteLine($"{item.Category}: {item.TotalStock}");

        // 10. Get the cheapest price among each category's products.
        var aggregate10 = from p in products
                          group p by p.Category into g
                          select new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) };
        Console.WriteLine("\nAggregate 10");
        foreach (var item in aggregate10)
            Console.WriteLine($"{item.Category}: {item.CheapestPrice}");

        // 11. Get the products with the cheapest price in each category using let.
        var aggregate11 = from p in products
                          group p by p.Category into g
                          let cheapestPrice = g.Min(p => p.UnitPrice)
                          from p in g
                          where p.UnitPrice == cheapestPrice
                          select p;
        Console.WriteLine("\nAggregate 11");
        foreach (var item in aggregate11)
            Console.WriteLine($"{item.Category} - {item.ProductName}: {item.UnitPrice}");

        // 12. Get the most expensive price among each category's products.
        var aggregate12 = from p in products
                          group p by p.Category into g
                          select new { Category = g.Key, HighestPrice = g.Max(p => p.UnitPrice) };
        Console.WriteLine("\nAggregate 12");
        foreach (var item in aggregate12)
            Console.WriteLine($"{item.Category}: {item.HighestPrice}");

        // 13. Get the products with the most expensive price in each category.
        var aggregate13 = from p in products
                          group p by p.Category into g
                          let highestPrice = g.Max(p => p.UnitPrice)
                          from p in g
                          where p.UnitPrice == highestPrice
                          select p;
        Console.WriteLine("\nAggregate 13");
        foreach (var item in aggregate13)
            Console.WriteLine($"{item.Category} - {item.ProductName}: {item.UnitPrice}");

        // 14. Get the average price of each category's products.
        var aggregate14 = from p in products
                          group p by p.Category into g
                          select new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) };
        Console.WriteLine("\nAggregate 14");
        foreach (var item in aggregate14)
            Console.WriteLine($"{item.Category}: {item.AveragePrice}");

        // LINQ - Set Operators

        // 1. Find the unique category names from the product list.
        var set1 = (from p in products select p.Category).Distinct();
        Console.WriteLine("\nSet 1");
        foreach (var item in set1)
            Console.WriteLine(item);

        // 2. Get the unique first letters from both product and customer names.
        var set2 = (from p in products select p.ProductName[0])
            .Union(from c in customers select c.CustomerName[0]);
        Console.WriteLine("\nSet 2");
        foreach (var item in set2)
            Console.WriteLine(item);

        // 3. Get the common first letters from both product and customer names.
        var set3 = (from p in products select p.ProductName[0])
            .Intersect(from c in customers select c.CustomerName[0]);
        Console.WriteLine("\nSet 3");
        foreach (var item in set3)
            Console.WriteLine(item);

        // 4. Get product name first letters that are not customer name first letters.
        var set4 = (from p in products select p.ProductName[0])
            .Except(from c in customers select c.CustomerName[0]);
        Console.WriteLine("\nSet 4");
        foreach (var item in set4)
            Console.WriteLine(item);

        // 5. Get the last three characters of all customer and product names, including duplicates.
        var set5 = (from c in customers
                    select c.CustomerName.Substring(c.CustomerName.Length - 3))
            .Concat(from p in products
                    select p.ProductName.Substring(p.ProductName.Length - 3));
        Console.WriteLine("\nSet 5");
        foreach (var item in set5)
            Console.WriteLine(item);

        // LINQ - Partitioning Operators

        // 1. Get the first three orders from customers in Washington.
        var partition1 = (from c in customers
                          where c.Region == "WA"
                          from order in c.Orders
                          select order).Take(3);
        Console.WriteLine("\nPartitioning 1");
        foreach (var item in partition1)
            Console.WriteLine(item);

        // 2. Get all but the first two orders from customers in Washington.
        var partition2 = (from c in customers
                          where c.Region == "WA"
                          from order in c.Orders
                          select order).Skip(2);
        Console.WriteLine("\nPartitioning 2");
        foreach (var item in partition2)
            Console.WriteLine(item);

        // 3. Return elements until a number is less than its position in the array.
        var partition3 = (from n in numbers select n).TakeWhile((n, index) => n >= index);
        Console.WriteLine("\nPartitioning 3");
        foreach (var item in partition3)
            Console.WriteLine(item);

        // 4. Get array elements starting from the first element divisible by three.
        var partition4 = (from n in numbers select n).SkipWhile(n => n % 3 != 0);
        Console.WriteLine("\nPartitioning 4");
        foreach (var item in partition4)
            Console.WriteLine(item);

        // 5. Get array elements starting from the first element less than its position.
        var partition5 = (from n in numbers select n).SkipWhile((n, index) => n >= index);
        Console.WriteLine("\nPartitioning 5");
        foreach (var item in partition5)
            Console.WriteLine(item);

        // LINQ - Quantifiers

        // 1. Determine whether any dictionary words contain the substring 'ei'.
        var quantifier1 = (from word in dictionary
                           where word.Contains("ei")
                           select word).Any();
        Console.WriteLine("\nQuantifiers 1");
        Console.WriteLine(quantifier1);

        // 2. Group products for categories with at least one product out of stock.
        var quantifier2 = from p in products
                          group p by p.Category into g
                          where g.Any(p => p.UnitsInStock == 0)
                          select g;
        Console.WriteLine("\nQuantifiers 2");
        foreach (var group in quantifier2)
        {
            Console.WriteLine(group.Key);
            foreach (var item in group)
                Console.WriteLine(item.ProductName);
        }

        // 3. Group products for categories with all products in stock.
        var quantifier3 = from p in products
                          group p by p.Category into g
                          where g.All(p => p.UnitsInStock > 0)
                          select g;
        Console.WriteLine("\nQuantifiers 3");
        foreach (var group in quantifier3)
        {
            Console.WriteLine(group.Key);
            foreach (var item in group)
                Console.WriteLine(item.ProductName);
        }

        // LINQ - Grouping Operators

        // 1. Group numbers by their remainder when divided by five.
        List<int> groupNumbers = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        var grouping1 = from n in groupNumbers
                        group n by n % 5;
        Console.WriteLine("\nGrouping 1");
        foreach (var group in grouping1)
            Console.WriteLine($"{group.Key}: {string.Join(", ", group)}");

        // 2. Group the words in dictionary_english.txt by their first letter.
        var grouping2 = from word in dictionary
                        group word by word[0];
        Console.WriteLine("\nGrouping 2");
        foreach (var group in grouping2)
        {
            Console.WriteLine(group.Key);
            Console.WriteLine(string.Join(", ", group));
        }

        // 3. Group words with the same characters using a custom comparer.
        string[] words = { "from", "salt", "earn", " last", "near", "form" };
        var grouping3 = words.GroupBy(word => word, new AnagramComparer());
        Console.WriteLine("\nGrouping 3");
        foreach (var group in grouping3)
            Console.WriteLine(string.Join(", ", group));
    }
}

internal class AnagramComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        return SortLetters(x) == SortLetters(y);
    }

    public int GetHashCode(string word)
    {
        return SortLetters(word).GetHashCode();
    }

    private string SortLetters(string word)
    {
        return new string(word.Trim().OrderBy(letter => letter).ToArray());
    }
}
