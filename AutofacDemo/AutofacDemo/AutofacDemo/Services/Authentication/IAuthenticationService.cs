namespace AutofacDemo.Services.Authentication
{
    using System.Threading.Tasks;
    using Model;

    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }

        User AuthenticatedUser { get; }

        Task<bool> LoginAsync(string email, string password);

        Task<bool> UserIsAuthenticatedAndValidAsync();

        Task LogoutAsync();
    }
}
