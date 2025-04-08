using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;
public sealed class HostId : ValueObject
{
    public Guid Value { get; }

    public HostId(Guid value)
    {
        Value = value;
    }
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(string value)
    {
        return new HostId(Guid.Parse(value));
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
