
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // ==============================
        // Section 01: Book Processing
        // ==============================

        Console.WriteLine("===== Section 01: Book Processing =====");

        List<Book> books = new List<Book>
        {
            new Book(
                "978-111",
                "C# Basics",
                new string[] { "Ahmed Ali", "Mohamed Samir" },
                new DateTime(2023, 5, 10),
                250m
            ),

            new Book(
                "978-222",
                "Advanced C#",
                new string[] { "Osama Ahmed" },
                new DateTime(2024, 8, 15),
                400m
            )
        };

        // 1. Custom Delegate
        Console.WriteLine("\n--- Custom Delegate: GetTitle ---");

        LibraryEngine.ProcessBooks(
            books,
            (BookDelegate)BookFunctions.GetTitle
        );

      // 2. Built-in Delegate: Func
Console.WriteLine("\n--- Func: GetAuthors ---");

LibraryEngine.ProcessBooks(
    books,
    (Func<Book, string>)BookFunctions.GetAuthors
);


// 3. Anonymous Method: GetISBN
Console.WriteLine("\n--- Anonymous Method: GetISBN ---");

LibraryEngine.ProcessBooks(
    books,
    (BookDelegate)delegate (Book B)
    {
        return BookFunctions.GetISBN(B);
    }
);


// 4. Lambda Expression: GetPublicationDate
Console.WriteLine("\n--- Lambda: GetPublicationDate ---");

LibraryEngine.ProcessBooks(
    books,
    (Func<Book, string>)(B =>
        BookFunctions.GetPublicationDate(B))
);


        // ==============================
        // Section 02: Order Processing
        // ==============================

        Console.WriteLine("\n===== Section 02: Order Processing =====");

        Order order = new Order(
            101,
            "Osama",
            100m,
            3
        );

        OrderService service = new OrderService();


        // 1. Custom Delegate: Price Calculation

        Console.WriteLine("\n--- Custom Delegate: Calculate Total ---");

        decimal total1 = service.CalculateOrderPrice(
            order,
            (PriceCalculator)CalculateTotal
        );

        Console.WriteLine($"Total Price: {total1:C}");


        // Custom Delegate: Discount

        Console.WriteLine("\n--- Custom Delegate: Calculate With Discount ---");

        decimal total2 = service.CalculateOrderPrice(
            order,
            (PriceCalculator)CalculateTotalWithDiscount
        );

        Console.WriteLine($"Discounted Price: {total2:C}");


        // 2. Func Delegate

        Console.WriteLine("\n--- Func: Calculate Total ---");

        decimal total3 = service.CalculateOrderPrice(
            order,
            new Func<Order, decimal>(
                o => CalculateTotal(o)
            )
        );

        Console.WriteLine($"Total Price: {total3:C}");


        // Func with Lambda: 10% Discount

        Console.WriteLine("\n--- Func: 10% Discount ---");

        decimal total4 = service.CalculateOrderPrice(
            order,
            new Func<Order, decimal>(
                o => o.Price * o.Quantity * 0.90m
            )
        );

        Console.WriteLine($"Price After 10% Discount: {total4:C}");


        // 3. Predicate: Order Validation

        Console.WriteLine("\n--- Predicate: Order Validation ---");

        bool validPrice = service.ValidateOrder(
            order,
            o => o.Price > 0
        );

        bool validQuantity = service.ValidateOrder(
            order,
            o => o.Quantity > 0
        );

        bool validCustomer = service.ValidateOrder(
            order,
            o => !string.IsNullOrWhiteSpace(o.CustomerName)
        );

        Console.WriteLine($"Valid Price: {validPrice}");
        Console.WriteLine($"Valid Quantity: {validQuantity}");
        Console.WriteLine($"Valid Customer: {validCustomer}");


        // 4. Action Delegate

        Console.WriteLine("\n--- Action: Order Processing Actions ---");

        service.ProcessOrder(
            order,
            o => Console.WriteLine(
                $"Sending confirmation to {o.CustomerName}"
            )
        );

        service.ProcessOrder(
            order,
            o => Console.WriteLine(
                $"Logging order ID: {o.Id}"
            )
        );

        service.ProcessOrder(
            order,
            o => Console.WriteLine(
                $"Order total: {o.Price * o.Quantity:C}"
            )
        );


        // 5. Events

        Console.WriteLine("\n--- Events: Order Processed ---");

        service.OrderProcessed += HandleOrderProcessed;

        service.OrderProcessed += o =>
            Console.WriteLine(
                $"Email notification sent for order {o.Id}"
            );

        service.OrderProcessed += o =>
            Console.WriteLine(
                $"Order {o.Id} saved to database"
            );

        // Multicast event: all subscribers are called
        service.ProcessOrder(order);

        // Unsubscribe one handler
        service.OrderProcessed -= HandleOrderProcessed;

        Console.WriteLine("\n--- After Unsubscribing Handler ---");

        service.ProcessOrder(order);


        // ==============================
        // Bonus: Pricing Strategies
        // ==============================

        Console.WriteLine("\n===== Bonus: Pricing Strategies =====");

        Func<Order, decimal> normalPrice =
            o => o.Price * o.Quantity;

        Func<Order, decimal> discount10 =
            o => o.Price * o.Quantity * 0.90m;

        Func<Order, decimal> discount20 =
            o => o.Price * o.Quantity * 0.80m;

        Func<Order, decimal> vipDiscount =
            o => o.Price * o.Quantity * 0.75m;

        Console.WriteLine(
            $"Normal Price: {normalPrice(order):C}"
        );

        Console.WriteLine(
            $"10% Discount: {discount10(order):C}"
        );

        Console.WriteLine(
            $"20% Discount: {discount20(order):C}"
        );

        Console.WriteLine(
            $"VIP 25% Discount: {vipDiscount(order):C}"
        );


        Console.WriteLine("\n===== Program Finished =====");
    }


    // ==============================
    // Helper Methods
    // ==============================

    static decimal CalculateTotal(Order order)
    {
        return order.Price * order.Quantity;
    }

    static decimal CalculateTotalWithDiscount(Order order)
    {
        decimal total = order.Price * order.Quantity;

        return total - 50m;
    }

    static void HandleOrderProcessed(Order order)
    {
        Console.WriteLine(
            $"Order {order.Id} processed successfully!"
        );
    }
}