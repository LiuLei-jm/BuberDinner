using BuberDinner.Domain.Menu;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.ListMenus;

public record ListMenusQuery
(
) : IRequest<ErrorOr<List<Menu>>>;

