﻿using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;
public sealed class Reservation : Entity<ReservationId>
{

    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; } = null!;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Reservation(ReservationId reservationId, int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId, DateTime createdDateTime, DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static Reservation Create(int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId)
    {
        return new Reservation(ReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
