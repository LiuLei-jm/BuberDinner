using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;
public sealed class HostId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private HostId(Guid value)
    {
        Value = value;
    }
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("HostId cannot be empty", nameof(value));
        }
        return new HostId(value);
    }
    public static HostId Create(string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException("HostId cannot be empty", nameof(value));
        }
        Guid.TryParse(value, out var guidValue);
        return new HostId(guidValue);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
