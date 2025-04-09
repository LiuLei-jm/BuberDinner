using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;
public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    public MenuSectionId(Guid value)
    {
        Value = value;
    }
    public static MenuSectionId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("MenuSectionId cannot be empty", nameof(value));
        }
        return new MenuSectionId(value);
    }
    public static MenuSectionId Create(string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException("MenuSectionId cannot be empty", nameof(value));
        }
        return new MenuSectionId(Guid.Parse(value));
    }
    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
