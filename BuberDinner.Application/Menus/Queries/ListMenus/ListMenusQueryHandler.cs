using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.ListMenus;

public class ListMenusQueryHandler : IRequestHandler<ListMenusQuery, ErrorOr<List<Menu>>>
{
    private readonly IMenuRepository _menuRepository;

    public ListMenusQueryHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<List<Menu>>> Handle(
        ListMenusQuery request,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask; // Simulate async work
        var menu = _menuRepository.GetAll();
        return menu;
    }
}
