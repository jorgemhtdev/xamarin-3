namespace AutofacDemo.ViewModel
{
    using Services.Authentication;
    using Base;
    using Model;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    using MenuItem = Model.MenuItem;

    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<MenuItem> menuItems;
        public string UserName => AppSettings.User?.Name;
        public string UserAvatar => AppSettings.User?.ImageProfile;

        public ObservableCollection<MenuItem> MenuItems
        {
            get => menuItems;
            set => SetProperty(ref menuItems, value);
        }

        private readonly IAuthenticationService authenticationService;

        
        public MenuViewModel(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;

            MenuItems = new ObservableCollection<MenuItem>();

            InitMenuItems();
        }

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>();

            InitMenuItems();
        }

        public ICommand MenuItemSelectedCommand => new Command<MenuItem>(OnSelectMenuItem);

        private void InitMenuItems()
        {
            MenuItems.Add(new MenuItem
            {
                Title = "Home",
                MenuItemType = MenuItemType.Home,
                ViewModelType = typeof(MainViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new MenuItem
            {
                Title = "My profile",
                MenuItemType = MenuItemType.MyProfile,
                ViewModelType = typeof(ProfileViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new MenuItem
            {
                Title = "Logout",
                MenuItemType = MenuItemType.Logout,
                ViewModelType = typeof(LoginViewModel),
                IsEnabled = true,
                AfterNavigationAction = RemoveUserCredentials
            });
        }

        private async void OnSelectMenuItem(MenuItem item)
        {
            if (!item.IsEnabled || item.ViewModelType == null) return;

            item.AfterNavigationAction?.Invoke();
            await NavigationService.NavigateToAsync(item.ViewModelType, item);
        }

        private Task RemoveUserCredentials() => authenticationService.LogoutAsync();
    }
}
