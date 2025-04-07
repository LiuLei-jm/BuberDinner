using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;
public sealed class Price : ValueObject
{
    public double Amount { get; }
    public string Currency { get; }
    public Price(double amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }
    public static Price Create(double amount, string currency)
    {
        return new Price(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
