using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Menu;
public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; }
    public string Description { get; }  
    public AverageRating AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();
    public HostId HostId { get; }
    public DateTime CreateDatedTime { get; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();    
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public Menu(MenuId id, string name, string description, HostId hostId, DateTime createDatedTime, DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreateDatedTime = createDatedTime;
        UpdatedDateTime = updatedDateTime;
    }
    public static Menu Create(string name, string description, HostId hostId)
    {
        return new Menu(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow);
    }
}
