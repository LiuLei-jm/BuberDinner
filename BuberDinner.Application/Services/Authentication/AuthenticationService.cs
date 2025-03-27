using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            await Task.CompletedTask;

            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateJwtToken(userId, "firstName", "lastName");
            return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, token);
        }

        public async Task<AuthenticationResult> RegisterAsync(
            string firstName,
            string lastName,
            string email,
            string password
        )
        {
            await Task.CompletedTask;
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateJwtToken(userId, firstName, lastName);
            return new AuthenticationResult(userId, firstName, lastName, email, token);
        }
    }
}
