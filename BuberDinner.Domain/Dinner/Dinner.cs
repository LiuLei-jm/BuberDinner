using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using Price = BuberDinner.Domain.Dinner.ValueObjects.Price;

namespace BuberDinner.Domain.Dinner;
public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private static List<Reservation> _reservations => new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; } = null!;
    public DateTime? EndedDateTime { get; } = null!;
    public DinnerStatus Status { get; }
    public bool IsPublic { get; }
    public int MaxGuest { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Dinner(DinnerId dinnerId, string name, string description, DateTime startDateTime, DateTime endDateTime, DinnerStatus status, bool isPublic, int maxGuest, Price price, HostId hostId, MenuId menuId, string imageUrl, Location location) : base(dinnerId)
    {
        Id = dinnerId;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuest = maxGuest;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
    }
    public static Dinner Create(string name, string description, DateTime startDateTime, DateTime endDateTime, DinnerStatus status, bool isPublic, int maxGuest, Price price, HostId hostId, MenuId menuId, string imageUrl, Location location)
    {
        return new Dinner(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime, status, isPublic, maxGuest, price, hostId, menuId, imageUrl, location);
    }
}
