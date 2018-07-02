namespace AutofacDemo.Model
{
    using System.Threading.Tasks;
    using System;
    using Xamarin.Forms;

    public class MenuItem : BindableObject
    {
        private string title;
        private MenuItemType menuItemType;
        private Type viewModelType;
        private bool isEnabled;

        public string Title
        {
            get => title;
            //set => SetProperty(ref title, value);

            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public MenuItemType MenuItemType
        {
            get => menuItemType;
            //set => SetProperty(ref menuItemType, value);

            set
            {
                menuItemType = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelType
        {
            get => viewModelType;
            //set => SetProperty(ref viewModelType, value);

            set
            {
                viewModelType = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get => isEnabled;
            //set => SetProperty(ref isEnabled, value);

            set
            {
                isEnabled = value;
                OnPropertyChanged();
            }
        }

        public Func<Task> AfterNavigationAction { get; set; }
    }
}
