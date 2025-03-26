namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            await Task.CompletedTask;
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "token"
            );
        }

        public async Task<AuthenticationResult> RegisterAsync(
            string firstName,
            string lastName,
            string email,
            string password
        )
        {
            await Task.CompletedTask;
            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, "token");
        }
    }
}
