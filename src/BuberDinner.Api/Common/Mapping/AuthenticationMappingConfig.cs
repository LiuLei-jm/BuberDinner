using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config
            .NewConfig<AuthenticationResult, AuthenticationResponse>()
            .MapWith(src => new AuthenticationResponse(src.User.Id.Value, src.User.FirstName, src.User.LastName, src.User.Email, src.Token));
    }
}
