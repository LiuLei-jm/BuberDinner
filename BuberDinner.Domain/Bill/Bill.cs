using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using Price = BuberDinner.Domain.Dinner.ValueObjects.Price;

namespace BuberDinner.Domain.Bill;
public sealed class Bill : AggregateRoot<BillId, Guid>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Bill(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId) : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }
    public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId)
    {
        return new Bill(BillId.CreateUnique(), dinnerId, guestId, hostId)
        ;
    }
}
