using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;
public sealed class MenuId : ValueObject
{
    public Guid Value { get; }
    private MenuId(Guid value)
    {
        Value = value;
    }
    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }
    public static MenuId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("MenuId cannot be empty", nameof(value));
        }
        return new MenuId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
