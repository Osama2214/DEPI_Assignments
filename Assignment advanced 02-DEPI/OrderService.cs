
using System;

// User-defined delegate
public delegate decimal PriceCalculator(Order order);

public class OrderService
{
    // Part 1: User-defined Delegate
    public decimal CalculateOrderPrice(
        Order order,
        PriceCalculator calculator)
    {
        return calculator(order);
    }

    // Part 2: Built-in Func Delegate
    public decimal CalculateOrderPrice(
        Order order,
        Func<Order, decimal> calculator)
    {
        return calculator(order);
    }

    // Part 3: Predicate
    public bool ValidateOrder(
        Order order,
        Predicate<Order> validationRule)
    {
        return validationRule(order);
    }

    // Part 4: Action
    public void ProcessOrder(
        Order order,
        Action<Order> action)
    {
        action(order);
    }

    // Part 5: Event
   public event Action<Order>? OrderProcessed;
    public void ProcessOrder(Order order)
    {
        Console.WriteLine(
            $"Processing order {order.Id}..."
        );

        OrderProcessed?.Invoke(order);
    }
}