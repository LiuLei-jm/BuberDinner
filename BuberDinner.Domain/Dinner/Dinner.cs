using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using Price = BuberDinner.Domain.Dinner.ValueObjects.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;

namespace BuberDinner.Domain.Dinner;
public sealed class Dinner : AggregateRoot<DinnerId>
{
    private static List<Reservation> _reservations => new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; } = null!;
    public DateTime? EndedDateTime { get; } = null!;
    public  DinnerStatus Status { get; }
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
    public Dinner(DinnerId id) : base(id)
    {
    }
}
