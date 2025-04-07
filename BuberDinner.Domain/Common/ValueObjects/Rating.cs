using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Common.ValueObjects;
public sealed class Rating : ValueObject
{
    public double Value { get; }

    public Rating(double value)
    {
        Value = value;
    }
    public static Rating Create(double value)
    {
        if (value < 0 || value > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Rating must be between 0 and 5.");
        }
        return new Rating(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
