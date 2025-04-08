using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;
public sealed class GuestRating : Entity<GuestRatingId>
{
    public string Comment { get; }
    public int Stars { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private GuestRating(GuestRatingId id, string comment, int stars) : base(id)
    {
        Comment = comment;
        Stars = stars;
    }
    public static GuestRating Create(string comment, int stars)
    {
        return new GuestRating(GuestRatingId.CreateUnique(), comment, stars);
    }
}
