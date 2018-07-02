using AutofacDemo.Services.Authentication;
using AutofacDemo.Validations;
using AutofacDemo.ViewModel.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AutofacDemo.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService authenticationService;

        private ValidatableObject<string> userName;
        private ValidatableObject<string> password;

        public ValidatableObject<string> UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;

            userName = new ValidatableObject<string>();
            password = new ValidatableObject<string>();

            AddValidations();
        }

        public ICommand SignInCommand => new AsyncCommand(SignInAsync);

        private async Task SignInAsync()
        {
            IsBusy = true;

            bool isValid = Validate();

            if (isValid)
            {
                bool isAuth = await authenticationService.LoginAsync(UserName.Value, Password.Value);

                if (isAuth)
                {
                    IsBusy = false;

                    await NavigationService.NavigateToAsync<MainViewModel>();
                }
            }

            IsBusy = false;
        }


        private bool Validate()
        {
            bool isValidUser = userName.Validate();
            bool isValidPassword = password.Validate();

            return isValidUser && isValidPassword;
        }

        private void AddValidations()
        {
            userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Username should not be empty" });
            userName.Validations.Add(new EmailRule());
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password should not be empty" });
        }

    }
}
