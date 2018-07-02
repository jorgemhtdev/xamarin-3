namespace AutofacDemo.Services.Authentication
{
    using System.Threading.Tasks;
    using Model;

    public class FakeAuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated => AppSettings.User != null;

        public User AuthenticatedUser => new User
        {
            Email = "jorge@mht.com",
            Name = "Jorge",
            LastName = "MHT",
            ImageProfile = "http://esmateria.com/wp-content/uploads/2014/02/house3.jpg"
        };

        public async Task<bool> LoginAsync(string userName, string password)
        {
            await Task.Delay(500);

            var succeeded = AuthenticatedUser.Email.ToLower() == userName.ToLower();

            if(succeeded) AppSettings.User = AuthenticatedUser;

            return succeeded;
        }

        public Task<bool> UserIsAuthenticatedAndValidAsync()
        {
            return Task.FromResult(IsAuthenticated);
        }


        public async Task LogoutAsync()
        {
            AppSettings.RemoveUserData();
        }
    }
}
