using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutofacDemo.Services.Authentication;
using AutofacDemo.ViewModel.Base;

namespace AutofacDemo.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticationService authenticationService;

        public HomeViewModel(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                var authenticatedUser = authenticationService.AuthenticatedUser;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Home] Error: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }


}
