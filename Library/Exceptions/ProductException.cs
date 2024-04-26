/*
 * Author: Sakthi Santhosh
 * Created on: 24/04/2024
 */
namespace Challenge1.Library.Exceptions;

public class InsufficientStockException : Exception
{
    public InsufficientStockException() : base(message: "Product has insufficient stock.")
    {
    }

    public InsufficientStockException(string message) : base(message)
    {
    }

    public InsufficientStockException(string message, Exception inner) : base(message, inner)
    {
    }
}

public class AgeIneligibilityException : Exception
{
    public AgeIneligibilityException() : base(message: "Age ineligible to buy the product.")
    {
    }

    public AgeIneligibilityException(string message) : base(message)
    {
    }

    public AgeIneligibilityException(string message, Exception inner) : base(message, inner)
    {
    }
}
