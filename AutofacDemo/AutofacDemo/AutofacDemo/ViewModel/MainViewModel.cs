using AutofacDemo.ViewModel.Base;

namespace AutofacDemo.ViewModel
{
    using System.Threading.Tasks;

    public class MainViewModel : ViewModelBase
    {
        private MenuViewModel menuViewModel;

        public MainViewModel(MenuViewModel menuViewModel)
        {
            this.menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => menuViewModel;

            set
            {
                menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAll
            (
                menuViewModel.InitializeAsync(navigationData),
                NavigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}