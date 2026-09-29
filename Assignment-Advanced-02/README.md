
# Assignment 02 - C# Delegates & Events

## Q1. What is the difference between PriceCalculator and Func<Order, decimal>?

PriceCalculator is a custom delegate created by the programmer.
Func<Order, decimal> is a built-in generic delegate provided by C#.

Both represent a method that takes an Order and returns a decimal.

The main difference is that Func is reusable and does not require creating a custom delegate for every similar method signature.

## Q2. What is the difference between Action<Order> and Func<Order, decimal>?

Action<Order> takes an Order as a parameter and does not return a value.

Func<Order, decimal> takes an Order as a parameter and returns a decimal value.

Action is useful for performing operations, while Func is useful for calculations that produce a result.

## Q3. Why does Predicate<T> return bool?

Predicate<T> is designed to represent a condition or a test.

It takes an object of type T and returns true or false depending on whether the object satisfies the condition.

For example, checking whether an order's quantity is greater than zero.

## Q4. What is the difference between a delegate and an event?

A delegate is a type that can reference methods with a specific signature.

An event is a mechanism that allows a class to notify other parts of the application when something happens.

A delegate can be invoked by code that has access to it, while an event restricts external code to subscribing and unsubscribing handlers.

## Q5. Why can't external code normally invoke an event declared in another class?

Because events are designed to be raised only by the class that declares them.

External code can subscribe or unsubscribe handlers, but it cannot directly invoke the event.

This protects the event owner and ensures that notifications are raised under the control of the declaring class.

## Q6. What happens when multiple handlers subscribe to the same event?

All subscribed handlers are called when the event is raised.

This is called multicast behavior.

Each handler can perform a different operation, such as sending a notification, printing a message, or writing an audit log.

## Q7. Explain the following code:

orderService.OrderProcessed += HandleOrderProcessed;

OrderProcessed:
The event that notifies subscribers when an order is processed.

+=:
The subscription operator. It adds a handler to the event.

HandleOrderProcessed:
The method that will be executed when the event is raised.

Together, this statement subscribes HandleOrderProcessed to the OrderProcessed event.

## Q8. What is the difference between Action<Order> and event Action<Order>?

Action<Order> is a delegate that can be invoked directly by code that holds it.

event Action<Order> is an event that uses Action<Order> as its underlying delegate type.

An event restricts external code to subscribing and unsubscribing handlers instead of directly invoking or replacing the delegate.

Events provide controlled notifications and protect the class that declares them.