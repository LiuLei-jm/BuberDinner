using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;
public sealed class DinnerId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private DinnerId(Guid value)
    {
        Value = value;
    }
    public static DinnerId Create(Guid value)
    {
        if(value == Guid.Empty)
        {
            throw new ArgumentException("DinnerId cannot be empty", nameof(value));
        }
        return new DinnerId(value);
    }
    public static DinnerId Create(string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException("DinnerId cannot be empty", nameof(value));
        }
        return new DinnerId(Guid.Parse(value));
    }
    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
