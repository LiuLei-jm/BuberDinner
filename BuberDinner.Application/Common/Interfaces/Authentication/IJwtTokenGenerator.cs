
using BuberDinner.Domain.User;

namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(User user);
    }
}
