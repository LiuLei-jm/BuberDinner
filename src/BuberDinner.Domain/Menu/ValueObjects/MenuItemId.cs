using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;
public sealed class MenuItemId : ValueObject
{
    public Guid Value { get; }

    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("MenuItemId cannot be empty", nameof(value));
        }
        return new MenuItemId(value);
    }

    public static MenuItemId Create(string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException("MenuItemId cannot be empty", nameof(value));
        }
        return new MenuItemId(Guid.Parse(value));
    }
    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
