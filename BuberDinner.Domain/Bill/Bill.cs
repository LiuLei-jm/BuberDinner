using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using Price = BuberDinner.Domain.Dinner.ValueObjects.Price;

namespace BuberDinner.Domain.Bill;
public sealed class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public Bill(BillId id, DinnerId dinnerId, GuestId guestId, HostId hostId, DateTime createdDateTime, DateTime UpdatedDateTime) : base(id)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        this.UpdatedDateTime = UpdatedDateTime;
    }
    public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId)
    {
        return new Bill(BillId.CreateUnique(), dinnerId, guestId, hostId, DateTime.UtcNow, DateTime.UtcNow)
        ;
    }
}
